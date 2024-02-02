using System.Collections;
using UnityEngine;

public class SkeletonBoss : BotComponent
{
    [SerializeField] private float _attackCoolDownTimeBossss;

    protected override void Update()
    {
        base.Update();
        AttackBosss();
    }
    private void AttackBosss()
    {
        if (_dis <= _attackRangeBot && _isBossAttack)
        {
            _animatorBot.SetTrigger("AttackSk");
            _isBossAttack = false;

            StartCoroutine(AttackCoolDownBoss());
        }
    }
    private IEnumerator AttackCoolDownBoss()
    {
        yield return new WaitForSeconds(_attackCoolDownTimeBossss);
        _isBossAttack = true;
    }
}
