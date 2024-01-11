using UnityEngine;

public class TriggerDiePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamage idamage)) { idamage.GetDamage(101); }
        if (collision.TryGetComponent(out IDamageBot idamageBot)) { idamageBot.GetDamageBot(101); }
    }
}
