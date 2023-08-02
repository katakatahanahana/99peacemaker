using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerB : MonoBehaviour
{
    public static float moveSpeedb = 50;
    public static float beamSpeedb = 15.0f;

    private Rigidbody2D rb;
    private SpriteRenderer player;
    private Transform objectPlayer;
    public GameObject BeamPrefab;
    public bool flipX = false;

    public float span = 0.01f;
    private float currentTime = 0f;
    public float angle = 0f;
    float f = 1f;
    AudioSource audioSource;
    public AudioClip attackSound;

    private float spanTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<SpriteRenderer>();
        objectPlayer = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 0.01)
        {
            if (Mathf.Abs(angle) > 60)
            {
                f = -f;
            }
            angle += f;
            currentTime = 0f;
        }
        float moveHorizontal = Input.GetAxisRaw("Player2Horizontal");
        float moveVertical = Input.GetAxisRaw("Player2Vertical");

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("Walk", true);
            Variable.directionb = 2;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("Walk", true);
            Variable.directionb = 1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("Walk", true);
            Variable.directionb = 3;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("Walk", true);
            Variable.directionb = 4;
        }
        else
        {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("Walk", false);
        }
        Rotate();

        Vector2 posi = this.transform.position;
        spanTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Return) && (spanTime > 0.25f))
        {
            if (Variable.rb == 1)
            {

                if (Variable.directionb == 1)
                {
                    audioSource.PlayOneShot(attackSound);
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x + 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, angle) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if (Variable.directionb == 3)
                {
                    audioSource.PlayOneShot(attackSound);
                    float d = angle + 90;
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x + 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if (Variable.directionb == 4)
                {
                    audioSource.PlayOneShot(attackSound);
                    float d = angle + 270;
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x + 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
            }
            else if (Variable.rb == 2)
            {
                if (Variable.directionb == 2)
                {
                    audioSource.PlayOneShot(attackSound);
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x - 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, angle) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if (Variable.directionb == 4)
                {
                    audioSource.PlayOneShot(attackSound);
                    float d = angle + 90;
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x - 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if (Variable.directionb == 3)
                {
                    audioSource.PlayOneShot(attackSound);
                    float d = angle + 270;
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x - 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
            }
            spanTime = 0;
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * moveSpeedb;

        float leftBoundary = -11f; // 좌측 경계
        float rightBoundary = 11f; // 우측 경계
        float topBoundary = 8f; // 상단 경계
        float bottomBoundary = -8f; // 하단 경계

        // 제한된 위치 계산
        float clampedX = Mathf.Clamp(rb.position.x + movement.x * Time.deltaTime, leftBoundary, rightBoundary);
        float clampedY = Mathf.Clamp(rb.position.y + movement.y * Time.deltaTime, bottomBoundary, topBoundary);

        // 제한된 위치를 새로운 위치로 설정
        Vector2 clampedPosition = new Vector2(clampedX, clampedY);

        rb.MovePosition(clampedPosition);
        //rb.velocity = movement;

    }
    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.rotation = transform.rotation * Quaternion.Euler (0, 180, 0);
            Variable.rb = 1;
            float y = 0;
            transform.rotation = Quaternion.Euler(0, y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Variable.rb = 2;
            float y = 180;
            transform.rotation = Quaternion.Euler(0, y, 0);
        }
    }
}