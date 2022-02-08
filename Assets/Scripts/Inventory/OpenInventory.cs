using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject Inventory;

        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Inventory.gameObject.SetActive(!Inventory.gameObject.activeSelf);
        }
    }
}
