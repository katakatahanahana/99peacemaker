using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2Gene : MonoBehaviour
{
    public GameObject Monster2Prefab;

    public void GenerateNewMonster(Vector3 position)
    {
        Instantiate(Monster2Prefab, position, Quaternion.identity);
    }
}
