using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject1;
    [SerializeField] private GameObject _gameObject2;
    [SerializeField] private GameObject _gameObject3;
    [SerializeField] private GameObject _gameObject4;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameObject1.SetActive(true);
            _gameObject2.SetActive(true);
            _gameObject3.SetActive(true);
            _gameObject4.SetActive(true);
            Destroy(gameObject);
        }       
    }
}
