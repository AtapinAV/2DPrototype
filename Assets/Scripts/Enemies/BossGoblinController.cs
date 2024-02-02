using System.Collections;
using UnityEngine;

public class BossGoblinController : BotComponent
{
    [SerializeField] private float _attackCoolDownTimeBoss;
    [SerializeField] private float _forceDashBoss;
    protected override void Update()
    {
        base.Update();
        AttackBoss();
    }
    private void AttackBoss()
    {
        if (_dis > _attackRangeBot && _isBossAttack)
        {
            _animatorBot.SetTrigger("AttackGBoss");
            _clipAttack.Play();
            _rbBot.velocity = Vector3.zero;
            if (transform.position.x > _player.transform.position.x)
            {
                _rbBot.AddForce(Vector3.left * _forceDashBoss, ForceMode2D.Impulse);
            }
            else if (transform.position.x < _player.transform.position.x)
            {
                _rbBot.AddForce(Vector3.right * _forceDashBoss, ForceMode2D.Impulse);
            }
            _isBossAttack = false;

            StartCoroutine(AttackCoolDownBoss());
        }
    }
    private IEnumerator AttackCoolDownBoss()
    {
        yield return new WaitForSeconds(_attackCoolDownTimeBoss);
        _isBossAttack = true;
    }
}
