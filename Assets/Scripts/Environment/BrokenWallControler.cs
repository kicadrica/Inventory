using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWallControler : MonoBehaviour, IAttackable //Инплементация интерфейса IAttackable. 
{
    public GameObject UnbrokenWall; //Публичная переменная типа GameObject. В инспекторе назначается объект целой стены.
    public GameObject BrokenWall; //Публичная переменная типа GameObject. В инспекторе назначается объект сломаной стены.

    void Start()
    {
        UnbrokenWall.SetActive(true); //Включение объекта целой стены при старте.
        BrokenWall.SetActive(false); //Выключение объекта сломаной стены при старте.
    }

    public void AttackBy(GameObject attacker) //Реализация метода интерфейса отвечающего за атаку.
    {
        UnbrokenWall.SetActive(false); //Выключение объекта целой стены.
        BrokenWall.SetActive(true); //Включени объекта сломаной стены.
    }
}
