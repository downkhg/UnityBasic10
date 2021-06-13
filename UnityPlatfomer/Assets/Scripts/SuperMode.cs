using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMode : MonoBehaviour
{
    public float Time = 1;
    public bool isUse = false;

    IEnumerator Timmer()
    {
        isUse = true;
        yield return new WaitForSeconds(Time);
        GetComponent<SpriteRenderer>().color = Color.white;
        isUse = false;
    }

    public void Active()
    {
        StartCoroutine(Timmer());
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isUse) Active();
    }

    // Update is called once per frame
    void Update()
    {
        if(isUse)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            if (color.a == 1) color.a = 0;
            else color.a = 1;
            spriteRenderer.color = color;
        }
    }
}
