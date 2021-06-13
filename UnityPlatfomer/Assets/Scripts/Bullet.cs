using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Dist;
    public Vector3 vStartPos;
    public Player master;

    private void Start()
    {
        //시작할때 총알의 위치를 저장한다.
        vStartPos = this.transform.position;
        //AddForce를 이용하면 언제 거리가 정확하게 가는지 측정하기 어려우므로,
        //사거리를 정확하게 측정할수 없다.(물론 역산가능하면됨)
        //Destroy(this.gameObject, 1);
    }

    private void Update()
    {
        //현재위치에서 시작위치를 빼고,스칼라를 이용하여 거리를 구한다. 
        Vector3 vPos = this.transform.position;
        Vector3 vDist = vPos - vStartPos;

        if(vDist.magnitude >= Dist )
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet.OnCollisionEnter2D:" + collision.gameObject.name);
        if(collision.gameObject.tag == "Monster")
        {
            //Destroy(collision.gameObject.gameObject);
            Player monster = collision.gameObject.GetComponent<Player>();

            SuperMode superMode = monster.GetComponent<SuperMode>();
            if (superMode && !superMode.isUse)
            {
                master.Attack(monster);
                superMode.Active();
            }
        }
        
        if (collision.gameObject.tag != "Player" && 
            collision.gameObject.tag != "Ladder")
        {
            Destroy(this.gameObject);
        }
    }
}
