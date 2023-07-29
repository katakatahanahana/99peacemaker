using UnityEngine;
using System.Collections;

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

    public float fadeTime = 0.5f;
    private float time;
    private SpriteRenderer render;
    private Rigidbody2D rb2d;


    void Start()
    {
        ChangeDirection();

        //オブジェクトのスケールを取得して、移動距離を計算
        Vector3 scale = transform.localScale;
        distancePerSecond = scale.x * 10 * 20;

        render = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        time += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        if (isMoving)
        {
            if (elapsedTime <= moveDuration)
            {
                Vector2 displacement = direction * distancePerSecond * Time.deltaTime;
                Vector2 newPosition = (Vector2)transform.position + displacement;

                newPosition = new Vector2(
                Mathf.Clamp(newPosition.x, -9, 9),
                Mathf.Clamp(newPosition.y, -4, 4)
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
            if (!Input.GetKeyDown(KeyCode.Space) && elapsedTime > stopDuration)
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
    IEnumerator FadeOutAndDestroy(float time)
    {
        float startAlpha = render.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            Color newColor = new Color(render.color.r, render.color.g, render.color.b, Mathf.Lerp(startAlpha, 0, t));
            render.color = newColor;

            yield return null;
        }
        Vector3 randomPosition = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-3.0f, 3.0f), 0);
        yield return new WaitForSeconds(10.0f);
        Monster2Gene generator = FindObjectOfType<Monster2Gene>();
        generator.GenerateNewMonster(randomPosition);

        Destroy(gameObject);
    }


    //当たり判定
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Beam")
        {
            hp--;
            if (hp <= 0)
            {
                BeamController beam = collision.GetComponent<BeamController>();
                // stop and fade out
                isMoving = false;
                elapsedTime = 0f;
                rb2d.velocity = Vector2.zero;
                Instantiate(beam.particle, transform);
                GetComponent<CircleCollider2D>().enabled = false;
                GameObject.FindObjectOfType<GameManager>().GetPoint(beam.playerNum, 2);
                StartCoroutine(FadeOutAndDestroy(fadeTime));
            }
        }
    }
}
