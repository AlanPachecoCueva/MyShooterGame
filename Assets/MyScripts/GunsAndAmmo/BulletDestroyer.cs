using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime > 0){
            lifeTime -= Time.deltaTime;
            //Debug.Log("Time: "+lifeTime);
        }

        if(lifeTime < 1){
            Destroy(this.gameObject);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
