using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Pink_InventoryManager : MonoBehaviour, Pink_IGameManager
{
    public Pink_ManagerStatus status { get; private set; }
    private Dictionary<string, int> items;
    public void Startup()
    {
        Debug.Log("Pink Inventory manager starting...");

        items = new Dictionary<string, int>();

        status = Pink_ManagerStatus.Started;
    }

    private void DisplayItems()
    {
        string itemDisplay = "Pink's Items: ";
        foreach (KeyValuePair<string, int> item in items)
        {
            itemDisplay += item.Key + "(" + item.Value + ") ";
        }
        Debug.Log(itemDisplay);
    }

    public void AddItem(string name)
    {
        if (items.ContainsKey(name))
        {
            items[name] += 1;
        }
        else
        {
            items[name] = 1;
        }
        DisplayItems();
    }

    public List<string> GetItemList()
    {
        List<string> list = new List<string>(items.Keys);
        return list;
    }

    public int GetItemCount(string name)
    {
        if (items.ContainsKey(name))
        {
            return items[name];
        }
        return 0;
    }
}
