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

    // Update is called once per frame
    void Update()
    {
        ProcessCameraTrakerTarget();
        ResponEangleProcess();
    }

    void ResponEangleProcess()
    {
        if (responnerEagle.objPlayer)
        {
            Eagle eagle = responnerEagle.objPlayer.GetComponent<Eagle>();

            eagle.objResponPoint = responnerEagle.gameObject;
        }
    }
}
