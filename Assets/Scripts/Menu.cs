using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnTetrominoButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
    
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
