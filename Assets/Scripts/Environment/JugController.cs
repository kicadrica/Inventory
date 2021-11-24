using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugController : MonoBehaviour, IAttackable 
{
    [SerializeField] private GameObject Unbroken; 
    [SerializeField] private GameObject Broken1; 
    [SerializeField] private GameObject Broken2; 
    [SerializeField] private GameObject Coin;
    
    public void AttackBy(GameObject attacker) //Реализация метода интерфейса отвечающего за атаку.
    {
        StartCoroutine(CompleteBroke()); 
    }

   private void Start()
    {
        Unbroken.SetActive(true); 
        Broken1.SetActive(false); 
        Broken2.SetActive(false); 
    }

    private IEnumerator CompleteBroke() 
    {
        Unbroken.SetActive(false); 
        Broken1.SetActive(true); 
        yield return new WaitForSeconds(0.30f); 
        Broken1.SetActive(false); 
        Broken2.SetActive(true); 
        yield return new WaitForSeconds(0.20f);
        Broken2.SetActive(false);
        if (Random.value * 100 < 50) //Генерирует рандомное число от 0 до 100. Если меньше 50, то срабатывает условие.
        {
            Instantiate(Coin, transform.position, Quaternion.identity); //Рандомно появляется объект монеты на позиции разбитого предмета.
        }
    }
}
