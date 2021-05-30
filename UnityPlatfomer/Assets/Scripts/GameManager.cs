using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Responner responnerPlayer;
    public Responner responnerOpossum;
    public Responner responnerEagle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
