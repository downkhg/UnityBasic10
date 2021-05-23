using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responner : MonoBehaviour
{
    public GameObject objPlayer;
    public string strPrefabName;
    public float Time;
    public bool isReady = false;

    // Update is called once per frame
    void Update()
    {
        if(objPlayer == null && isReady == false)
        {
            StartCoroutine(ProcessResponTimmer());
        }
    }

    void ResponObject()
    {
        GameObject prefabPlayer = 
            Resources.Load("Prefabs/" + strPrefabName) as GameObject;
        objPlayer = Instantiate(prefabPlayer);
        objPlayer.transform.position = this.transform.position;
    }

    IEnumerator ProcessResponTimmer()
    {
        Debug.Log("ProcessResponTimmer 1");
        isReady = true;
        yield return new WaitForSeconds(Time);
        ResponObject();
        isReady = false;
        Debug.Log("ProcessResponTimmer 2");
    }
}
