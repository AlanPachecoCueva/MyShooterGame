using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLife : MonoBehaviour
{
    public int life = 4;
    private Animator anim;

    ZombieMovement zm;

    void Start()
    {
        anim = GetComponent<Animator>();
        zm = GetComponent<ZombieMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.tag == "Bullet"){
    //         if(life > 0){
    //             life -= 1;
    //             if(life < 1){
    //                 //The character die
    //                 Debug.Log("Muerto");
    //                 zm.setIsDead();
    //                 //I use the 5 numbers to start an animation in the animator controller
    //                 anim.SetFloat("VelX", 5);
    //                 anim.SetFloat("VelY", 5);
    //                 Invoke("killZombie", 1f);
    //             }
    //         }
            
    //     }
    // }

    public void substractLife(){
        //Used by rayCast in RayCastGenerator in the gun
        if(life > 0){
                life -= 1;
                if(life < 1){
                    //The character die
                    Debug.Log("Muerto");
                    zm.setIsDead();
                    //I use the 5 numbers to start an animation in the animator controller
                    anim.SetFloat("VelX", 5);
                    anim.SetFloat("VelY", 5);
                    Invoke("killZombie", 1f);
                }
            }
    }

    void killZombie(){
        Destroy(this.gameObject);
    }
}
