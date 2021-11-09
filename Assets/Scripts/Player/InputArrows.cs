using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputArrows : MonoBehaviour
{
    private PlayerController player; //Создание приватной переменной типа PlayerControler.
    void Start()
    {
        player = GetComponentInChildren<PlayerController>(); //Запись компонента PlayerControler в переменную.
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) //Если нажата стрелка вверх, объект игрок запускает метод движения вверх.
        { 
            player.MoveUp();
        }
        if (Input.GetKey(KeyCode.DownArrow)) //Если нажата стрелка вниз, объект игрок запускает метод движения вниз.
        {
            player.MoveDown();
        }
        if (Input.GetKey(KeyCode.LeftArrow)) //Если нажата стрелка влево, объект игрок запускает метод движения влево.
        {
            player.MoveLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow)) //Если нажата стрелка вправо, объект игрок запускает метод движения вправо.
        {
            player.MoveRight();
        }
    }
}
