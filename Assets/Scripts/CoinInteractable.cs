using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteractable : MonoBehaviour, ICollectable //Инплементация интерфейса ICollectable
{
    public void CollectBy(GameObject actor) 
    {
        Destroy(gameObject);
        actor.GetComponent<PlayerController>().PlayerInventory.Coins++;
    }
}
