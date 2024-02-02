using System.Collections;
using Unity.Collections;
using UnityEngine;

public abstract class BotComponent : MonoBehaviour, IDamageBot
{
    [SerializeField] protected LayerMask _playerMask;
    [SerializeField, ReadOnly] protected float _dis;
    [SerializeField] protected int _hpBot;
    [SerializeField] protected float _speedBot;
    [SerializeField] protected float _attackCoolDownTime;
    [SerializeField] protected int _attackDamage;
    [SerializeField] protected float _attackRangeBot;
    [SerializeField] protected float _moveRangeBot;
    [SerializeField] protected GameObject _prefabDamageEffect;
    [SerializeField] protected AudioSource _clipAttack;
    [SerializeField] protected AudioSource _clipDead;
    [SerializeField] protected AudioSource _clipOnDamage;

    public int HpBot { get { return _hpBot; } }

    protected bool _isRecharged;
    protected bool _isBossAttack;
    protected Animator _animatorBot;
    protected SpriteRenderer _rendererBot;
    protected PlayerAComponent _player;
    protected Rigidbody2D _rbBot;
    protected Collider2D _colliderBot;
    protected  void Awake()
    {
        _isRecharged = true;
        _isBossAttack = true;
    }
    protected  void Start()
    {
        _animatorBot = GetComponent<Animator>();
        _rendererBot = GetComponent<SpriteRenderer>();
        _colliderBot = GetComponent<Collider2D>();
        _rbBot = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<PlayerAComponent>();
    }
    protected virtual void Update()
    {
        _dis = Vector2.Distance(_player.transform.position, transform.position);
        FlipBot();
        MovementBot();
        AttackBot();
    }
    protected void MovementBot()
    {
        if (_dis <= _moveRangeBot && _dis >= _attackRangeBot)
        {
            _animatorBot.SetBool("RunBot", true);
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speedBot * Time.deltaTime);
        }
        else { _animatorBot.SetBool("RunBot", false); }
    }
    protected void AttackBot()
    {
        if (_dis <= _attackRangeBot && _isRecharged)
        {
            _animatorBot.SetTrigger("AttackBot");
            _clipAttack.Play();
            _isRecharged = false;
            StartCoroutine(AttackCoolDown());
        }
    }
    protected void FlipBot()
    {
        if (transform.position.x > _player.transform.position.x) { _rendererBot.flipX = true;}
        else { _rendererBot.flipX = false;}
    }
    protected void OnAttackBot()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, _attackRangeBot, _playerMask);
        if (collider2D == null) { return; }
        else if (collider2D.TryGetComponent(out IDamage idamage)) { idamage.GetDamage(_attackDamage); }
    }
    public void GetDamageBot(int damage)
    {
        _hpBot -= damage;
        if (_hpBot > 0) { _clipOnDamage.Play(); }
        Instantiate(_prefabDamageEffect, transform.position, Quaternion.identity);
        if (_hpBot <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y -0.7f, transform.position.z);
            _clipDead.Play();
            _animatorBot.SetTrigger("DeathBot");
            _colliderBot.enabled = false;
            _rbBot.constraints = (RigidbodyConstraints2D)2;
            Destroy(gameObject, 1f);
        }
    }
    protected IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(_attackCoolDownTime);
        _isRecharged = true;
    }
#if UNITY_EDITOR
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRangeBot);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _moveRangeBot);
    }
#endif
}
