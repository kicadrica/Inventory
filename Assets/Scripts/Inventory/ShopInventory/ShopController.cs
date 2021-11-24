using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public InventorySO Inventory;
    
    [SerializeField] private Button SellButton;
    [SerializeField] private InventoryCell ShopCell;
    [SerializeField] private Text ItemPriceText;
    
    private int _totalSellPrice;
    private void Start()
    {
        SellButton.onClick.AddListener(SellItem);
        ShopCell.ItemHolder = new InventorySO.InventoryItemsHolder();
        ShopCell.ItemHolder.OnHolderChange += UpdateShopInfo;
        ShopCell.Init();
    }
    
    private void OnDestroy()
    {
        ShopCell.ItemHolder.OnHolderChange -= UpdateShopInfo;
    }

    private void SellItem()
    {
        if (ShopCell.ItemHolder.Item == null) return;
        Inventory.Coins += _totalSellPrice;
        
        ShopCell.ItemHolder.Item = null;
        ShopCell.Hide();
        ItemPriceText.text = "0";
    }
    
    private void UpdateShopInfo()
    {
        if (ShopCell.ItemHolder.Item != null) {
            var itemPrice = ShopCell.ItemHolder.Item.Info.ItemPrice;
            var itemCount =  ShopCell.ItemHolder.Item.Count;
            _totalSellPrice = itemPrice * itemCount;
            ItemPriceText.text = _totalSellPrice.ToString();
        } else {
            _totalSellPrice = 0;
            ItemPriceText.text = _totalSellPrice.ToString();
        }
    }
}
