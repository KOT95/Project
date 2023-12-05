using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;
    [SerializeField] private Joystick joystick;
    
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 _input = new Vector3();
    private Camera _camera;
    
    public void SetFields()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
    }

    public void Move()
    {
        _input = GetDirection(joystick.Direction, -_camera.transform.eulerAngles.y / 180 * Mathf.PI);
        
        _animator.SetFloat("Velocity", Vector3.ClampMagnitude(_input, 1).magnitude);
        _rigidbody.velocity = Vector3.ClampMagnitude(_input, 1) * speed;
        if(_input.magnitude > Mathf.Abs(0.05f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_input), Time.deltaTime * speedRotation);
        _rigidbody.angularVelocity = Vector3.zero;
    }
    
    private Vector3 GetDirection(Vector3 vector, float AxisY)
    {
        Vector3 result = vector;
        result.x = -vector.y * Mathf.Sin(AxisY) + vector.x * Mathf.Cos(AxisY);
        result.z = vector.y * Mathf.Cos(AxisY) + vector.x * Mathf.Sin(AxisY);
        result.y = 0;

        return result;
    }
}
