using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIInventory : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> listIventory = new List<GameObject>();
    public RectTransform rectContent;

    public void InitInventory()
    {
        List<string> Inventory = GameManager.GetInstance().Inventory;

        GameObject prefabsImage = Resources.Load("GUI/MonsterImage") as GameObject;

        foreach(string name in Inventory)
        {
            GameObject monsterImage =  Instantiate(prefabsImage, rectContent);
            GUIMonsterImage guiMonsterImage = monsterImage.GetComponent<GUIMonsterImage>();
            guiMonsterImage.SetImage(name);
            listIventory.Add(monsterImage);
        }

        GridLayoutGroup gridLayout = rectContent.GetComponent<GridLayoutGroup>();
        Vector2 vContentSize = rectContent.sizeDelta; //200,200
        Vector2 vGridSize = gridLayout.cellSize; //600,300
        int nRayoutCount = (int)(rectContent.sizeDelta.x / vGridSize.x);//600/200 = 3
        int nLine = Inventory.Count / nRayoutCount; // 4/3 = 1
        if (Inventory.Count % nRayoutCount > 0) //4/3 = 1
            nLine++;
        vContentSize.y = vGridSize.y * nLine; 
        rectContent.sizeDelta = vContentSize;
    }

    public void ClearInventory()
    {
        for (int i = 0; i < listIventory.Count; i++)
            Destroy(listIventory[i]);
        listIventory.Clear();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
