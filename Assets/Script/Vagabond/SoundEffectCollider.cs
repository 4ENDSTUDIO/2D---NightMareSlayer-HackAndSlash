using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectCollider : MonoBehaviour
{
    private AudioSource source;
    public AudioClip  RunSound;
    void Start()
    {
     
        source = GetComponent<AudioSource>();
        source.clip = RunSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            
            source.Play();
            

        }
        else
        {
            source.Stop();
           
        }
            
        
    }
}
