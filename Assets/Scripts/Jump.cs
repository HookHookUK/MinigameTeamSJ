using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float jumpPower;
    [SerializeField] bool destory;
    private void Start()
    {
        GameMGR.Instance.pool.AddTalbe(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.SendMessage("Jump", jumpPower, SendMessageOptions.DontRequireReceiver);
            if(destory) GameMGR.Instance.pool.DestroyPrefab(gameObject);
            //Destroy(gameObject);
        }
    }
}
