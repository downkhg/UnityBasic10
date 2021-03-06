using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Hp = 100;
    public int MaxHp; 
    public int Atk =  10;
    public int Exp = 0;
    public int Lv = 1;
    public void Attack(Player target)
    {
        target.Hp -= this.Atk;
        if (target.Death())
        {
            StillExp(target);
            GameManager.GetInstance().SetInventory(target.gameObject.name);
        }
    }
    public bool Death()
    {
        if (Hp > 0)
            return false;
        else
            return true;
    }
    public int GetExp()
    {
        return Exp + Lv * 100;
    }
    public void StillExp(Player target)
    {
        Exp += target.GetExp();
    }
    public void CheckLvUp()
    {
        if(Exp >= 100)
        {
            Lv++;
            Hp += 10;
            MaxHp += 10;
            Atk += 5;
            Exp -= 100;
        }
    }
    //public int idxDebugGUI;
    //private void OnGUI()
    //{
    //    int nWidth = 100;
    //    int nHight = 20;
    //    int nOrder = 0;
    //    GUI.Box(new Rect(idxDebugGUI * nWidth, nOrder * nHight, nWidth, nHight),"Name:" + gameObject.name); 
    //    nOrder++;
    //    GUI.Box(new Rect(idxDebugGUI * nWidth, nOrder * nHight, nWidth, nHight),"HP:" + Hp); 
    //    nOrder++;
    //    GUI.Box(new Rect(idxDebugGUI * nWidth, nOrder * nHight, nWidth, nHight),"STR:" + Atk); 
    //    nOrder++;
    //    GUI.Box(new Rect(idxDebugGUI * nWidth, nOrder * nHight, nWidth, nHight),string.Format("Lv/Exp:{0}/{1}", Lv, Exp)); 
    //    nOrder++;
    //}
    public GUIStatusBar guiHPBar;

    public void UpdateHPBar()
    {
        if(guiHPBar) guiHPBar.SetStatus(Hp, MaxHp);
    }

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = Hp;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Death()) Destroy(this.gameObject);

        CheckLvUp();
        UpdateHPBar();
    }
}
