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
    }

    public void GoMainMenu(){
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame(){
        //Para salir
        Application.Quit();
    }
}
