using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    static int life = 5;
    
    public SaveScore sScore;
    
    public AudioSource source;
    public AudioClip clipDead;
    public AudioClip clipHitHuman;

    public TextMeshProUGUI lifeCountTag;

    float timer = 1f;
    public bool isPlayed =  false;

    public GameObject deadText;
    public GameObject deadTextBackground;

    public GameObject UIPanelPause;

    void Start()
    {
        lifeCountTag.text = life.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Menú de pause
        if (Input.GetKeyDown("p") && life > 0)
        {
            if (Time.timeScale == 0) {
                //Reanudamos
                Time.timeScale = 1;
                //Ocultamos el menú
                UIPanelPause.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                FirstPersonMovement.isPausedTheGame = false;
                FirstPersonLook.isPausedTheGame = false;
            }
            else {
                //Pausamos
                Time.timeScale = 0;

                //Desplegamos el menú
                UIPanelPause.SetActive(true);
                Cursor.lockState = CursorLockMode.None;

                FirstPersonMovement.isPausedTheGame = true;
                FirstPersonLook.isPausedTheGame = true;
            }
        }



        if (life <= 0){

            if (!isPlayed) {
                
                sScore.saveData();
                source.PlayOneShot(clipDead);
                Debug.Log("Salir");

                isPlayed = true;
            }


            //Pausa el juego
            timer -= Time.deltaTime;
            if (timer < 1) {
                Time.timeScale = 0f;

                deadText.SetActive(true);
                deadTextBackground.SetActive(true);


                if (Input.GetKeyDown("c") && life < 1)
                {
                    SceneManager.LoadScene("GameOverScene");
                }
                //At the moment of death of player
                //Destroy(this.gameObject);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                //
            }

        }
        lifeCountTag.text = life.ToString();

    }


    public void substractLife(){
        if(life > 0){
            life -= 1; 
            Debug.Log("Life: "+life);
            source.PlayOneShot(clipHitHuman);
        }
        
    }

    public bool plusLife(){

        //Valida que no se le asigne más vida del máximo que es 5
        if (life < 5)
        {
            life += 1;
            Debug.Log("Life: " + life);
            return true;
        }
        else {
            return false;
        }
        
    }

    public static bool plusLifeStatic()
    {

        //Valida que no se le asigne más vida del máximo que es 5
        if (life < 5)
        {
            life += 1;
            Debug.Log("Life: " + life);
            return true;
        }
        else
        {
            return false;
        }

    }

}
