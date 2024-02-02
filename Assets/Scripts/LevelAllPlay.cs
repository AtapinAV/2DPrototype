using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAllPlay : MonoBehaviour
{
    public void Level(int level) => SceneManager.LoadScene(level);
}
