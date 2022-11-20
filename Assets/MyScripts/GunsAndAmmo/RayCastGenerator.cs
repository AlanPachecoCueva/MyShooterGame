using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastGenerator : MonoBehaviour
{
    public Rigidbody projectil;

    public AudioSource source;
    public AudioClip clipFire;
    public AudioClip clipNoAmmo;
    public AudioClip clipRecharge;
    public AudioClip losePoints;

    public GameObject Gun;

    public GameObject rechargeText;
    public Text ScoreTag;

    AmmoController AmmoControll;

    void Start()
    {
        AmmoControll = Gun.GetComponent<AmmoController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, transform.forward*10f, Color.yellow);
        if(Input.GetButtonDown("Fire1")){
            //If have bullets
            if(AmmoControll.getAmmoCounter() > 0){
                Shoot();
            }else{
                rechargeText.SetActive(true);
                source.PlayOneShot(clipNoAmmo);

                Invoke("TurnOffText",2f);
            }
        }

        //To recharge
        if(Input.GetKeyDown(KeyCode.R)){
            source.PlayOneShot(clipRecharge);
            AmmoControll.rechargeAmmo();
        }
    }

    void TurnOffText(){
        rechargeText.SetActive(false);
    }

    void Shoot(){
        //This bullet is only for view, is not interacting with anyone object
        //Is only because the player needs to see the bullet direction in a graphical way
        GameObject bullet = new GameObject();
        Rigidbody bulletRG = bullet.GetComponent<Rigidbody>();
        bulletRG = Instantiate(projectil, this.transform.position,this.transform.rotation); 
        bulletRG.velocity = this.transform.TransformDirection(Vector3.forward * 20);

        //This is the logic that kill the zombies with the raycast
        RaycastHit hit;
        source.PlayOneShot(clipFire);
        
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, 20f)){
            
            if(string.Compare(hit.transform.tag,"Enemy") == 0){
                //Debug.Log("Pega a zombie");
                hit.transform.gameObject.GetComponent<ZombieLife>().substractLife();

                //Disminuye el número de zombies
                zombieSpawner.numberOfZombies -= 1; 
            }

            if(string.Compare(hit.transform.tag,"Target") == 0){
                source.PlayOneShot (losePoints);
                int aux = int.Parse(ScoreTag.text);
                ScoreTag.text = (aux-1).ToString();
                Destroy(hit.transform.gameObject);
            }
        }
        AmmoControll.minusAmmo();
    }

    // void OnDrawGizmos()
    // {
    //     // Draw a yellow sphere at the transform's position
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawRay(transform.position, transform.forward * 10f);
    // }
}
