using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // then call this to restart game
    public void hardRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
