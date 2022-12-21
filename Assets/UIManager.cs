using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject LobbyPanel;
    [SerializeField] public GameObject InGameScene;

    public bool showMenu = false;

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
            Time.timeScale = 0f;
        }

        else
        { 
            InGameScene.transform.GetChild(1).gameObject.SetActive(false);
            showMenu = false;
            Time.timeScale = 1f;
        }
    }

    public void OnClickOption()
    {
       
    }

    public void OnClickHome()
    {
        GameMGR.Instance.RemovePlayer();
        GameMGR.Instance.audioMGR.PlaySound(SoundList.Start);
        LobbyPanel.SetActive(true);
        Time.timeScale = 1f;
        showMenu = false;
        InGameScene.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void OnClickRestart()
    {
        showMenu = false;
        InGameScene.transform.GetChild(1).gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameMGR.Instance.RemovePlayer();
        GameMGR.Instance.GameStart();
    }

}
