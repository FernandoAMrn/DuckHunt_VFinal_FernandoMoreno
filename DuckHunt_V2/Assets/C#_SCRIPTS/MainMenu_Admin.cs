using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Admin : MonoBehaviour
{
  public void PlayGame()
    {
        //Cargar escena del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("Quitting Game");//Solo para comprobar que sale del juego.
        Application.Quit();
        
    }
}
