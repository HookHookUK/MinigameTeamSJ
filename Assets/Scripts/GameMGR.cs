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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
