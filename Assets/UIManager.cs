using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject LobbyPanel;


    public void OnClickStart()
    {
        GameMGR.Instance.GameStart();
        LobbyPanel.SetActive(false);
    }

    public void OnClickExit()
    {
        GameMGR.Instance.GameEnd();
    }

    
}
