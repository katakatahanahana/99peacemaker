using UnityEngine;

public class SampleMonster : MonoBehaviour
{
    public float distancePerSecond = 2.0f; // 1秒あたりに移動する距離
    private Vector2 direction;
    private float elapsedTime = 0f;
    private float moveDuration = 2f; 
    private float stopDuration = 1f; 
    private bool isMoving = true;
    private int hp = 1;

    void Start()
    {
        ChangeDirection();
    }

    void Update()
    {

        elapsedTime += Time.deltaTime;

        if (isMoving)
        {
            if (elapsedTime <= moveDuration)
            {
                Vector2 displacement = direction * distancePerSecond * Time.deltaTime;
                transform.position = (Vector2)transform.position + displacement;
            }
            else
            {
                isMoving = false;
                elapsedTime = 0f;
            }
        }
        else
        {
            if (elapsedTime > stopDuration)
            {
                isMoving = true;
                elapsedTime = 0f;
                ChangeDirection();
            }
        }
    }

    void ChangeDirection()
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
    }
}
