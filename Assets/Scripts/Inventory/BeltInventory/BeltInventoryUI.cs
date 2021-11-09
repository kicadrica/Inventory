using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltInventoryUI : MonoBehaviour
{
    [SerializeField] private BeltInventoryCell BeltCellPrefab;
    public InventorySO _inventory;
    private int _maxCells = 4;
    public BeltInventoryCell[] BeltInvCells;
    private void Awake()
    {
        BeltInvCells = new BeltInventoryCell[_maxCells];
        for (int i = 0; i < BeltInvCells.Length; i++) {
            var cell = Instantiate(BeltCellPrefab, transform);
            BeltInvCells[i] = cell;
            BeltInvCells[i].ItemHolder = _inventory.ItemList[i];
            BeltInvCells[i].Init();
        }
    }
    

    
}
