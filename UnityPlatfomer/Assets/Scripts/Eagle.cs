using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public float Speed;
    public GameObject objTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vPos = this.transform.position;
        Vector3 vTargetPos = objTarget.transform.position;
        Vector3 vDist = vTargetPos - vPos;
        Vector3 vDir = vDist.normalized;//방향
        float fDist = vDist.magnitude; //거리

        if(fDist > Time.deltaTime)//독수리가 일정거리까지 가기전까지만 
            transform.position += vDir * Speed * Time.deltaTime; //이동
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            objTarget = collision.gameObject;
    }
}
