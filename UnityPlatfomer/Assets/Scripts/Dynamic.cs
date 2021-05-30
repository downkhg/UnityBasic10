using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    public float Speed;
    public float JumpPower = 100;
    public bool isJump = false;
    public bool isLodder = false;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += Vector3.right * Speed * Time.deltaTime;
        //왼쪽키이동하기
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += Vector3.left * Speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump == false)
            {
                Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
                rigidbody.velocity = Vector2.zero;//현재강체의 가속도를 0으로 만든다.
                rigidbody.AddForce(Vector3.up * JumpPower);

                isJump = true;
            }
        }

        if(isLodder)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                transform.position += Vector3.up * Speed * Time.deltaTime;
            //왼쪽키이동하기
            if (Input.GetKey(KeyCode.DownArrow))
                transform.position += Vector3.down * Speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
            rigidbody.velocity = Vector2.zero;//현재강체의 가속도를 0으로 만든다.
            rigidbody.gravityScale = 0;
            isLodder = true;
        }
        //Debug.Log("OnTriggerEnter2D:" + collision.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLodder = false;
            Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
            rigidbody.gravityScale = 1;
        }
        //Debug.Log("OnTriggerExit2D:" + collision.gameObject.name);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 20), "isJump:" + isJump);
        GUI.Box(new Rect(0, 20, 100, 20), "Score:" + Score);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.name == "Tilemap")
        {
            isJump = false;
            Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
            rigidbody.gravityScale = 1;

            //Debug.Log("OnCollisionEnter2D:" + collision.gameObject.name);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //isJump = true; //다른블럭에서 이동했을때도 이 경우에 해당이 된다.
        //Debug.Log("OnCollisionExit2D:" + collision.gameObject.name);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //if (collision.gameObject.name == "cherry")
    //    if (collision.gameObject.tag == "Item")
    //    {
    //        Score++;
    //        Destroy(collision.gameObject);
    //    }
    //}
}
