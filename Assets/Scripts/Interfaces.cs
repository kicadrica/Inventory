using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPushable //Интерфейс, который инплементируют объекты, которые можно двигать.
{
    void PushBy(GameObject actor); //Метод вызывается для толкания объектов. 
}
interface ICollectable //Интерфейс, который инплементируют объекты, на которые можно стать.
{
    void CollectBy(GameObject collector); //Метод вызывается у объектов, на которые можно стать.
}
interface IAttackable //Интерфейс, который инплементируют объекты, которые можно атаковать.
{
    void AttackBy(GameObject attacker); //Метод вызывается для атаки.
}
