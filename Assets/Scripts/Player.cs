using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

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
    }

    IEnumerator CO_MoveRight()
    {
        while(!isDead)
        {
            rb.transform.Translate(Vector3.right * speed * Time.deltaTime);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        
    }    

    IEnumerator CO_PlayerRotate()
    {
        if (rotDir == 360) rotDir = 0;
        rotDir += 90;
        float rot = 0;
        while(rot < 90f)
        {
            myImage.transform.Rotate(0, 0, 1f * rotSpeed * Time.deltaTime);
            rot += rotSpeed * Time.deltaTime;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        //myImage.transform.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump) return;

            rb.AddForce(Vector2.up * jumpPower) ;
            StartCoroutine(CO_PlayerRotate());
            myImage.transform.localRotation = Quaternion.Euler(0,0,90f);

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
