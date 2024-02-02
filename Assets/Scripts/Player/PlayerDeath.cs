using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : PlayerAComponent, IDamage
{
    [SerializeField] private int _hpPlayer;
    [SerializeField] private AudioSource _playerDead;
    [SerializeField] private AudioSource _playerOnDamage;
    [SerializeField] private TextMeshProUGUI _hpPlayerText;
    [SerializeField] private GameObject _prefabBloom;
    [SerializeField] private Collider2D _playerCollider;

    private PlayerController _playerController;
    private PlayerAttak _playerAttak;

    protected override void Start()
    {
        base.Start();
        _playerController = GetComponent<PlayerController>();
        _playerAttak = GetComponent<PlayerAttak>();
    }
    private void Update()
    {
        _hpPlayerText.text = _hpPlayer.ToString();
    }
    public void GetDamage(int damage)
    {
        _hpPlayer -= damage;
        _playerOnDamage.Play();
        Instantiate(_prefabBloom, transform.position, Quaternion.identity);
        if (_hpPlayer <= 0)
        {
            _playerDead.Play();
            _animator.SetTrigger("Death");
            _playerController.enabled = false;
            _playerAttak.enabled = false;
            _playerCollider.enabled = false;
            _rb.constraints = (RigidbodyConstraints2D)2;

            StartCoroutine(PlayerDie());
        }
    }
    private IEnumerator PlayerDie()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
