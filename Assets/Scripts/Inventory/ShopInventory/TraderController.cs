using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderController : MonoBehaviour, IPushable
{
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private GameObject TraderInvUI;

    public void PushBy(GameObject actor)
    {
        InventoryUI.SetActive(true);
        TraderInvUI.SetActive(true);
    }
}
