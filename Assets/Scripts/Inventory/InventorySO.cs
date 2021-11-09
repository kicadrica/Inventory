using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Managers/Inventory")]
public class InventorySO : ScriptableObject
{
     public class InventoryItem
     {
         public ItemSO Info;
         public int Count; 
         public InventoryItemsHolder Holder;
    }

    public class InventoryItemsHolder
    {
        public event Action OnHolderChange;

        private InventoryItem _item;
        public InventoryItem Item {
            get => _item;
            set {
                _item = value;
                if(_item != null)
                    _item.Holder = this;
                OnHolderChange?.Invoke();
            }
        }
        public void UpdateInfo()
        {
            OnHolderChange?.Invoke();
        }
    }
    
    public string SavePrefix;
    public InventoryItemsHolder[] ItemList;

    public int InventorySize = 15;
    public int MaxItemsInCell = 20;
    
    public event Action<int> OnMoneyChange;
    public int Coins {
        get {
            return PlayerPrefs.GetInt("Money"); 
        }
        set {
            PlayerPrefs.SetInt("Money", value);
            OnMoneyChange?.Invoke(Coins);
        }
    }

    private void OnValidate()
    {
        ItemList = new InventoryItemsHolder[InventorySize];
        for (int i = 0; i < ItemList.Length; i++) {
            ItemList[i] = new InventoryItemsHolder();
            ItemList[i].OnHolderChange += SaveInventory;
        }
        LoadInventory();
    }

    public bool AddNewItem(ItemSO item)
    {
        for (int i = 0; i < ItemList.Length; i++) {
            if (ItemList[i].Item != null && ItemList[i].Item.Info.ItemID == item.ItemID && ItemList[i].Item.Count < MaxItemsInCell) {
                ItemList[i].Item.Count += 1;
                ItemList[i].UpdateInfo();
                return true;
            }
        }
        
        for (int i = 0; i < ItemList.Length; i++) {
            if (ItemList[i].Item == null) {
                ItemList[i].Item = new InventoryItem() {Info = item, Count = 1};
                return true;
            }
        }
        return false;
    }

    [Serializable]
    private class SaveData
    {
        [Serializable]
        public class SaveItemInfo
        {
            public string ID;
            public int Count;
        }

        public List<SaveItemInfo> Items = new List<SaveItemInfo>();
    }

    private void SaveInventory()
    {
        SaveData saveData = new SaveData();

        foreach (var holder in ItemList) {
            if (holder.Item == null) {
                saveData.Items.Add(null);
            } else {
                saveData.Items.Add(new SaveData.SaveItemInfo(){ID = holder.Item.Info.ItemID, Count = holder.Item.Count});
            }
        }
        
        PlayerPrefs.SetString(SavePrefix+"Inventory", JsonUtility.ToJson(saveData));
    }

    private void LoadInventory()
    {
        if (!PlayerPrefs.HasKey(SavePrefix+"Inventory")) return;
        
        var saveDataString = PlayerPrefs.GetString(SavePrefix+"Inventory");
        if (string.IsNullOrEmpty(saveDataString)) return;
        
        var saveData = JsonUtility.FromJson<SaveData>(saveDataString);
        if (saveData == null || saveData.Items == null) return;
        
        for (var i = 0; i < saveData.Items.Count || i < InventorySize; i++) {
            var savedItem = saveData.Items[i];
            if (string.IsNullOrEmpty(savedItem.ID)) {
                ItemList[i].Item = null;
            } else {
                var itemInfo = FindItemWithID(savedItem.ID);
                if (itemInfo == null) {
                    ItemList[i].Item = null;
                } else {
                    ItemList[i].Item = new InventoryItem() {Info = itemInfo, Count = savedItem.Count};
                }
            }
        }
    }

    private ItemSO FindItemWithID(string id)
    {
        foreach (var mushroom in ItemsManager.Instance.MushroomList) {
            if (mushroom.ItemID == id) 
                return mushroom;
        }
        return null;
    }
}
