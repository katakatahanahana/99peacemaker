using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerA : MonoBehaviour
{
    public static float moveSpeeda = 50;
    public static float beamSpeeda = 15.0f;

    private Rigidbody2D rb;
    private SpriteRenderer player;
    private Transform objectPlayer;
    public GameObject BeamPrefab;
    public bool flipX = false;

    public float span = 0.01f;
    private float currentTime = 0f;
    public static float angle = 0f;
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
        Animator animator = GetComponent<Animator>();
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
        float moveHorizontal = Input.GetAxisRaw("Player1Horizontal");
        float moveVertical = Input.GetAxisRaw("Player1Vertical");

        Vector2 p = this.transform.position;
        if (this.transform.position.x < 10.0f && this.transform.position.x > -10.0f && this.transform.position.y < 10.0f && this.transform.position.y > -10.0f)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Animator animator = GetComponent<Animator>();
                animator.SetBool("Walk", true);
                Variable.directiona = 2;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Animator animator = GetComponent<Animator>();
                animator.SetBool("Walk", true);
                Variable.directiona = 1;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                Animator animator = GetComponent<Animator>();
                animator.SetBool("Walk", true);
                Variable.directiona = 3;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Animator animator = GetComponent<Animator>();
                animator.SetBool("Walk", true);
                Variable.directiona = 4;
            }
            else
            {
                Animator animator = GetComponent<Animator>();
                animator.SetBool("Walk", false);
            }
        }
        Rotate();

        Vector2 posi = this.transform.position;
        spanTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && (spanTime > 0.5f))
        {
            if (Variable.ra == 1)
            {

                if (Variable.directiona == 1)
                {
                    audioSource.PlayOneShot(attackSound);
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x + 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, angle) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if (Variable.directiona == 3)
                {
                    audioSource.PlayOneShot(attackSound);
                    float d = angle + 90;
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x + 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if (Variable.directiona == 4)
                {
                    audioSource.PlayOneShot(attackSound);
                    float d = angle + 270;
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x + 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
            }
            else if (Variable.ra == 2)
            {
                if (Variable.directiona == 2)
                {
                    audioSource.PlayOneShot(attackSound);
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x - 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, angle) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if (Variable.directiona == 4)
                {
                    audioSource.PlayOneShot(attackSound);
                    float d = angle + 90;
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x - 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if (Variable.directiona == 3)
                {
                    audioSource.PlayOneShot(attackSound);
                    float d = angle + 270;
                    GameObject Beam = Instantiate(BeamPrefab, new Vector2(posi.x - 0.3f, posi.y + 0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d) * transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
            }
            spanTime = 0;
        }

        //Vector2 movement = new Vector2(moveHorizontal, moveVertical) * moveSpeeda;
        //
        //rb.velocity = movement;

        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * moveSpeeda;

        // 사각형 범위 (left, right, top, bottom)
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
    }
    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //transform.rotation = transform.rotation * Quaternion.Euler (0, 180, 0);
            Variable.ra = 1;
            float y = 0;
            transform.rotation = Quaternion.Euler(0, y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Variable.ra = 2;
            float y = 180;
            transform.rotation = Quaternion.Euler(0, y, 0);
        }
    }
}