using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject objTarget;

    // Update is called once per frame
    void Update()
    {
        if (objTarget)
        {
            this.transform.position = objTarget.transform.position;
        }
    }
}
