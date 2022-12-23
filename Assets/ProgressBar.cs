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

    public float arrive;

    bool isEndStage;

    private void Update()
    {

        if (isEndStage) return;
        if (playerPos == null) return;

        playerCurPos = playerPos.position;
        if (playerCurPos.x < 0)
        {
            percentText.text = 0 + "%";
            percentIMG.fillAmount = 0;
        }
        else if (playerCurPos.x < arrive)
        {
            percentText.text = $"{(int)(((int)(playerPos.transform.position.x) / arrive) * 100)}%";
            percentIMG.fillAmount = (playerPos.transform.position.x / arrive);
        }
        else
        {
            percentText.text = 100 + "%";
            percentIMG.fillAmount = 1;
            EndStage();
        }

    }
    public void EndStage()
    {
        isEndStage = true;
        GameMGR.Instance.uiMGR.StageClearUI();

    }
    public void ReStart()
    {
        isEndStage = false;
        percentText.text = 0 + "%";
        percentIMG.fillAmount = 0;

    }

    
}
