using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour, ICollectable
{
    [HideInInspector] public MushroomSO MushroomInfo;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        MushroomInfo = ItemsManager.Instance.MushroomList[Random.Range(0, ItemsManager.Instance.MushroomList.Length)];
        _spriteRenderer.sprite = MushroomInfo.ItemSprite;
    }


    public void CollectBy(GameObject collector)
    {
        bool isAdded = collector.GetComponent<PlayerController>().PlayerInventory.AddNewItem(MushroomInfo);
        if (isAdded) {
            Destroy(gameObject);
        } else {
            Debug.Log("Inventory is full");
        }
       
    }
}
