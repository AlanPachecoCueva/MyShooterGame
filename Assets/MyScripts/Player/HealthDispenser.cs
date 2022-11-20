using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class HealthDispenser : MonoBehaviour
{

    public GameObject txt;


    float textHealth = 60f;

    public AudioSource source;

    public AudioClip clipHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textHealth += Time.deltaTime;

        //Para que pueda recoger vida cada minuto
        if (Input.GetKeyDown("f") && textHealth >= 60)
        {

            PlayerLife.plusLifeStatic();
            source.PlayOneShot(clipHealth);
            textHealth = 0f;
            txt.SetActive(false);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            txt.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            txt.SetActive(false);

        }
    }
}
