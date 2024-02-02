using System.Collections;
using UnityEngine;

public class BossMochController : BotComponent
{
    [SerializeField] private float _attackCoolDownTimeBosss;
    [SerializeField] private AudioSource _clipAttackBoss;
    [SerializeField] private BlastBossController _prefabBlastBoss;
    [SerializeField] private Transform _spawnBlastBossR;
    [SerializeField] private Transform _spawnBlastBossL;
    [SerializeField] private float _forceBlast;

    protected override void Update()
    {
        base.Update();
        AttackBoss();
    }
    private void AttackBoss()
    {
        if (_dis > _attackRangeBot && _isBossAttack)
        {
            _animatorBot.SetTrigger("AttackGMBoss");
            _clipAttackBoss.Play();
            if (_rendererBot.flipX == false)
            {
                var blast = Instantiate(_prefabBlastBoss, _spawnBlastBossR.transform.position, Quaternion.identity);
                blast.GetComponent<SpriteRenderer>().flipX = false;
                blast.GetComponent<Rigidbody2D>().AddForce(Vector3.right * _forceBlast, ForceMode2D.Impulse);
            }
            else if (_rendererBot.flipX == true)
            {
                var blast = Instantiate(_prefabBlastBoss, _spawnBlastBossL.transform.position, Quaternion.identity);
                blast.GetComponent<SpriteRenderer>().flipX = true;
                blast.GetComponent<Rigidbody2D>().AddForce(Vector3.left * _forceBlast, ForceMode2D.Impulse);
            }
            _isBossAttack = false;

            StartCoroutine(AttackCoolDownBoss());
        }
    }
    private IEnumerator AttackCoolDownBoss()
    {
        yield return new WaitForSeconds(_attackCoolDownTimeBosss);
        _isBossAttack = true;
    }
}
