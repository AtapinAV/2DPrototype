using System.Collections;
using UnityEngine;

public class AddRain : MonoBehaviour
{
    [SerializeField] private GameObject _prefabRain;
    [SerializeField] private float _rainAddTime;

    private bool _isRainTime;
    private void Awake()
    {
        _isRainTime = true;
    }
    private void Update()
    {
        RainAddPrefab();
    }

    private void RainAddPrefab()
    {
        if (_isRainTime)
        {
            var a = Instantiate(_prefabRain, transform.position, Quaternion.identity);
            a.transform.Rotate(0f, 0f, 90f);
            _isRainTime = false;
            StartCoroutine(RainAddTimeNo());
        }
    }
    private IEnumerator RainAddTimeNo()
    {
        yield return new WaitForSeconds(_rainAddTime);
        _isRainTime = true;
    }
}
