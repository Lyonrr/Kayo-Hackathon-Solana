using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public int sceneBuildIndex = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }


    private void QuitGame()
    {
        Application.Quit();
        //SceneManager.LoadScene(sceneBuildIndex);
    }
}
