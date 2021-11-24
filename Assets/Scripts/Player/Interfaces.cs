using UnityEngine;

interface IPushable //Интерфейс имплементируют объекты, которые можно двигать.
{
    void PushBy(GameObject actor); //Метод вызывается для толкания объектов. 
}

interface ICollectable //Интерфейс имплементируют объекты, на которые можно стать.
{
    void CollectBy(GameObject collector); //Метод вызывается у объектов, на которые можно стать.
}
interface IAttackable //Интерфейс имплементируют объекты, которые можно атаковать.
{
    void AttackBy(GameObject attacker); //Метод вызывается для атаки.
}
