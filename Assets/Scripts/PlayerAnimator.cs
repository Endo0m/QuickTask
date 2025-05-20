using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int DashTrigger = Animator.StringToHash("Dash");
    private static readonly int IsSprinting = Animator.StringToHash("IsSprinting");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayDash()
    {
        _animator.SetTrigger(DashTrigger);
        _animator.SetBool(IsSprinting, true); // ��������� ����������� ������
        _animator.SetBool(IsRunning, false);  // ��������� ������� ���
    }

    public void StopSprint()
    {
        _animator.SetBool(IsSprinting, false); // ��������� ������
    }

    public void UpdateMovementAnimation(Vector3 velocity)
    {
        if (_animator.GetBool(IsSprinting)) return; // ���� ������ � �� �������� ���

        bool isMoving = velocity.sqrMagnitude > 0.01f;
        _animator.SetBool(IsRunning, isMoving);
    }
}
