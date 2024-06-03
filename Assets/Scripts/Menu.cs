using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnTetrominoButton() // loading tetromino mode
    {
        
        SceneManager.LoadScene(1);
    }
    
    public void OnPentominoButton() // loading for pentomino mode
    {
        
        SceneManager.LoadScene(2);
    }
    
    public void OnRestartButton() //restarting tetromino mode
    {
        SceneManager.LoadScene(1);
    }
    
    public void OnRestartButton2() //restarting pentomino mode
    {
        SceneManager.LoadScene(2);
    }

    public void OnQuitButton() // quit the game
    {
        Application.Quit();
    }
    
    public void OnMainMenuButton() // loading main menu
    {
        SceneManager.LoadScene(0);
    }
    
}
