using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualeControler : DoorControler, IPushable //Реализация открытия двери. Наследование класса DoorControler. Инплементация интерфейса IPushable.
{
    public void PushBy(GameObject actor) //Реализация метода интерфейса.
    {
        StartCoroutine(OpenWithDelay()); //Старт коротины.
    }
    private IEnumerator OpenWithDelay() //Создание коротины для задержки при открытии двери.
    {
        yield return new WaitForSeconds(0.15f); //После заданого времени запускается метод  OpenDoor().
        OpenDoor();
    }
}
