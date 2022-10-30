using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollector : MonoBehaviour
{
    public GameObject Gun;
    AmmoController AmmoControll;

    public AudioSource source;
    public AudioClip clip;

    void Start()
    {
        AmmoControll = Gun.GetComponent<AmmoController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            AmmoControll.plusAmmo();
            source.PlayOneShot (clip);
            Destroy(this.gameObject);
        }
    }
}
