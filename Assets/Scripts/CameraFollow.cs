using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //Создание переменной типа Transform. В инспекторе назначается объект, за которым должна следовать камера.

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, target.position.z - 10), Time.deltaTime*10);
        
    }
}
