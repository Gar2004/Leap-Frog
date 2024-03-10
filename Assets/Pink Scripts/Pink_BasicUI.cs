using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink_BasicUI : MonoBehaviour
{
    void OnGUI()
    {
        int posX = 10;
        int posY = 10;
        int width = 100;
        int height = 30;
        int buffer = 10;

        List<string> itemList = Pink_Managers.Inventory.GetItemList();
        if (itemList.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No items");
        }
        foreach (string item in itemList)
        {
            int count = Pink_Managers.Inventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>($"Icons/{item}");
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent($"({count})", image));
            posX += width + buffer;
        }
    }
}

