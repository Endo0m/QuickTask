using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������ ���� � UI-��������� � ������ Dash
/// </summary>
public class PlayerInputReader : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Button _dashButton;
    public bool ShootHeld { get; private set; }
    public Vector2 MoveInput => new Vector2(_joystick.Horizontal, _joystick.Vertical);
    public bool DashPressed { get; private set; }

    private void Awake()
    {
        if (_joystick == null)
            Debug.LogError("�� �������� FloatingJoystick!");

        if (_dashButton == null)
            Debug.LogError("�� ��������� DashButton!");
        else
            _dashButton.onClick.AddListener(OnDashPressed);
    }

    private void LateUpdate()
    {
        DashPressed = false; // ���������� ������ ����
    }

    private void OnDashPressed()
    {
        DashPressed = true;
    }
}
