using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Читает ввод с UI-джойстика и кнопки Dash
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
            Debug.LogError("Не назначен FloatingJoystick!");

        if (_dashButton == null)
            Debug.LogError("Не назначена DashButton!");
        else
            _dashButton.onClick.AddListener(OnDashPressed);
    }

    private void LateUpdate()
    {
        DashPressed = false; // сбрасываем каждый кадр
    }

    private void OnDashPressed()
    {
        DashPressed = true;
    }
}
