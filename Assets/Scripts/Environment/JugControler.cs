using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugControler : MonoBehaviour, IAttackable //Инплементация интерфейса IAttackable. 
{
    public GameObject Unbroken; //В инспекторе назначается объект целого предмета.
    public GameObject Broken1; //В инспекторе назначается объект первой стадии разбитого предмета.
    public GameObject Broken2; //В инспекторе назначается объект второй стадии разбитого предмета.
    public GameObject Coin;
    public void AttackBy(GameObject attacker) //Реализация метода интерфейса отвечающего за атаку.
    {
        StartCoroutine(CompleteBroke()); //Старт коротины.
    }

    void Start()
    {
        Unbroken.SetActive(true); //Включение объекта целого предмета при старте.
        Broken1.SetActive(false); //Выключение объекта первой стадии разбитого предмета.
        Broken2.SetActive(false); //Выключение объекта второй стадии разбитого предмета.
    }

    private IEnumerator CompleteBroke() //Создание коротины. Описывает разбитие предмета.
    {
        Unbroken.SetActive(false); //Выключение объекта целого предмет.
        Broken1.SetActive(true); //Включение объекта первой стадии разбитого предмета.
        yield return new WaitForSeconds(0.30f); //Метод делает задержку между сменой двух объектов.
        Broken1.SetActive(false); //Выключение объекта первой стадии разбитого предмета.
        Broken2.SetActive(true); //Включение объекта второй стадии разбитого предмета.

        if (Random.value * 100 < 50) //Генерирует рандомное число от 0 до 100. Если меньше 50, то срабатывает условие.
        {
            Instantiate(Coin, transform.position, Quaternion.identity); //Рандомно появляется объект монеты на позиции разбитого предмета.
        }
       

    }
}
