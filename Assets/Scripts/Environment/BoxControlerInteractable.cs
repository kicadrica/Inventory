using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControlerInteractable : MonoBehaviour, IPushable //Инплементация интерфейса IPushable
{
    public void PushBy(GameObject actor) //Реализация метода интерфейса. Передвижение объекта.
    {
        Vector3 direction = transform.position - actor.transform.position; //Запись в переменную направления.
        Vector3 destination = transform.position + direction; //К текущей позиции добавляется направление.

        Collider2D col = Physics2D.OverlapPoint(destination); //Поиск колайдера на точке, к которой совершится движение.
        if (col) //Если колайдер обнаружен...
        {
            var teleport = col.GetComponentInParent<TeleportInteractable>(); //Проверка на наличие компонента телепорта.
            if (teleport) //Если компонент телепорта обнаружен...
            {
                transform.position = teleport.transform.position; //В текущаю позицию записывается позиция телепорта.
                teleport.CollectBy(this.gameObject); //В телепорта вызывается метод отвечающий за перемещение. В качестве аргумента передается текущий объект (коробка).
                StartCoroutine(AfterTeleport(direction)); //Старт коротины.
            }
            return; //Прерывание метода, при обнаружении других колайдеров.
        }
        transform.position = destination; //Если колайдеров не обнажено, текущей позиции присваивается новая позиция.
        Physics2D.SyncTransforms(); 
    }
    private IEnumerator AfterTeleport(Vector3 direction) //Создание коротины для задержки смещения объекта с телепорта.
    {
        yield return new WaitForSeconds(0.16f); //Вызов метода задержки.
        transform.position += direction; //К текущей позиции присваивается текущая позиция плюс направление.
    }
}
