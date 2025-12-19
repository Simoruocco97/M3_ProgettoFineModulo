using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        if (target == null) return;
        else
        {
            Vector3 cameraPosition = new Vector3(target.position.x, target.position.y, gameObject.transform.position.z);
            transform.position = cameraPosition;
        }
    }
}