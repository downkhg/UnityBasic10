using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject objBullet;
    public float ShotPower;

    public void Shot()
    {
        //총알을 오른쪽으로 발사
        //같은 총알에 힘을준다 -> 공
        //서로 다른 에 힘을 준다.
        //총알:게임오브젝트을 생성한다.
        GameObject copyBullet = Instantiate(objBullet);
        Rigidbody2D rigidbody = copyBullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Vector3.right * ShotPower);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            Shot();
    }
}
