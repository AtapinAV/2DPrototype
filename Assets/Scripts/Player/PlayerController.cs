using System.Collections;
using UnityEngine;

public class PlayerController : PlayerAComponent
{
    private bool _isJump;
    private bool _isDash;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    private float _dashEffectTimeActive;

    [SerializeField] private float _dashCoolDownTime;
    [SerializeField] private float _forceDash;
    [SerializeField] private float _forceJump;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _dashEffectLeft;
    [SerializeField] private GameObject _dashEffectRight;
    [SerializeField] private AudioSource _clipJump;
    [SerializeField] private AudioSource _clipDash;


    private void Awake()
    {
        _isDash = true;
        _dashEffectTimeActive = 0.4f;
    }
    protected override void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        PlayerMovement();
        PlayerJump();
        PlayerDash();
    }
    private void PlayerMovement()
    {
        var hor = Input.GetAxis("Horizontal");
        transform.position += _speed * Time.deltaTime * hor * Vector3.right;

        if (hor > 0f) _spriteRenderer.flipX = false;
        if (hor < 0f) _spriteRenderer.flipX = true;

        if (hor != 0f) _animator.SetBool("Run", true);
        else { _animator.SetBool("Run", false); }
    }
    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && !_isJump)
        {
            _clipJump.Play();
            _animator.SetBool("Jump", true);
            _rb.AddForce(Vector3.up * _forceJump, ForceMode2D.Impulse);
            _isJump = true;
        }
    }
    private void PlayerDash()
    {
        if (Input.GetButtonDown("Dashe") && _isDash)
        {
            _clipDash.Play();
            _animator.SetTrigger("Dashe");
            _rb.velocity = Vector3.zero;

            if (_spriteRenderer.flipX == false && Input.GetKey(KeyCode.D))
            {
                _dashEffectLeft.SetActive(true);
                _rb.AddForce(Vector3.right * _forceDash, ForceMode2D.Impulse);
            } 
            else if (_spriteRenderer.flipX == true && Input.GetKey(KeyCode.A))
            {
                _dashEffectRight.SetActive(true);
                _rb.AddForce(Vector3.left * _forceDash, ForceMode2D.Impulse);
            }
            _isDash = false;
            StartCoroutine(DashCoolDown());
            StartCoroutine(DashEffectActive());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("Jump", false);
            _isJump = false;
        }
    }
    private IEnumerator DashCoolDown()
    {
        yield return new WaitForSeconds(_dashCoolDownTime);
        _isDash = true;
    }
    private IEnumerator DashEffectActive()
    {
        yield return new WaitForSeconds(_dashEffectTimeActive);
        _dashEffectLeft.SetActive(false); _dashEffectRight.SetActive(false);
    }
}
