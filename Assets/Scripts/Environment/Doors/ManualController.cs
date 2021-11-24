using System.Collections;
using UnityEngine;

public class ManualController : DoorController, IPushable 
{
    public void PushBy(GameObject actor) //При столкновении с персонажем, открывает дверь, если есть ключ.
    {
        var actorController = actor.GetComponent<PlayerController>();
        if (!actorController) return;

        if (actorController.KeyHolder == null || actorController.KeyHolder.Keys <= 0) return;
        StartCoroutine(OpenWithDelay()); 
        actorController.KeyHolder.Keys--;

    }
    private IEnumerator OpenWithDelay() 
    {
        yield return new WaitForSeconds(0.15f); 
        OpenDoor();
    }
}
