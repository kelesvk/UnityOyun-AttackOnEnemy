using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuu : MonoBehaviour
{
   public void PlayGames(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }

    public void QuitGameE(){
        Debug.Log("Oyundan Çık");
        Application.Quit();
    }

    public void ReturnToMainMenu(){
        SceneManager.LoadScene("Movement");
    }
}
