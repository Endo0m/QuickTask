using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private JoystickInput _input; 
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _dashForce = 8f;
    [SerializeField] private float _dashCooldown = 1f;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private bool _canDash = true;
    private float _lastDashTime;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = _input.MoveInput;

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        if (move.sqrMagnitude > 0.01f)
        {
           
            move = move.normalized * _moveSpeed;
            _animator.SetBool("IsRunning", true);

           
            transform.forward = move;
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }

        _rigidbody.velocity = new Vector3(move.x, _rigidbody.velocity.y, move.z);

       
        if (_input.DashPressed && _canDash)
        {
            Dash(move.normalized);
        }
    }

    private void Dash(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f)
            return;

        _rigidbody.AddForce(direction * _dashForce, ForceMode.VelocityChange);
        _canDash = false;
        _lastDashTime = Time.time;

        
        Invoke(nameof(ResetDash), _dashCooldown);
    }

    private void ResetDash()
    {
        _canDash = true;
    }
}
