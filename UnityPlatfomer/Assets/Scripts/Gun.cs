using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject objBullet;
    public float ShotPower;
    
    public void Shot(Player player, Vector3 dir)
    {
        //총알을 오른쪽으로 발사
        //같은 총알에 힘을준다 -> 공
        //서로 다른 에 힘을 준다.
        //총알:게임오브젝트을 생성한다.
        GameObject copyBullet = Instantiate(objBullet);
        copyBullet.transform.position = this.transform.position;
        Rigidbody2D rigidbody = copyBullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(dir * ShotPower);
        Bullet bullet = copyBullet.GetComponent<Bullet>();
        bullet.master = player;
    }
}
