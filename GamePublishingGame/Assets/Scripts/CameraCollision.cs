using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 5f;
    public float minDistance = 1f;
    public LayerMask collision;
    Vector3 direction;
    void Start()
    {
        direction = transform.localPosition.normalized;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + player.TransformDirection(direction) * maxDistance;
        RaycastHit hit;
        if(Physics.Linecast(player.position, desiredPosition, out hit, collision))
        {
            float distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
            transform.position = player.position + player.TransformDirection(direction) * distance;
        }
        else
        {
            transform.position = desiredPosition;
        }

        transform.LookAt(player);
    }
}
