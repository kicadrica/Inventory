using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventorySO _inventory;
    
    public InventoryCell[] CellsList = new InventoryCell[15]; //Число
    public Image MovingCell;
    [SerializeField] private InventoryCell CellPrefab;
    
    private InventorySO.InventoryItem _movingCell;

    private Camera _camera;
    private static InventoryUI _currentMouseHandler;
    
    private void Awake()
    {
        _camera = Camera.main;
        MovingCell.enabled = false;
        
        AddCellsList();
    }
    private void OnDisable()
    {
        _currentMouseHandler = null;
    }

    private void Update()
    {
        if (_currentMouseHandler == null) {
            _currentMouseHandler = this;
        }
        if (_currentMouseHandler != this) {
            return;
        }
        
        if (Input.GetMouseButtonDown(0)) {
            Interact();
        }
        if (Input.GetMouseButtonUp(0) && _movingCell != null) {
            Interact();
        }
        
        if (MovingCell.enabled != false) {
            Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            MovingCell.transform.position = mousePos;
        }
    }

    private void AddCellsList()
    {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        CellsList = new InventoryCell[_inventory.InventorySize];
        for (int i = 0; i < CellsList.Length; i++) {
            var cell = Instantiate(CellPrefab, transform);
            CellsList[i] = cell;
            CellsList[i].ItemHolder = _inventory.ItemList[i];
            CellsList[i].Init();
        }
    }

    private void SelectItem(InventoryCell currentCell)
    {
        if (_movingCell == null) {
            if (currentCell.ItemHolder.Item != null) {
                _movingCell = currentCell.ItemHolder.Item;
                MovingCell.sprite = _movingCell.Info.ItemSprite;
                MovingCell.enabled = true;
                currentCell.Hide();
            }
        } else {
            var oldHolder = _movingCell.Holder;
            var newHolder = currentCell.ItemHolder;
            if (newHolder.Item == null) {
                newHolder.Item = oldHolder.Item;
                oldHolder.Item = null;
            } else {
                if (newHolder.Item.Info.ItemID == oldHolder.Item.Info.ItemID 
                    && oldHolder.Item.Count < _inventory.MaxItemsInCell
                    && newHolder.Item.Count < _inventory.MaxItemsInCell) {
                    StackItems(oldHolder, newHolder);
                } else {
                    var tempItem = newHolder.Item;
                    newHolder.Item = oldHolder.Item;
                    oldHolder.Item = tempItem;
                }
            }
            
            _movingCell = null;
            MovingCell.sprite = null;
            MovingCell.enabled = false;
        }
    }
    private void StackItems(InventorySO.InventoryItemsHolder oldHolder, InventorySO.InventoryItemsHolder newHolder)
    {
        if (newHolder == oldHolder) {
            newHolder.UpdateInfo();
            return;
        }
        
        var count = newHolder.Item.Count + oldHolder.Item.Count;
        if (count <= _inventory.MaxItemsInCell) {
            newHolder.Item.Count = count;
            oldHolder.Item = null;
        } else {
            newHolder.Item.Count = _inventory.MaxItemsInCell;
            oldHolder.Item.Count = count - _inventory.MaxItemsInCell;
        }
        newHolder.UpdateInfo();
        oldHolder.UpdateInfo();
    }


    private void Interact()
    {
        var pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);
        if (raycastResults.Count == 0) {
            ReturnItemBack();
            return;
        }
        
        InventoryCell cellUnderPointer = null;
        foreach (var result in raycastResults) {
            cellUnderPointer = result.gameObject.GetComponent<InventoryCell>();
            if(cellUnderPointer != null) break;
        }

        if (cellUnderPointer == null) {
            ReturnItemBack();
            return;
        }

        SelectItem(cellUnderPointer);
    }

    private void ReturnItemBack()
    {
        if (_movingCell == null) return;
        _movingCell.Holder.Item = _movingCell;
        _movingCell = null;
        MovingCell.sprite = null;
        MovingCell.enabled = false;
    }
}
