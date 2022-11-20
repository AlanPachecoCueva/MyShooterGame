using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AmmoDispenser : MonoBehaviour
{

    public GameObject txt;


    float textAmmo = 30f;

    public AudioSource source;

    public AudioClip clipAmmo;

    public GameObject ak74;
    AmmoController ammoControll;
    // Start is called before the first frame update
    void Start()
    {
        ammoControll = ak74.GetComponent<AmmoController>();
    }

    // Update is called once per frame
    void Update()
    {
        textAmmo += Time.deltaTime;

        //Para que pueda recoger munición cada minuto
        if (Input.GetKeyDown("g") && textAmmo >= 30)
        {

            ammoControll.plusAmmo();
            source.PlayOneShot(clipAmmo);
            textAmmo = 0f;
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
