using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Responner responnerPlayer;
    public Responner responnerOpossum;
    public Responner responnerEagle;

    public CameraTracker cameraTracker;

    void ProcessCameraTrakerTarget()
    {
        if(cameraTracker.objTarget == null && responnerPlayer.objPlayer)
        {
            cameraTracker.objTarget = responnerPlayer.objPlayer;
        }
    }

    void ProcessPatrolEagle(GameObject objTargetA, GameObject objTargetB)
    {
        if (responnerEagle.objPlayer)
        {
            Eagle eagle = responnerEagle.objPlayer.GetComponent<Eagle>();

            if (eagle.objTarget != null)
            {
                if (eagle.isMove == false)
                {
                    if (eagle.objTarget.name == objTargetA.name)
                    {
                        eagle.objTarget = objTargetB;
                    }
                    else if (eagle.objTarget.name == objTargetB.name)
                    {
                        eagle.objTarget = objTargetA;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessCameraTrakerTarget();
        ResponEagleProcess();
        ProcessPatrolEagle(responnerEagle.gameObject, responnerOpossum.gameObject);
    }

    void ResponEagleProcess()
    {
        if (responnerEagle.objPlayer)
        {
            Eagle eagle = responnerEagle.objPlayer.GetComponent<Eagle>();
            if(eagle.objResponPoint == null)
                eagle.objResponPoint = responnerEagle.gameObject;
        }
    }
}
