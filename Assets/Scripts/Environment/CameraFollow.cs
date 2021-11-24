using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Target; 

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Target.position.x, Target.position.y,
             Target.position.z - 10), Time.deltaTime*10);
    }
}
