using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour, ICollectable 
{
    public void CollectBy(GameObject actor) 
    {
        Destroy(gameObject);
        actor.GetComponent<PlayerController>().PlayerInventory.Coins++;
    }
}
