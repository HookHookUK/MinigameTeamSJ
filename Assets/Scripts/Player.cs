using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject trail;
    Vector3 trailPos = new Vector3(-0.8f, -0.4f);


    Rigidbody2D rb;
    bool isYPos;
    bool isDead = false;
    float yPos;
    [SerializeField] bool isJump = false;

    [SerializeField] float speed;
    [SerializeField] float rotSpeed;
    [SerializeField] float jumpPower;

    [SerializeField] GameObject myImage;
    [SerializeField] int rotDir;

    Coroutine co_PlayerRotate;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(CO_TrailAdd());
        GameMGR.Instance.pool.AddTalbe(gameObject);
    }

    void Die()
    {
        GameMGR.Instance.pool.DestroyPrefab(gameObject);
    }
    IEnumerator CO_TrailAdd()
    {
        while(!isDead)
        {
            yield return new WaitForSecondsRealtime(0.15f);
            GameMGR.Instance.pool.CreatePrefab(trail, transform.position + trailPos, Quaternion.identity);
        }
    }

    IEnumerator CO_PlayerRotate(float value)
    {
        if (rotDir == -360) rotDir = 0;
        rotDir -= 90;
        float rot = 0;
        yield return new WaitForSeconds(0.1f);
        while(isJump)
        {
            myImage.transform.Rotate(0, 0, -1f * rotSpeed * Time.deltaTime);
            rot -= rotSpeed * Time.deltaTime;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        myImage.transform.rotation = Quaternion.Euler(0,0, rotDir);
    }

    // Update is called once per frame
    private void Update()
    {
  
        rb.transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.y > yPos && isYPos == true)
        {
            isYPos = false;
            rb.velocity = Vector2.zero;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump) return;
            Jump(2);
        }
    }

    public void Jump(float value)
    {
        isYPos = true;
        yPos = transform.position.y + value;
        rb.velocity= Vector2.up* jumpPower;
        if (co_PlayerRotate != null)
        {
            StopCoroutine(co_PlayerRotate);
        }
        co_PlayerRotate = StartCoroutine(CO_PlayerRotate(value));
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
