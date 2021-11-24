using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe")]
public class RecipeSO : ScriptableObject
{
    public MushroomSO Mushroom1;
    public MushroomSO Mushroom2;
    public PotionSO Potion;
}
