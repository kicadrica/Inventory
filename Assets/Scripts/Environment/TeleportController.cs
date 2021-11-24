using System.Collections;
using UnityEngine;

public class TeleportController : MonoBehaviour, ICollectable 
{
    [SerializeField] private Transform Destination;
    private float _teleportDelay = 0.15f;
    public void CollectBy(GameObject actor) //Телепортирует объект с одного телепорта к другому.
    {
        StartCoroutine(TeleportObject(actor.transform)); 
    }
    private IEnumerator TeleportObject(Transform target) 
    {
        yield return new WaitForSeconds(_teleportDelay); 
        target.position = Destination.position; 
    }
}
