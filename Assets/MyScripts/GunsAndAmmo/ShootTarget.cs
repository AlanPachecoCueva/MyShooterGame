using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootTarget : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Text ScoreTag;
    public AudioSource source;
    public AudioClip winPoints;
    public AudioClip losePoints;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            source.PlayOneShot (winPoints);
            int aux = int.Parse(ScoreTag.text);
            ScoreTag.text = (aux+1).ToString();
            Destroy(this.gameObject);
        }
        if(other.tag == "Bullet"){
            source.PlayOneShot (losePoints);
            int aux = int.Parse(ScoreTag.text);
            ScoreTag.text = (aux-1).ToString();
            Destroy(this.gameObject);
        }
    }
}
