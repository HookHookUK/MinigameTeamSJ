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
    }
    
    public void GameStart()
    {
        pool.CreatePrefab(playerPrefab,new Vector2(-5f,1f),Quaternion.identity);
    }

    public void GameEnd()
    {

    }
}
