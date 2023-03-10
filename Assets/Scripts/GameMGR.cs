using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMGR : Singleton<GameMGR>
{
    //public AudioSource myAudioSource;
    public AudioMGR audioMGR;

    public UIManager uiMGR;
    public ObjectPool pool;
    public FollowCam followCam;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject[] stageOBJ;
    public ProgressBar progressBar;
    GameObject player;
    Jump[] jumps;
    private void Awake()
    {
        jumps = FindObjectsOfType<Jump>();
        Application.targetFrameRate = 120;
        pool = GetComponent<ObjectPool>();
        followCam = FindObjectOfType<FollowCam>();
        uiMGR = FindObjectOfType<UIManager>();
        audioMGR = FindObjectOfType<AudioMGR>();
        //myAudioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioMGR.PlaySound(SoundList.Start);
    }

    public void GameStart(int stage)
    {
        progressBar.ReStart();
        if (stage == 1)
        {
            progressBar.arrive = 140;
            audioMGR.PlaySound(SoundList.BGM1);
            for (int i = 0; i < stageOBJ.Length; i++)
            {
                if (i != stage - 1) stageOBJ[i].SetActive(false);
                else stageOBJ[i].SetActive(true);
            }
        }
        else if (stage == 2)
        {
            progressBar.arrive = 170;
            audioMGR.PlaySound(SoundList.BGM2);
            for (int i = 0; i < stageOBJ.Length; i++)
            {
                if (i != stage - 1) stageOBJ[i].SetActive(false);
                else stageOBJ[i].SetActive(true);
            }
        }
        StartCoroutine(GameStart_Delay(stage));
    }
    IEnumerator GameStart_Delay(int stage)
    {
        foreach (Jump a in jumps) a.GameRespwan();
        followCam.SetPos(null);
        if (stage == 1)
        {
            followCam.gameObject.transform.position = new Vector3(5, 4, -1);
            player = pool.CreatePrefab(playerPrefab, new Vector2(-5f, 4f), Quaternion.identity);
            player.transform.position = new Vector2(-5f, 4f);
        }
        else if(stage==2)
        {
            followCam.gameObject.transform.position = new Vector3(5, -6.5f, -1);
            player = pool.CreatePrefab(playerPrefab, new Vector2(-5f, -10f), Quaternion.identity);
            player.transform.position = new Vector2(-5f, -10f);
        }
        yield return new WaitForSeconds(1f);
        followCam.SetPos(player);
        progressBar.playerPos = player.transform;
        yield break;
    }

    public void GameEnd()
    {
        Application.Quit();
    }

    public void RemovePlayer()
    {
        audioMGR.PlaySound(SoundList.BGM1);
        player.transform.position = Vector3.zero;
        if (player.activeSelf) pool.DestroyPrefab(player);
    }

    public void Resume()
    {

    }


}
