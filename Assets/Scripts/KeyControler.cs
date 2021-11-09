using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControler : MonoBehaviour, ICollectable //Инплементация интерфейса ICollectable
{
    public void CollectBy(GameObject actor) //Реализация метода интерфейса. В качестве входного параметра передатся объект, который сталкивается с ключом.
    {
        Destroy(gameObject); //Уничтожение объекта при столкновении (ключа).
        actor.GetComponentInChildren<PlayerController>().CollectKey(); //Поиск компонента PlayerControler у объекта, который столкнулся с монетой и вызов у него метода счета ключей.

    }
}

