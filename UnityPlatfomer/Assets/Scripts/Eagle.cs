using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public float Speed;
    public GameObject objTarget;
    public float Site = 0.5f;
    
    public GameObject objResponPoint;
    public GameObject objPatrolPoint;

    public bool isMove = false;

    public enum E_AI_STATE { ATTACK, RETURN, PATROL }
    public E_AI_STATE curAIState;

    public void SetAIState(E_AI_STATE state)
    {
        switch(state)
        {
            case E_AI_STATE.ATTACK:

                break;
            case E_AI_STATE.RETURN:
                objTarget = objResponPoint;
                break;
            case E_AI_STATE.PATROL:

                break;
        }
        curAIState = state;
    }

    public void UpdateAIState()
    {
        switch (curAIState)
        {
            case E_AI_STATE.ATTACK:
                if (objTarget == null) SetAIState(E_AI_STATE.RETURN);
                break;
            case E_AI_STATE.RETURN:
                if (isMove == false) SetAIState(E_AI_STATE.PATROL); 
                break;
            case E_AI_STATE.PATROL:
                ProcessPatrol(objResponPoint, objPatrolPoint);
                break;
        }
    }

    public void ProcessPatrol(GameObject objTargetA, GameObject objTargetB)
    {
        if (objTarget != null)
        {
            if (isMove == false)
            {
                if (objTarget.name == objTargetA.name)
                {
                    objTarget = objTargetB;
                }
                else if (objTarget.name == objTargetB.name)
                {
                    objTarget = objTargetA;
                }
            }
        }
    }

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
        if (ProcessFindTargetLayer("Player"))
            SetAIState(E_AI_STATE.ATTACK);
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
        UpdateAIState();
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
    }
}
