using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Hp = 100;
    public int Atk =  10;
    public int Exp = 0;
    public int Lv = 1;
    public void Attack(Player target)
    {
        target.Hp -= this.Atk;
    }
    public bool Death()
    {
        if (Hp > 0)
            return false;
        else
            return true;
    }
    public void CheckLvUp()
    {
        if(Exp >= 100)
        {
            Lv++;
            Hp += 10;
            Atk += 5;
        }
    }
    public int idxDebugGUI;
    private void OnGUI()
    {
        int nWidth = 100;
        int nHight = 20;
        int nOrder = 0;
        GUI.Box(new Rect(idxDebugGUI * nWidth, nOrder * nHight, nWidth, nHight),"Name:" + gameObject.name); 
        nOrder++;
        GUI.Box(new Rect(idxDebugGUI * nWidth, nOrder * nHight, nWidth, nHight),"HP:" + Hp); 
        nOrder++;
        GUI.Box(new Rect(idxDebugGUI * nWidth, nOrder * nHight, nWidth, nHight),"STR:" + Atk); 
        nOrder++;
        GUI.Box(new Rect(idxDebugGUI * nWidth, nOrder * nHight, nWidth, nHight),string.Format("Lv/Exp:{0}/{1}", Lv, Exp)); 
        nOrder++;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
