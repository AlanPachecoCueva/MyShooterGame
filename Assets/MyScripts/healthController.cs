using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
{
    public GameObject player;
    PlayerLife pLife;

    public AudioSource source;
    public AudioClip clip;

    void Start()
    {
        pLife = player.GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            pLife.plusLife();
            source.PlayOneShot(clip);
            Destroy(this.gameObject);
        }
    }
}
