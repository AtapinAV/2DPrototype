using System.Collections;
using UnityEngine;

public class PlayerAttak : PlayerAComponent
{
    [SerializeField] private LayerMask _botMask;
    [SerializeField] private float _attack1CoolDownTime;
    [SerializeField] private float _attack2CoolDownTime;
    [SerializeField] private float _attackRange;
    [SerializeField] private AudioSource _clipAttack1;
    [SerializeField] private AudioSource _clipAttack2;

    private bool _isAttack1;
    private bool _isAttack2;

    private void Awake()
    {
        _isAttack1 = true; _isAttack2 = true;
    }
    private void Update()
    {
        Attack1();
        Attack2();
    }
    private void Attack1()
    {
        if (Input.GetButtonDown("Fire2") && _isAttack1)
        {
            _animator.SetTrigger("Attack1");
            _clipAttack1.Play();
            _isAttack1 = false;

            StartCoroutine(AttackCoolDown1());
        }
    }
    private void Attack2()
    {
        if (Input.GetButtonDown("Fire1") && _isAttack2)
        {
            _animator.SetTrigger("Attack2");
            _clipAttack2.Play();
            _isAttack2 = false;

            StartCoroutine(AttackCoolDown2());
        }
    }
    protected void OnAttack(int attackDamage)
    {
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, _attackRange, _botMask);
        if (collider2D.TryGetComponent(out IDamageBot idamageBot)) { idamageBot.GetDamageBot(attackDamage); }
    }
    private IEnumerator AttackCoolDown1()
    {
        yield return new WaitForSeconds(_attack1CoolDownTime);
       _isAttack1 = true;
    }
    private IEnumerator AttackCoolDown2()
    {
        yield return new WaitForSeconds(_attack2CoolDownTime);
        _isAttack2 = true;
    }
#if UNITY_EDITOR
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
#endif
}
