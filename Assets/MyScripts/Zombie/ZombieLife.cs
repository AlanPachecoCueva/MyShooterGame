using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLife : MonoBehaviour
{
    public int life = 4;
    private Animator anim;

    ZombieMovement zm;

    public AudioSource source;
    public AudioClip clipZombieDead;

    void Start()
    {
        source = this.GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        zm = GetComponent<ZombieMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void substractLife(){
        //Used by rayCast in RayCastGenerator in the gun
        if(life > 0){
                life -= 1;
                if(life < 1){
                    //The character die
                    zm.setIsDead();
                    //I use the 5 numbers to start an animation in the animator controller
                    anim.SetFloat("VelX", 5);
                    anim.SetFloat("VelY", 5);
                Debug.Log("Sonido muerte");
                if (source.isPlaying)
                {
                    Debug.Log("Para sonido");
                    source.Stop();
                }
                source.volume = 1;
                source.PlayOneShot(clipZombieDead);
                source.volume = 0.1f;
                Invoke("killZombie", 1.5f);
            }
            }
    }

    void killZombie(){
        Destroy(this.gameObject);
    }
    
}
