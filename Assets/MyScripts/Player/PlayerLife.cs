using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    int life = 4;
    
    public SaveScore sScore;
    
    public AudioSource source;
    public AudioClip clipDead;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0){
            sScore.saveData();
            source.PlayOneShot(clipDead);
            Debug.Log("Salir");
            //At the moment of death of player
            //Destroy(this.gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void substractLife(){
        if(life > 0){
            life -= 1; 
            Debug.Log("Life: "+life);
        }
        
    }

    public void plusLife(){
        life += 1; 
        Debug.Log("Life: "+life);
    }

}
