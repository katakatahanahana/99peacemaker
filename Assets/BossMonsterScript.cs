using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterScript : MonoBehaviour
{
    public float speed = 3.0f;
    private Vector2 direction;
    private float changeTime = 1.5f;
    private bool isMoving = true;
    private Camera mainCamera;
    private int hp = 5;

    void Start()
    {
        mainCamera = Camera.main;
        ChangeDirection();
    }

    void Update()
    {
        changeTime -= Time.deltaTime;

        if (changeTime <= 0f)
        {
            if (isMoving)
            {
                isMoving = false;
                changeTime = 1.5f;  
            }
            else
            {
                isMoving = true;
                ChangeDirection();  
                changeTime = 3.0f;  
            }
        }

        if (isMoving)
        {
            //To avoid going off-screen
            Vector2 newPos = (Vector2)transform.position + direction * speed * Time.deltaTime;
            Vector3 screenPos = mainCamera.WorldToViewportPoint(newPos);
            if (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1)
            {
                transform.position = newPos;
            }
            else
            {
                isMoving = false;
                changeTime = 1.5f;
            }
        }
    }

    void ChangeDirection()
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
    }
}
