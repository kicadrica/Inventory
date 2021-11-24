using System.Collections;
using UnityEngine;

public class BoxControllerInteractable : MonoBehaviour, IPushable
{
    private float _teleportDelay = 0.16f;
    public void PushBy(GameObject actor) //Передвижение объекта и его телепортация.
    {
        var direction = transform.position - actor.transform.position; 
        var destination = transform.position + direction; 

        var col = Physics2D.OverlapPoint(destination);
        if (col) 
        {
            var teleport = col.GetComponentInParent<TeleportController>();
            if (teleport) 
            {
                transform.position = teleport.transform.position; 
                teleport.CollectBy(this.gameObject); 
                StartCoroutine(AfterTeleport(direction)); 
            }
            return; 
        }
        transform.position = destination; 
        Physics2D.SyncTransforms(); 
    }
    private IEnumerator AfterTeleport(Vector3 direction) 
    {
        yield return new WaitForSeconds(_teleportDelay); 
        transform.position += direction; 
    }
}
