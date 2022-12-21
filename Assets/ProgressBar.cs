using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Text percentText;
    [SerializeField] Image percentIMG;

    [SerializeField] public Transform playerPos;
    [SerializeField] public Vector2 playerCurPos;

    [SerializeField] float arrive;


    private void Update()
    {
        
        if (playerPos == null) return;
        playerCurPos = playerPos.position;
        percentText.text = $"{(int)(((int)(playerPos.transform.position.x) / arrive)*100)}%";
        percentIMG.fillAmount = (playerPos.transform.position.x / arrive);

    }
    
}
