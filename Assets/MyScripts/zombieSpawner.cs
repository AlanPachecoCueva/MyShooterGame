using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 0f;

    public Rigidbody zombieModelo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 5){
            GameObject zom = new GameObject();
            Rigidbody zomRG = zom.GetComponent<Rigidbody>();

            zomRG = Instantiate(zombieModelo, this.transform.position,this.transform.rotation);
            time = 0f; 
        }
    }
}
