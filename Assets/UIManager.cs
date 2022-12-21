using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject LobbyPanel;
    [SerializeField] GameObject InGameScene;

    bool resume = false;
    bool showMenu = false;

    public void OnClickStart()
    {
        GameMGR.Instance.GameStart();
        LobbyPanel.SetActive(false);
    }

    public void OnClickExit()
    {
        GameMGR.Instance.GameEnd();
    }

    public void OnClickShowMenu()
    {
        if (!showMenu)
        {
            InGameScene.transform.GetChild(1).gameObject.SetActive(true);
            showMenu = true;
        }

        else
        { 
            InGameScene.transform.GetChild(1).gameObject.SetActive(false);
            showMenu = false;
        }
    }

    public void OnClickHome()
    {
        GameMGR.Instance.GoHome();
        LobbyPanel.SetActive(true);
        resume = false;
        Time.timeScale = 1f;
        showMenu = false;
        InGameScene.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void OnClickResume()
    {
        if(!resume)
        {
            Time.timeScale = 0f;
            resume = true;

        }
        else
        {
            Time.timeScale = 1f;
            resume = false;
        }
    }

}
