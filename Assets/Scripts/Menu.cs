using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnTetrominoButton()
    {
        
        SceneManager.LoadScene(1);
    }
    
    public void OnPentominoButton()
    {
        
        SceneManager.LoadScene(2);
    }
    
    public void OnRestartButton()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OnRestartButton2()
    {
        SceneManager.LoadScene(2);
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
