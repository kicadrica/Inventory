using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellController : MonoBehaviour
{
    public InventorySO _inventory;
    
    [SerializeField] private Button SellButton;
    [SerializeField] private InventoryCell CellForSell;
    [SerializeField] private Text ItemPriceText;
    
    private int _totalSellPrice;
    private void Start()
    {
        SellButton.onClick.AddListener(SellItem);
        CellForSell.ItemHolder = new InventorySO.InventoryItemsHolder();
        CellForSell.ItemHolder.OnHolderChange += UpdateShopInfo;
        CellForSell.Init();
    }
    
    private void OnDestroy()
    {
        CellForSell.ItemHolder.OnHolderChange -= UpdateShopInfo;
    }

    private void SellItem()
    {
        if (CellForSell.ItemHolder.Item == null) return;
        _inventory.Coins += _totalSellPrice;
        
        CellForSell.ItemHolder.Item = null;
        CellForSell.Hide();
        ItemPriceText.text = "0";
    }
    
    private void UpdateShopInfo()
    {
        if (CellForSell.ItemHolder.Item != null) {
            var itemPrice = CellForSell.ItemHolder.Item.Info.ItemPrice;
            var itemCount =  CellForSell.ItemHolder.Item.Count;
            _totalSellPrice = itemPrice * itemCount;
            ItemPriceText.text = _totalSellPrice.ToString();
        } else {
            _totalSellPrice = 0;
            ItemPriceText.text = _totalSellPrice.ToString();
        }
    }
}
