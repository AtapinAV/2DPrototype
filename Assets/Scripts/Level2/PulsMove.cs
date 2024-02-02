using UnityEngine;

public class PulsMove : MonoBehaviour
{
    [SerializeField] private float _speedPuls;
    [SerializeField] private int _deletePuls;
    private void Update()
    {
        MovePuls();
        Destroy(gameObject, _deletePuls);
    }
    private void MovePuls() { transform.position += _speedPuls * Time.deltaTime * Vector3.left; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamage idamage)) { idamage.GetDamage(101); }
        if (collision.TryGetComponent(out IDamageBot idamageBot)) { idamageBot.GetDamageBot(101); }
        Destroy(gameObject, 0.1f);
    }
}
