using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject LobbyPanel;
    [SerializeField] public GameObject InGameScene;
    [SerializeField] GameObject soundOptionBox;
    [SerializeField] GameObject StageClearMenu;
    [SerializeField] GameObject StageClearMenuButton;
    [SerializeField] GameObject StageNone;

    public bool showMenu = false;
    bool showOption = false;
     public int curStage { get; private set; } = 1;

    public void OnClickStart()
    {
        GameMGR.Instance.GameStart(curStage);
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
        if(soundOptionBox.activeSelf==false)
            soundOptionBox.SetActive(true);
        else
            soundOptionBox.SetActive(false);
    }

    public void OnClickHome()
    {
        curStage = 1;
        Debug.Log("??1");
        if (StageClearMenuButton.activeSelf)
        {
            Debug.Log("??2");
            StageClearMenuButton.SetActive(false);
            if (StageClearMenu.activeSelf)
            {
                Debug.Log("??3");
                StageClearMenu.SetActive(false);
            }
        }
        Debug.Log("??4");
        GameMGR.Instance.RemovePlayer();
        GameMGR.Instance.audioMGR.PlaySound(SoundList.Start);
        LobbyPanel.SetActive(true);
        Time.timeScale = 1f;
        showMenu = false;
        InGameScene.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void OnClickRestart()
    {
        if (StageClearMenuButton.activeSelf)
        {
            StageClearMenuButton.SetActive(false);
            if (StageClearMenu.activeSelf)
            {
                StageClearMenu.SetActive(false);
            }
        }
        showMenu = false;
        InGameScene.transform.GetChild(1).gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameMGR.Instance.RemovePlayer();
        GameMGR.Instance.GameStart(curStage);
    }
    public void StageClearUI()
    {
        GameMGR.Instance.audioMGR.PlaySound(SoundList.Clear);
        StartCoroutine(StageClearUI_Delay());

    }
    IEnumerator StageClearUI_Delay()
    {
        FadeIn(StageClearMenu);
        yield return new WaitForSeconds(0.5f);
        FadeIn(StageClearMenuButton);
    }
    public void FadeIn(GameObject obj)
    {
        StartCoroutine(FadeIn_Delay(obj));
    }
    IEnumerator FadeIn_Delay(GameObject obj)
    {
        obj.SetActive(true);
        CanvasGroup Ap= obj.GetComponent<CanvasGroup>();
        Ap.alpha = 0;
        for (int i = 0; i<25; i++)
        {
            yield return new WaitForSeconds(0.01f);
            if(Ap.alpha<1)  Ap.alpha += 0.04f;
        }
        yield break;
    }
    public void FadeOut(GameObject obj)
    {
        StartCoroutine(FadeOut_Delay(obj));
    }
    IEnumerator FadeOut_Delay(GameObject obj)
    {
        CanvasGroup Ap = obj.GetComponent<CanvasGroup>();
        Ap.alpha = 1;
        for (int i = 0; i < 25; i++)
        {
            yield return new WaitForSeconds(0.01f);
            if (Ap.alpha > 0) Ap.alpha -= 0.04f;
            else if (Ap.alpha < 0) Ap.alpha = 0;
        }
        obj.SetActive(false);
        yield break;
    }
    public void OnClickNextStage()
    {
        if (curStage >= 2)
        {
            StageNones();
            return;
        }
        curStage++;
        OnClickRestart();

    }
    bool isNone;
    void StageNones()
    {
        if (isNone) return;
        StartCoroutine(StageNone_Delay());
    }
    IEnumerator StageNone_Delay()
    {
        isNone = true;
        FadeIn(StageNone);
        yield return new WaitForSeconds(1f);
        FadeOut(StageNone);
        yield return new WaitForSeconds(1f);

        isNone = false;
    }
}
