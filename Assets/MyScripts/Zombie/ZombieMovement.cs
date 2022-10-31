using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float movementVelocity = 5.0f;
    public float rotationVelocity = 200.0f;

    public float reactionTime = 2f;
    int movement;

    bool wait, walk, rotate, isDead = false;

    private Animator anim;

    public float x,y; 

    //To follow the player
    public GameObject playerToFollow = null;
    void awake(){
        
    }

    void Start()
    {
        playerToFollow = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        //action();
    }

    void Update()
    {
        //To follow the player
        if(playerToFollow == null){
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, playerToFollow.transform.position, movementVelocity * Time.deltaTime);
        anim.SetFloat("VelX", 1);
        //anim.SetFloat("VelX", transform.position.x);
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(playerToFollow.transform.position - transform.position), movementVelocity*Time.deltaTime);
        //transform.up = playerToFollow.transform.position - transform.position;


        // if(isDead == false){
        //     if(wait){
        //         x = 0;
        //         anim.SetFloat("VelX", x);
        //     }
        //     if(walk){
        //         x = 1;
        //         anim.SetFloat("VelX", x);
        //         transform.position += (transform.forward * movementVelocity * Time.deltaTime);;
        //     }
        //     if(rotate){
        //         x = 1;
        //         anim.SetFloat("VelX", x);
        //         transform.Rotate(Vector3.up * Time.deltaTime * rotationVelocity);
        //     }
        //}
    }

    void action(){
        if(isDead == false){
            movement = Random.Range(1, 4);
            if(movement ==1){
                walk = true;
                wait = false;
            }
            if(movement == 2){
                wait = true;
                walk = false;
            }
            if(movement == 3){
                rotate = true;
                StartCoroutine(rotateTime());
            }

            Invoke("action", reactionTime);
        }
    }

    IEnumerator rotateTime(){
        yield return new WaitForSeconds(1);
        rotate = false;
    }

    public void setIsDead(){
        isDead = true;
    }
}
