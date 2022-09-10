using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public List<ItemSO> AllItemSO = new List<ItemSO>();
    public MushroomSO[] MushroomList;
    public PotionSO[] PotionList;
    public RecipeSO[] RecipeList;
    public PotionSO TaintedPotion;
    
    private static ItemsManager _instance;
    public static ItemsManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<ItemsManager>();
                _instance.Init();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (Instance == this) {
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    
    private void Init()
    {
        MushroomList = Resources.LoadAll<MushroomSO>("Mushrooms");
        PotionList = Resources.LoadAll<PotionSO>("Potions");
        RecipeList = Resources.LoadAll<RecipeSO>("Recipes");
        AllItemSO.AddRange(MushroomList);
        AllItemSO.AddRange(PotionList);
    }

}
