using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private InventorySO _inventory;
    private Text _moneyText;
    private void Start()
    {
        _inventory.OnMoneyChange += ChangeMoneyUI;
        _moneyText = GetComponent<Text>();
        ChangeMoneyUI(_inventory.Coins);
    }

    private void OnDestroy()
    {
        _inventory.OnMoneyChange -= ChangeMoneyUI;
    }

    private void ChangeMoneyUI(int coins)
    {
        _moneyText.text = coins.ToString();
    }
}
