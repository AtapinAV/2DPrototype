using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : PlayerAComponent, IDamage
{
    [SerializeField] private int _hpPlayer;
    [SerializeField] private AudioSource _playerDead;

    private PlayerController _playerController;
    private PlayerAttak _playerAttak;

    protected override void Start()
    {
        base.Start();
        _playerController = GetComponent<PlayerController>();
        _playerAttak = GetComponent<PlayerAttak>();
    }
    public void GetDamage(int damage)
    {
        _hpPlayer -= damage;

        if (_hpPlayer <= 0)
        {
            _playerDead.Play();
            _animator.SetTrigger("Death");
            _playerController.enabled = false;
            _playerAttak.enabled = false;

            StartCoroutine(PlayerDie());
        }
    }
    private IEnumerator PlayerDie()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
