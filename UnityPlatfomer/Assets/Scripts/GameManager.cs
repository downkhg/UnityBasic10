using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Responner responnerPlayer;
    public Responner responnerOpossum;
    public Responner responnerEagle;

    public CameraTracker cameraTracker;

    static GameManager instance;

    public static GameManager  GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    void ProcessCameraTrakerTarget()
    {
        if(cameraTracker.objTarget == null && responnerPlayer.objPlayer)
        {
            cameraTracker.objTarget = responnerPlayer.objPlayer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessCameraTrakerTarget();
        ResponEagleProcess();
        // ProcessPatrolEagle(responnerEagle.gameObject, responnerOpossum.gameObject);
    }

    void ResponEagleProcess()
    {
        if (responnerEagle.objPlayer)
        {
            Eagle eagle = responnerEagle.objPlayer.GetComponent<Eagle>();
            //eagle.ProcessPatrolEagle(responnerEagle.gameObject, responnerOpossum.gameObject);
            if(eagle.objResponPoint == null)
                eagle.objResponPoint = responnerEagle.gameObject;
            if (eagle.objPatrolPoint == null)
                eagle.objPatrolPoint = responnerOpossum.gameObject;
        }
    }
}
