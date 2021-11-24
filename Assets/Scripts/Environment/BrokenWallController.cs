using UnityEngine;

public class BrokenWallController : MonoBehaviour, IAttackable 
{
    [SerializeField] private GameObject UnbrokenWall; 
    [SerializeField] private GameObject BrokenWall; 

    private void Start()
    {
        UnbrokenWall.SetActive(true); 
        BrokenWall.SetActive(false); 
    }

    public void AttackBy(GameObject attacker) //Реализация метода интерфейса отвечающего за атаку.
    {
        UnbrokenWall.SetActive(false); 
        BrokenWall.SetActive(true); 
    }
}
