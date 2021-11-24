using System.Collections;
using UnityEngine;

public class ManualController : DoorController, IPushable 
{
    public void PushBy(GameObject actor) //При столкновении с персонажем, открывает дверь, если есть ключ.
    {
        var actorController = actor.GetComponent<PlayerController>();
        if (!actorController) return;

        if (!actorController.HasKeys) return;
        StartCoroutine(OpenWithDelay()); 
        actorController.RemoveKey();

    }
    private IEnumerator OpenWithDelay() 
    {
        yield return new WaitForSeconds(0.15f); 
        OpenDoor();
    }
}
