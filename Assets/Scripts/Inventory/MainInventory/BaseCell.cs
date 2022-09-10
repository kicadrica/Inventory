using UnityEngine;
using UnityEngine.UI;

public class BaseCell : MonoBehaviour
{
    public InventorySO.InventoryItemsHolder ItemHolder;
    public Image ItemImageInCell;
    public Text CellText;
    
    public void Init()
    {
        UpdateCell();
        ItemHolder.OnHolderChange += UpdateCell;
    }

    private void OnDisable()
    {
        if (ItemHolder != null) ItemHolder.OnHolderChange -= UpdateCell;
    }

    public void Hide()
    {
        ItemImageInCell.enabled = false;
        CellText.text = "";
    }

    private void UpdateCell()
    {
        if (ItemHolder.Item != null) {
            ItemImageInCell.sprite = ItemHolder.Item.Info.ItemSprite;
            CellText.text = ItemHolder.Item.Count.ToString();
            ItemImageInCell.enabled = true;
        } else {
            Hide();
        }
    }
}
