using UnityEngine;

public class Monster1Script : MonoBehaviour
{
    private float distancePerSecond; // 1秒あたりに移動する距離
    private Vector2 direction;
    private float elapsedTime = 0f;
    private float moveDuration = 1f; 
    private float stopDuration = 1f; 
    private bool isMoving = true;
    private int hp = 1;
    private float Angle = 0f;

    void Start()
    {
        ChangeDirection();

        //オブジェクトのスケールを取得して、移動距離を計算
        Vector3 scale = transform.localScale;
        distancePerSecond = scale.x*2;
    }

    void Update()
    {
        Debug.Log(transform.position);
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
        float randomAngle = Random.Range(1,4);
        if (randomAngle == 1)
        {
            Angle = 0f;
        }
        else if (randomAngle == 2)
        {
            Angle = 90f;
        }
        else if (randomAngle == 3)
        {
            Angle = 180f;
        }
        else if (randomAngle == 4)
        {
            Angle = 270f;
        }
    float radian = Angle * Mathf.Deg2Rad;
    direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
}
