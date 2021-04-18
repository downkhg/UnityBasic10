using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    public float Speed;
    public float JumpPower = 100;
    public bool isJump = false;

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
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(Vector3.up * JumpPower);

                isJump = true;
            }
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 20), "isJump:" + isJump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false;
        Debug.Log("OnCollisionEnter2D:"+collision.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //isJump = true; //다른블럭에서 이동했을때도 이 경우에 해당이 된다.
        Debug.Log("OnCollisionExit2D:" + collision.gameObject.name);
    }
}
