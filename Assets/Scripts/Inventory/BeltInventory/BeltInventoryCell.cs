using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeltInventoryCell : BaseCell
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(UseItem);
    }
    
    private void UseItem()
    {
        if (ItemHolder.Item == null) return;
        if (ItemHolder.Item.Count > 1) {
            ItemHolder.Item.Count--;
            ItemHolder.UpdateInfo();
        } else {
            ItemHolder.Item = null;
        }
    }
}
