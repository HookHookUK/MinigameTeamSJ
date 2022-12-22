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
    [SerializeField] ProgressBar progressBar;
    GameObject player;
    private void Awake()
    {
        Application.targetFrameRate = 60;
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

    public void GameStart()
    {
        
        StartCoroutine(GameStart_Delay());
    }
    IEnumerator GameStart_Delay()
    {
        audioMGR.PlaySound(SoundList.BGM1);
        followCam.gameObject.transform.position = new Vector3(5, 4, -1);
        player = pool.CreatePrefab(playerPrefab, new Vector2(-5f, 1f), Quaternion.identity);
        player.transform.position = new Vector2(-5f, 1f);
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
        if (player.activeSelf) pool.DestroyPrefab(player);
    }

    public void Resume()
    {

    }


}
