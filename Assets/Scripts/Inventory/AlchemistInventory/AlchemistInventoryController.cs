using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlchemistInventoryController : MonoBehaviour
{
    public InventorySO Inventory;
    
    [SerializeField] private InventoryCell FirstCell;
    [SerializeField] private InventoryCell SecondCell;
    [SerializeField] private Text PriceText;
    [SerializeField] private Text NoticeText;
    [SerializeField] private Button MakeItemButton;

    private ItemsManager _itemsManager;
    private const int _priceForMakeItem = 2;
   
    private void OnEnable()
    {
        FirstCell.ItemHolder = new InventorySO.InventoryItemsHolder();
        SecondCell.ItemHolder = new InventorySO.InventoryItemsHolder();
        
        FirstCell.Init();
        SecondCell.Init();
        
        FirstCell.ItemHolder.OnHolderChange += UpdateAlchemistUIInfo;
        SecondCell.ItemHolder.OnHolderChange += UpdateAlchemistUIInfo;
        
        _itemsManager = ItemsManager.Instance;
        MakeItemButton.onClick.AddListener(MakeItem);
        
        UpdateAlchemistUIInfo();
    }

    private void OnDisable()
    {
        FirstCell.ItemHolder.OnHolderChange -= UpdateAlchemistUIInfo;
        SecondCell.ItemHolder.OnHolderChange -= UpdateAlchemistUIInfo;
    }

    private void MakeItem()
    {
        if (FirstCell.ItemHolder.Item == null || SecondCell.ItemHolder.Item == null) return;

            var potion = FindRecipe();
        if (potion == null) {
            Debug.Log("Recipe is not found");
            NoticeText.text = "Recipe is not found";
            return;
        }

        bool isAdded;
        if (Inventory.Coins >= _priceForMakeItem) {
            isAdded = Inventory.AddNewItem(potion);
        } else {
            Debug.Log("No money!");
            NoticeText.text = "You have no money";
            return;
        }
        
        if (isAdded) {
            FirstCell.ItemHolder.Item.Count--;
            SecondCell.ItemHolder.Item.Count--;
            Inventory.Coins -= _priceForMakeItem;
        } else {
            Debug.Log("Inventory is full");
            NoticeText.text = "Inventory is full";
            return;
        }
        
        if (FirstCell.ItemHolder.Item.Count < 1) {
            FirstCell.ItemHolder.Item = null;
        }
        if (SecondCell.ItemHolder.Item.Count < 1) {
            SecondCell.ItemHolder.Item = null;
        }
        
        FirstCell.ItemHolder.UpdateInfo();
        SecondCell.ItemHolder.UpdateInfo();
    }

    private PotionSO FindRecipe()
    {
        for (int i = 0; i < _itemsManager.RecipeList.Length; i++) {
            if ((FirstCell.ItemHolder.Item.Info.ItemID == _itemsManager.RecipeList[i].Mushroom1.ItemID &&
                 SecondCell.ItemHolder.Item.Info.ItemID == _itemsManager.RecipeList[i].Mushroom2.ItemID)
                ||
                (FirstCell.ItemHolder.Item.Info.ItemID == _itemsManager.RecipeList[i].Mushroom2.ItemID &&
                 SecondCell.ItemHolder.Item.Info.ItemID == _itemsManager.RecipeList[i].Mushroom1.ItemID)) {
                return _itemsManager.RecipeList[i].Potion;
            }
        }
        if (FirstCell.ItemHolder.Item.Info is MushroomSO && SecondCell.ItemHolder.Item.Info is MushroomSO) {
            return _itemsManager.TaintedPotion;
        }
        return null;
    }
    
    private void UpdateAlchemistUIInfo()
    {
        if (FirstCell.ItemHolder.Item != null && SecondCell.ItemHolder.Item != null) {
            PriceText.text = _priceForMakeItem.ToString();
        } else {
            PriceText.text = "0";
            NoticeText.text = "";
        }
    }
    
    
}
