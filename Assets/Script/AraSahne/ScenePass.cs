using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePass : MonoBehaviour
{
    public void GamePass()
    {
        SceneManager.LoadScene(GameManager.level);
    }
}
