using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 0f;

    public GameObject zombieSpanwned;

    public static int numberOfZombies = 14;

    //public Rigidbody zombieModelo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 5){
            //Solo se spawnean zombies luego de 5 segundos y si la cantidad existente es menor a 40
            if (numberOfZombies < 40){

                float random = Random.Range(1f, 3f);
                //Debug.Log("random: "+random);
                if (random > 0 && random < 2) {
                    //Genera el zombie
                    Debug.Log("Genera Zombie");
                    var z = Instantiate(zombieSpanwned, this.transform.position, this.transform.rotation);
                    z.SetActive(true  );
                    //Actualizamos la cantidad de zombies existentes
                    numberOfZombies++;
                    time = 0f;
                }
                
            }
            
        }
    }
}
