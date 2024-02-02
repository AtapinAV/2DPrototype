using UnityEngine;

public class TriggerPuls : MonoBehaviour
{
    [SerializeField] private GameObject _pulsObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _pulsObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}

