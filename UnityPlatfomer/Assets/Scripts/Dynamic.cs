using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += Vector3.right * Time.deltaTime;
        //왼쪽키이동하기
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += Vector3.left * Time.deltaTime;

        //if (Input.GetKeyUp(KeyCode.Space))
        //    transform.position += Vector3.right * Time.deltaTime;

        //transform.position += Vector3.right * Time.deltaTime;
    }
}
