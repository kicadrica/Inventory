using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMaker : MonoBehaviour, IPushable
{
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private GameObject MakeItemsInvUI;

    public void PushBy(GameObject actor)
    {
        InventoryUI.SetActive(true);
        MakeItemsInvUI.SetActive(true);
    }
}

