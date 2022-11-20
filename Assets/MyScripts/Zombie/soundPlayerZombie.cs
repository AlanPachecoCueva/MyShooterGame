using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundPlayerZombie : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clipZombieSound;

    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 5) {
            float random = Random.Range(1f, 5f);

            if (random > 0 && random < 2)
            {
                source.PlayOneShot(clipZombieSound);
                time = 0;
            }
        }
    }
}
