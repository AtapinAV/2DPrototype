using UnityEngine;

public class GoblinController : BotComponent
{
    protected override void Update()
    {
        base.Update();
        MovementBot();
        AttackBot();
    }
    private void MovementBot()
    {
        if (_dis <= _moveRangeBot && _dis >= _attackRangeBot)
        {
            _animatorBot.SetBool("RunGoblin", true);
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speedBot * Time.deltaTime);
        }
        else { _animatorBot.SetBool("RunGoblin", false); }
    }
    private void AttackBot()
    {
        if (_dis <= _attackRangeBot && _isRecharged)
        {
            _animatorBot.SetTrigger("AttackGoblin");
            _clipAttack.Play();
            _isRecharged = false;

            StartCoroutine(AttackCoolDown());
        }
    }
}
