using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _volumeOn;
    [SerializeField] private GameObject _volumeOff;
    [SerializeField] private GameObject _pause;
    [SerializeField] private AudioSource _clip;

    private bool _isPaused;

    private void Awake()
    {
        Pause();
        AudioListener.volume = 1f;
    }
    private void Update()
    {
        PlayPause();
    }

    private void PlayPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        _pause.SetActive(false);
        Time.timeScale = 1f;
        _clip.enabled = true;
        _isPaused = false;
    }
    public void Pause()
    {
        _pause.SetActive(true);
        Time.timeScale = 0f;
        _clip.enabled = false;
        _isPaused = true;
    }
    public void VolumeOff()
    {
        AudioListener.volume = 0f;
        _volumeOn.SetActive(false);
        _volumeOff.SetActive(true);
    }
    public void VolumeOn()
    {
        AudioListener.volume = 1f;
        _volumeOn.SetActive(true);
        _volumeOff.SetActive(false);
    }
}
