using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load Gameplay scene(Game Screen)
    public void PlayGame()
    {
        
        SceneManager.LoadScene("GamePlay");
    }

    //To let player quit application
    public void QuitGame()
    {
        Application.Quit();
        print("Quit");
    }
}
