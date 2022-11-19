using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject player;
    PlayerLife pl;
    // Start is called before the first frame update
    void Start()
    {
         pl = player.GetComponent<PlayerLife>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Etiqueta"+other.tag);
        if(string.Compare(other.gameObject.tag, "Player") == 0){
            
            pl.substractLife();
            
        }
    }

}
