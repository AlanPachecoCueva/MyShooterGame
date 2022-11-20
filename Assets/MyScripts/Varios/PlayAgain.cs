using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgainMethod(){
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        unpauseGame();
    }

    public void GoMainMenu(){
        SceneManager.LoadScene("MainMenuScene");
        unpauseGame();
    }

    public void QuitGame(){
        //Para salir
        Application.Quit();
    }

    public void unpauseGame() {
        Time.timeScale = 1f;
        FirstPersonMovement.isPausedTheGame = false;
        FirstPersonLook.isPausedTheGame = false;
    }
}
