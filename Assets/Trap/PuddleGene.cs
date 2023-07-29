using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleGene : MonoBehaviour
{
    private float Settime = 5.0f;
    private float Destroytime = 10.0f;
    private float probability = 0.6f;
    public GameObject Trap;
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(Trap, new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-3.0f, 3.0f), 0), Quaternion.identity);
        Invoke("GenerateTrap", Settime);
        
    }
        void GenerateTrap()
    {
        bool shouldGenerate = Random.value < probability;

        if (shouldGenerate)
        {

             GameObject newTrap = Instantiate(Trap, new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-3.0f, 3.0f), 0), Quaternion.identity);
             Destroy(newTrap, Destroytime);
        }
             Invoke("GenerateTrap", Settime);
    }
}
