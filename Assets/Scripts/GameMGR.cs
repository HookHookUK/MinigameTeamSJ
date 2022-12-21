using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMGR : Singleton<GameMGR>
{
    public ObjectPool pool;
    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
    }
    
    public void GameStart()
    {

    }

    public void GameEnd()
    {

    }
}
