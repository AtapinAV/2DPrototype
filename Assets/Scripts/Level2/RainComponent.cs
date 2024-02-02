using UnityEngine;

public class RainComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamage idamage)) { idamage.GetDamage(101); }
        if (collision.TryGetComponent(out IDamageBot idamageBot)) { idamageBot.GetDamageBot(101); }
        Destroy(gameObject, 0.1f);
    }
}
