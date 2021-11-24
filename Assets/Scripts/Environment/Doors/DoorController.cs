using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour //Базовый класс отвечающий за открытие и закрытие дверей.
{
    [SerializeField] private GameObject OpenedDoor; 
    [SerializeField] private GameObject ClosedDoor; 
    private void Start()
    {
        CloseDoor(); 
    }
    protected void OpenDoor() 
    {
        OpenedDoor.SetActive(true); 
        ClosedDoor.SetActive(false); 
    }
    private void CloseDoor() 
    {
        OpenedDoor.SetActive(false); 
        ClosedDoor.SetActive(true); 
    }

}
