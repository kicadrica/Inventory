using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsPool : MonoBehaviour
{
    public static CellsPool Instance;
    
    [SerializeField] private InventoryCell CellPrefab;
    
    private static Queue<InventoryCell> DisabledCells = new Queue<InventoryCell>();
    private int _cellCount = 30;
    
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        for (int i = 0; i < _cellCount; i++) {
            CreateNewCell();
        }
    }

    private InventoryCell CreateNewCell()
    {
        var cell = Instantiate(CellPrefab, transform);
        cell.gameObject.SetActive(false);
        return cell;
    }

    public InventoryCell GetCell(Transform parent)
    {
        InventoryCell cell = null;
        if (DisabledCells.Count > 0) {
            cell = DisabledCells.Dequeue();
        } else {
            cell = CreateNewCell();
        }
        cell.transform.SetParent(parent);
        cell.gameObject.SetActive(true);
        cell.transform.localScale = Vector3.one;
        return cell;
    }

    public void PutCell(InventoryCell cell)
    {
        cell.gameObject.SetActive(false);
        DisabledCells.Enqueue(cell);
    }
}
