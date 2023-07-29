using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1Gene : MonoBehaviour
{
     public GameObject Monster1Prefab;

    public void GenerateNewMonster(Vector3 position)
    {
        Instantiate(Monster1Prefab, position, Quaternion.identity);
    }
}
