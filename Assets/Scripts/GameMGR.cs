using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMGR : Singleton<GameMGR>
{
    public ObjectPool pool;
    public FollowCam followCam;
    [SerializeField] GameObject playerPrefab;
    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
        followCam= FindObjectOfType<FollowCam>();
    }
    
    public void GameStart()
    {
        StartCoroutine(GameStart_Delay());
    }
    IEnumerator GameStart_Delay()
    {
        followCam.gameObject.transform.position= new Vector3(5,4,-1);
        GameObject obj= pool.CreatePrefab(playerPrefab, new Vector2(-5f, 1f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        followCam.SetPos(obj);
        yield break;


    }

    public void GameEnd()
    {

    }
}
