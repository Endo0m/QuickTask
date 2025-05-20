using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Движение")]
    [SerializeField] private float _moveSpeed = 5f;

    [Header("Рывок")]
    [SerializeField] private float _dashDistance = 10f;
    [SerializeField] private float _dashSpeed = 7f;
    [SerializeField] private float _dashCooldown = 1f;

    [Header("Гравитация")]
    [SerializeField] private float _gravity = -20f;

    [Header("Ссылки")]
    [SerializeField] private PlayerInputReader _inputReader;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isDashing;
    private bool _canDash = true;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_isDashing) return;

        Vector2 input = _inputReader.MoveInput;
        Vector3 move = new Vector3(input.x, 0, input.y);

        _velocity.y += _gravity * Time.deltaTime;

        if (move.sqrMagnitude > 0.01f)
        {
            move.Normalize();
            _controller.Move((move * _moveSpeed + _velocity) * Time.deltaTime);
            transform.forward = move;
        }
        else
        {
            _controller.Move(_velocity * Time.deltaTime);
        }

        _playerAnimator.UpdateMovementAnimation(move);

        if (_inputReader.DashPressed && _canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        _isDashing = true;
        _canDash = false;

        _playerAnimator.PlayDash();

        Vector3 dashDir = transform.forward;
        float distanceMoved = 0f;

        while (distanceMoved < _dashDistance)
        {
            float step = _dashSpeed * Time.deltaTime;
            _controller.Move(dashDir * step);
            distanceMoved += step;
            yield return null;
        }

        _playerAnimator.StopSprint();
        _isDashing = false;

        yield return new WaitForSeconds(_dashCooldown);
        _canDash = true;
    }
}
