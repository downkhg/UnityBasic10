using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIStatusBar : MonoBehaviour
{
    public RectTransform recttrBar;
    public Vector2 vMaxBarSize;

    public void SetStatus(float cur, float max)
    {
        float rat = cur / max;
        Vector2 vSize = recttrBar.sizeDelta;
        vSize.x = vMaxBarSize.x * rat;//100 * 0.9 = 90//90*0.9 = 81
        recttrBar.sizeDelta = vSize;
    }

    public void InitBarSize()
    {
        vMaxBarSize = recttrBar.sizeDelta;
    }

    private void Awake()
    {
        InitBarSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
