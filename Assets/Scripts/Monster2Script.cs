using UnityEngine;

public class Monster2Script : MonoBehaviour
{
    private float distancePerSecond; // 1秒あたりに移動する距離
    private Vector2 direction;
    private float elapsedTime = 0f;
    private float moveDuration = 0.5f;
    private float stopDuration = 0.5f;
    private bool isMoving = true;
    private int hp = 1;
    private float Angle = 0f;

    void Start()
    {
        ChangeDirection();

        //オブジェクトのスケールを取得して、移動距離を計算
        Vector3 scale = transform.localScale;
        distancePerSecond = scale.x * 10 * 20;
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
                Vector2 newPosition = (Vector2)transform.position + displacement;

                Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

                newPosition = new Vector2(
                    Mathf.Clamp(newPosition.x, -screenBounds.x + 1, screenBounds.x - 1),
                    Mathf.Clamp(newPosition.y, -screenBounds.y + 1, screenBounds.y - 1)
                );
                transform.position = newPosition;
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
        float randomAngle = Random.Range(1, 5);
        switch (randomAngle)
        {
            case 1:
                Angle = 0f;
                break;
            case 2:
                Angle = 90f;
                break;
            case 3:
                Angle = 180f;
                break;
            case 4:
                Angle = 270f;
                break;
            case 5:
                Angle = 360f;
                break;
        }
        float radian = Angle * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
}
