using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Item : MonoBehaviour
{
    //[SerializeField] string itemName;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue"))
        {
            //Blue_Managers.Inventory.AddItem(itemName);
            Destroy(this.gameObject);
        }
        //Debug.Log($"Item collected: {itemName}");

    }

}
