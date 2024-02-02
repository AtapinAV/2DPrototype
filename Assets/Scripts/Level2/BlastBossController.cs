using UnityEngine;

public class BlastBossController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamage idamage)) { idamage.GetDamage(10); }
        Destroy(gameObject, 0.1f);
    }
}
