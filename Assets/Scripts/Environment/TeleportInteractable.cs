using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInteractable : MonoBehaviour, ICollectable //Инплементация интерфейса ICollectable
{
    public Transform destination; //Создание переменной типа Transform для указания в инспекторе второго телепорта.
    public void CollectBy(GameObject actor) //Реализация метода интерфейса с входным параметром типа GameObject, который будет телепортирован.
    {
        StartCoroutine(TeleportObject(actor.transform)); //Старт коротины. Передаем в метод transform телепортируемого объекта.
    }
    private IEnumerator TeleportObject(Transform target) //Создание коротины с входным параметром типа Transform телепортируемого объекта.
    {
        yield return new WaitForSeconds(0.15f); //Задержка телепортации.
        target.position = destination.position; //Присваиваем текущей позиции телепортируемого объекта позицию второго телепорта.
    }
}
