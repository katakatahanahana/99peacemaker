using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGene : MonoBehaviour
{
    public GameObject BossPrefab;

    public void GenerateNewMonster(Vector3 position)
    {
        Instantiate(BossPrefab, position, Quaternion.identity);
    }
}
