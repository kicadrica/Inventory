using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour //Класс отвечающий за двери.
{
    public GameObject openedDoor; //Создание переменной типа GameObject. В инспекторе назначается объект открытой двери.
    public GameObject closedDoor; //Создание переменной типа GameObject. В инспекторе назначается объект закрытой двери.

    void Start()
    {
        CloseDoor(); //При старте игры дверь закрыта.
    }
    protected void OpenDoor() //Метод открытой двери.
    {
        openedDoor.SetActive(true); //Включение объекта открытой двери.
        closedDoor.SetActive(false); //Выключение объекта закрытой двери.
    }
    protected void CloseDoor() //Метод закрытой двери.
    {
        openedDoor.SetActive(false); //Выключение объекта открытой двери.
        closedDoor.SetActive(true); //Включение объекта закрытой двери.
    }

}
