using UnityEngine;

public class KeyController : MonoBehaviour, ICollectable 
{
    public void CollectBy(GameObject actor) //В качестве входного параметра передатся объект, который сталкивается с ключом.
    {
        Destroy(gameObject); 
        actor.GetComponentInChildren<PlayerController>().CollectKey(); 

    }
}

