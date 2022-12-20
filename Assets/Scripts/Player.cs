using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(CO_MoveRight());
    }

    IEnumerator CO_MoveRight()
    {
        rb.transform.Translate(Vector3.right * Time.deltaTime);
        yield return new WaitForSecondsRealtime(0.01f);
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
