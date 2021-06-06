using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject objTarget;
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        if (objTarget != null)
        {
            Vector3 vPos = this.transform.position;
            Vector3 vTarget = objTarget.transform.position;
            vTarget.z = vPos.z;

            ProcessLerp(vPos, vTarget, Speed * Time.deltaTime);
            //ProcessTrackerTarget(vPos, vTarget);
            //ProcessMovePointSync();
        }
    }

    void ProcessMovePointSync()
    {
        this.transform.position = objTarget.transform.position;
        //}
    }

    void ProcessLerp(Vector3 vPos, Vector3 vTargetPos, float rat)
    {
        this.transform.position = Vector3.Lerp(vPos, vTargetPos, rat);
    }

    void ProcessTrackerTarget(Vector3 vPos, Vector3 vTargetPos)
    {
        Vector3 vDist = vTargetPos - vPos;
        Vector3 vDir = vDist.normalized;//방향
        float fDist = vDist.magnitude; //거리

        if (fDist > Time.deltaTime * Speed)//독수리가 일정거리까지 가기전까지만 
        {
            transform.position += vDir * Speed * Time.deltaTime; //이동
        }
    }
}
