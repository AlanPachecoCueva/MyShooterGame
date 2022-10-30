using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody projectil;

    public AudioSource source;
    public AudioClip clipFire;
    public AudioClip clipNoAmmo;
    public AudioClip clipRecharge;

    public GameObject Gun;

    public GameObject rechargeText;

    AmmoController AmmoControll;
    void Start()
    {
        AmmoControll = Gun.GetComponent<AmmoController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        GameObject bullet = new GameObject();
        Rigidbody bulletRG = bullet.GetComponent<Rigidbody>();
        //Rigidbody bullet;
        source.PlayOneShot(clipFire);
        bulletRG = Instantiate(projectil, this.transform.position,this.transform.rotation); 
        bulletRG.velocity = this.transform.TransformDirection(Vector3.forward * 20);
        AmmoControll.minusAmmo();
        //Destroy(bulletRG,.5f);
        //Destroy(bullet.GetComponent<>(),5f);
    }
}
