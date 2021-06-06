using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public float Speed;
    public GameObject objTarget;
    public float Site = 0.5f;
    
    public GameObject objResponPoint;

    public bool isMove = false;

    bool ProcessTargetTraker()
    {
        if (objTarget != null)
        {
            Vector3 vPos = this.transform.position;
            Vector3 vTargetPos = objTarget.transform.position;
            Vector3 vDist = vTargetPos - vPos;
            Vector3 vDir = vDist.normalized;//방향
            float fDist = vDist.magnitude; //거리

            if (fDist > Time.deltaTime)//독수리가 일정거리까지 가기전까지만 
            {
                transform.position += vDir * Speed * Time.deltaTime; //이동
                isMove = true;
                return true;
            }
        }
        isMove = false;
        return false;
    }

    private void FixedUpdate()
    {
        ProcessFindTargetLayer("Player");
        //ProcessFindTarget("Player");
    }
    bool ProcessFindTargetLayer(string layername)
    {
        int nLayer = 1 << LayerMask.NameToLayer(layername);
        Collider2D colider =
            Physics2D.OverlapCircle(transform.position, Site, nLayer);

        if (colider)
        {
            objTarget = colider.gameObject;
            return true;
        }

        return false;
    }
    bool ProcessFindTarget(string tagname)
    {
        Collider2D[] coliders =
            Physics2D.OverlapCircleAll(transform.position, Site);
        Debug.Log("ColLength:"+ coliders.Length);
        for (int i = 0; i < coliders.Length; i++)
        {
            Collider2D collider = coliders[i];
            if (collider && collider.tag == tagname)
            {
                objTarget = collider.gameObject;
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, Site);//시야확인용
    }

    // Update is called once per frame
    void Update()
    {
        if (objTarget == null) objTarget = objResponPoint;
        ProcessTargetTraker();
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.tag == "Player")
        //    objTarget = collision.gameObject;

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
