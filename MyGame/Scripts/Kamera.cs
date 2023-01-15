using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform target;
    private float smooth = 0.2f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            targetPosition.z = transform.position.z;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
        }
    }
}
