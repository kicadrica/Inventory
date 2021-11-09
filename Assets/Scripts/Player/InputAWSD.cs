using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAWSD : MonoBehaviour
{
    private PlayerController player; //Создание приватной переменной типа PlayerControler.
    void Start()
    {
        player = GetComponentInChildren<PlayerController>(); //Запись компонента PlayerControler в переменную.
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //Если нажата клавиша W, объект игрок запускает метод движения вверх.
        {
            player.MoveUp();
        }
        if (Input.GetKey(KeyCode.S)) //Если нажата клавиша S, объект игрок запускает метод движения вниз.
        {
            player.MoveDown();
        }
        if (Input.GetKey(KeyCode.A)) //Если нажата клавиша A, объект игрок запускает метод движения влево.
        {
            player.MoveLeft();
        }
        if (Input.GetKey(KeyCode.D)) //Если нажата клавиша D, объект игрок запускает метод движения вправо.
        {
            player.MoveRight();
        }
    }
}
