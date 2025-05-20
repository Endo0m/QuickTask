using UnityEngine;
using UnityEngine.UI;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Button _dashButton;

    private Vector2 _moveInput;
    private bool _dashPressed;

    public Vector2 MoveInput => _moveInput;
    public bool DashPressed => _dashPressed;

    private void Awake()
    {
        _dashButton.onClick.AddListener(OnDashPressed);
    }

    private void Update()
    {
        _moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
    }

    private void LateUpdate()
    {
        _dashPressed = false;
    }

    private void OnDashPressed()
    {
        _dashPressed = true;
    }
}
