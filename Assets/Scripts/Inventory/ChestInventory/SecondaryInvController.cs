using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryInvController : MonoBehaviour, IPushable
{
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private GameObject SecondaryInvUI;
    [SerializeField] InventorySO SecInventory;
    public void PushBy(GameObject actor)
    {
        InventoryUI.SetActive(true);
        SecondaryInvUI.GetComponentInChildren<InventoryUI>()._inventory = SecInventory;
        SecondaryInvUI.SetActive(true);
    }
}
