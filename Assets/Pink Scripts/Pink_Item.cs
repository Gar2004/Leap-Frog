using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink_Item : MonoBehaviour
{
    [SerializeField] string itemName;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pink"))
        {
            Pink_Managers.Inventory.AddItem(itemName);
            Destroy(this.gameObject);
        }
        //Debug.Log($"Item collected: {itemName}");

    }
}
