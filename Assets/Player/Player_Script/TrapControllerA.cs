using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TrapControllerA : MonoBehaviour
{
    private float hole_timea = 0;
    private int hole_flaga = 1;

    private float puddle_timea = 0;
    private int puddle_flaga = 1;
    AudioSource audioSource;
    public AudioClip puddleSound;
    public AudioClip holeSound;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        if (hole_flaga == 2)
        {
            hole_timea += Time.deltaTime;
            if (hole_timea > 3.0)
            {
                MovePlayerA.moveSpeeda = 5;
                hole_flaga = 1;
                hole_timea = 0f;
            }
        }
        if (puddle_flaga == 2)
        {
            puddle_timea += Time.deltaTime;
            if (puddle_timea > 3.0)
            {
                MovePlayerA.moveSpeeda = 5;
                puddle_flaga = 1;
                puddle_timea = 0f;
            }
        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "hole")
        {
            audioSource.PlayOneShot(holeSound);
            MovePlayerA.moveSpeeda = 0;
            hole_flaga = 2;
        }
        if (other.gameObject.tag == "puddle")
        {
            audioSource.PlayOneShot(puddleSound);
            MovePlayerA.moveSpeeda = 2.5f;
            puddle_flaga = 2;
            StartCoroutine(SlowParticle());
        }
    }

    IEnumerator SlowParticle()
    {
        GameObject go = Instantiate(particle);
        for (int i = 0; i < 3; i++)
        {
            go.transform.position = transform.position;
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
}
