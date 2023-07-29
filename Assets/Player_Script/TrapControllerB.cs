using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControllerB : MonoBehaviour
{
    private float hole_timeb = 0;
    private int hole_flagb = 1;

    private float puddle_timeb = 0;
    private int puddle_flagb = 1;
    AudioSource audioSource;
    public AudioClip puddleSound;
    public AudioClip holeSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();     
    }
    void Update()
    {
        if(hole_flagb == 2){
            hole_timeb += Time.deltaTime;
            if(hole_timeb > 3.0)
            {
                MovePlayerB.moveSpeedb = 5;
                hole_flagb = 1;
                hole_timeb = 0f;
            }
        }
        if(puddle_flagb == 2){
            puddle_timeb += Time.deltaTime;
            if(puddle_timeb > 3.0)
            {
                MovePlayerB.moveSpeedb = 5;
                puddle_flagb = 1;
                puddle_timeb = 0f;
            }
        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "hole")
        {
            audioSource.PlayOneShot(holeSound);
            MovePlayerB.moveSpeedb = 0;
            hole_flagb = 2;
        }
        if(other.gameObject.tag == "puddle")
        {
            audioSource.PlayOneShot(puddleSound);
            MovePlayerB.moveSpeedb = 2.5f;
            puddle_flagb = 2;
        }
    }
}
