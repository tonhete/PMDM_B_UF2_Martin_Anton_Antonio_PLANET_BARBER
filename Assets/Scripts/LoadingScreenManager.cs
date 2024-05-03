using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            GameManager.DestroySingleton();
            SceneManager.LoadScene("MainGame");
        }
    }
}
