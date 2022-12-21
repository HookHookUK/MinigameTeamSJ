using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject Player;


    public void OnClickStart()
    {
        GameMGR.Instance.GameStart();
        gameObject.SetActive(false);
    }

    public void OnClickExit()
    {
        GameMGR.Instance.GameEnd();
    }

    
}
