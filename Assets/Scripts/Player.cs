using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject trail;
    Vector3 trailPos = new Vector3(-0.8f, -0.4f);


    Rigidbody2D rb;
    bool isDead = false;
    [SerializeField] bool isJump = false;

    [SerializeField] float speed;
    [SerializeField] float rotSpeed;
    [SerializeField] float jumpPower;

    [SerializeField] GameObject myImage;
    [SerializeField] int rotDir;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(CO_MoveRight());
        StartCoroutine(CO_TrailAdd());
    }

    IEnumerator CO_MoveRight()
    {
        while(!isDead)
        {
            rb.transform.Translate(Vector3.right * speed * Time.deltaTime);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }    

    IEnumerator CO_TrailAdd()
    {
        while(!isDead)
        {
            yield return new WaitForSecondsRealtime(0.15f);
            GameMGR.Instance.pool.CreatePrefab(trail, transform.position + trailPos, Quaternion.identity);
        }
    }

    IEnumerator CO_PlayerRotate()
    {
        if (rotDir == -360) rotDir = 0;
        rotDir -= 90;
        float rot = 0;
        while(rot > -90f)
        {
            myImage.transform.Rotate(0, 0, -1f * rotSpeed * Time.deltaTime);
            rot -= rotSpeed * Time.deltaTime;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        myImage.transform.rotation = Quaternion.Euler(0,0, rotDir);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump) return;

            rb.AddForce(Vector2.up * jumpPower);
            StartCoroutine(CO_PlayerRotate());


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            isJump = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            isJump = true;
        }
    }
}
