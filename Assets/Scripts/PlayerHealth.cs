using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private Image _healthBar; // UI элемент с FillAmount

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        UpdateUI();
    }

    public void TakeDamage(float amount)
    {
        _currentHealth = Mathf.Max(0, _currentHealth - amount);
        UpdateUI();

        if (_currentHealth <= 0)
        {
            Debug.Log("Игрок погиб");
            // Тут можно вызвать анимацию смерти и т.д.
        }
    }
    public bool Heal(float amount)
    {
        if (_currentHealth >= _maxHealth)
            return false;

        _currentHealth = Mathf.Min(_maxHealth, _currentHealth + amount);
        UpdateUI();
        return true;
    }


    private void UpdateUI()
    {
        if (_healthBar != null)
            _healthBar.fillAmount = _currentHealth / _maxHealth;
    }
}
