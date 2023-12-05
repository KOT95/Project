using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.1f;
    [SerializeField] private Vector3 offset;
    
    private bool _lookAt = true;
    
    private void FixedUpdate()
    {
        if (_lookAt)
        {
            Quaternion OriginalRot = transform.rotation;
            transform.LookAt(target);
            Quaternion NewRot = transform.rotation;
            transform.rotation = OriginalRot;
            transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, 1.5f * Time.deltaTime);
        }

        Vector3 targetPositionWithOffset = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPositionWithOffset, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
