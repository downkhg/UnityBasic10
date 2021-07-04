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

    public void LaserShot(Player player, Vector3 dir, float dist)
    {
        

        Vector3 vPos = this.transform.position;

        RaycastHit2D raycastHit = 
            Physics2D.Raycast(vPos, dir, dist, 1<<LayerMask.NameToLayer("Monster"));

        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, vPos);

        if (raycastHit.collider)
        {
            lineRenderer.endColor = Color.red;
            lineRenderer.SetPosition(1, raycastHit.point);

            Debug.DrawLine(vPos, raycastHit.point, Color.green);
            Player monster = raycastHit.collider.gameObject.GetComponent<Player>();

            SuperMode superMode = monster.GetComponent<SuperMode>();
            if (superMode && !superMode.isUse)
            {
                player.Attack(monster);
                superMode.Active();
            }
        }
        else
        {
            lineRenderer.endColor = Color.green;
            
            lineRenderer.SetPosition(1, vPos + dir * dist);
            Debug.DrawLine(vPos, vPos + dir * dist, Color.red);
        }
    }
}
