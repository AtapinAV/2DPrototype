using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ScriptBoss : MonoBehaviour
{
    [SerializeField] private GameObject _nextLevel;
    [SerializeField] private BotComponent _boss;
    [SerializeField] private TextMeshProUGUI _hpBoss;
    [SerializeField] private GameObject _hpTextBoss;
    [DllImport("__Internal")]
    private static extern void ReclamaData();

    private void Update()
    {
        _hpBoss.text = _boss.HpBot.ToString();
        DeadBoss();
    }
    private void DeadBoss()
    {
        if (_boss.HpBot <= 0)
        {
            Destroy(_hpTextBoss);
            StartCoroutine(NextLevel());
        }
    }
    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2.5f);
        _nextLevel.SetActive(true);
        Time.timeScale = 0f;
        ReclamaData();
    }
}
