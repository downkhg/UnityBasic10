using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MonsterInfo
{
    public string name;
    public string coment;
    public string image;

    public MonsterInfo(string name, string coment, string image)
    {
        this.name = name;
        this.coment = coment;
        this.image = image;
    }
}

public class GameManager : MonoBehaviour
{
    public Responner responnerPlayer;
    public Responner responnerOpossum;
    public Responner responnerEagle;

    public CameraTracker cameraTracker;

    public List<string> Inventory;

    public void SetInventory(string name)
    {
        Inventory.Add(name);
    }

    public string GetInventory(int idx)
    {
        return Inventory[idx];
    }

    public string GetInventory(string name)
    {
        return Inventory.Find(item => item.Equals(name));
    }

    public void OnGUI()
    {
        for (int i = 0; i < Inventory.Count; i++)
            GUI.Box(new Rect(0, 0 + (20 * i), 100, 20), Inventory[i]);
    }

    static GameManager instance;

    public static GameManager  GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public GUIStatusBar guiHPBar;
    public GUIStatusBar guiMPBar;
    public GUIStatusBar guiExpBar;
    public Text textPlayerName;
    public Text textPlayerLv;

    public Image imgLastTarget;
    public GameObject lastTarget;

    public Dictionary<string, MonsterInfo> monsterInfos = new Dictionary<string, MonsterInfo>();
    
    public GUIInventory guiInventory;
    public GUIContentInfo guiContentInfo;
    public GameObject popupLayer;

    private void Start()
    {
        monsterInfos.Add("eagle", new MonsterInfo("독수리", "날아다닌다", "eagle"));
        monsterInfos.Add("opossum", new MonsterInfo("주머니쥐", "기어다닌다", "opossum"));

        guiHPBar.InitBarSize();
        SetGUIStatus(curGUIStatus);
    }

    void UpdatePlayerStatus()
    {
        if (responnerPlayer.objPlayer)
        {
            Player player = responnerPlayer.objPlayer.GetComponent<Player>();

            textPlayerName.text = responnerPlayer.gameObject.name;
            textPlayerLv.text = string.Format("Lv.{0}",player.Lv);
            guiHPBar.SetStatus(player.Hp, player.MaxHp);
        }
    }

    public void EventChangeSenes(int idx)
    {
        SetGUIStatus((E_GUI_STATUS)idx);
    }

    public void EventExit()
    {
        Application.Quit();
    }

    public List<GameObject> listGUIScences;

    void ShowGUIScenes(E_GUI_STATUS state)
    {
        for(int i = 0; i < listGUIScences.Count; i++)
        {
            if ( i == (int)state)
                listGUIScences[i].SetActive(true);
            else
                listGUIScences[i].SetActive(false);
        }
    }
    public enum E_GUI_STATUS { TITLE, THEEND, GAMEOVER, PLAY }
    public E_GUI_STATUS curGUIStatus;

    public void SetGUIStatus(E_GUI_STATUS state)
    {
        Time.timeScale = 0;
        switch(state)
        {
            case E_GUI_STATUS.TITLE:
                break;
            case E_GUI_STATUS.THEEND:
                break;
            case E_GUI_STATUS.GAMEOVER:
                imgLastTarget.sprite = lastTarget.GetComponent<SpriteRenderer>().sprite;
                break;
            case E_GUI_STATUS.PLAY:


                Time.timeScale = 1;
                break;
        }
        ShowGUIScenes(state);
        curGUIStatus = state;
    }

    public void UpdateStatus()
    {
        switch (curGUIStatus)
        {
            case E_GUI_STATUS.TITLE:
                break;
            case E_GUI_STATUS.THEEND:
                break;
            case E_GUI_STATUS.GAMEOVER:
                break;
            case E_GUI_STATUS.PLAY:
                if (Input.GetKeyDown(KeyCode.I))
                {
                    if (popupLayer.activeSelf == false)
                    {
                        guiInventory.InitInventory();
                        popupLayer.SetActive(true);
                    }
                    else
                    {
                        popupLayer.SetActive(false);
                        guiInventory.ClearInventory();
                    }
                }

                break;
        }
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
        UpdateStatus();
        UpdatePlayerStatus();
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
