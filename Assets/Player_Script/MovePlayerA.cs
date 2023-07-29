using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerA : MonoBehaviour
{
    public static float moveSpeeda = 5;
    public static float beamSpeeda = 7.5f;

    private Rigidbody2D rb;
    private SpriteRenderer player;
    private Transform objectPlayer;
    public GameObject BeamPrefab;
    public bool flipX = false;

    public float span = 0.01f;
    private float currentTime = 0f;
    public static float angle = 0f;
    float f = 1f;

    private float spanTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<SpriteRenderer>();
        objectPlayer = GetComponent<Transform>();
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        
        if(currentTime > 0.01)
            {
                if(Mathf.Abs( angle) > 60){
                    f=-f;
                }
                angle +=f;
                currentTime = 0f;
            }
        float moveHorizontal = Input.GetAxisRaw("Player1Horizontal");
        float moveVertical = Input.GetAxisRaw("Player1Vertical");
        
        Vector2 p = this.transform.position;
        if(Input.GetKey(KeyCode.A))
        {
            Variable.directiona = 2;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Variable.directiona = 1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Variable.directiona = 3;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Variable.directiona = 4;
        }
        Rotate();
        
        Vector2 posi = this.transform.position;
        spanTime += Time.deltaTime;
        if (Input.GetKeyDown (KeyCode.Space)&&(spanTime > 0.5f)) 
        {
            if(Variable.ra == 1)
            {
                
                if(Variable.directiona == 1)
                {
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x+0.3f,posi.y+0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, angle) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if(Variable.directiona == 3)
                {
                    float d = angle + 90;
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x+0.3f,posi.y+0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d ) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if(Variable.directiona == 4)
                {
                    float d = angle + 270;
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x+0.3f,posi.y+0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d ) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
            }
            else if(Variable.ra == 2)
            {
                if(Variable.directiona == 2)
                {
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x-0.3f,posi.y+0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, angle) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if(Variable.directiona == 4)
                {
                    float d = angle + 90;
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x-0.3f,posi.y+0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d ) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if(Variable.directiona == 3)
                {
                    float d = angle + 270;
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x-0.3f,posi.y+0.25f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d ) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeeda; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                } 
            }
            spanTime = 0;
		}
             
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * moveSpeeda;

        rb.velocity = movement;
    }
    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //transform.rotation = transform.rotation * Quaternion.Euler (0, 180, 0);
            Variable.ra = 1;
            float y = 0;
            transform.rotation = Quaternion.Euler (0, y, 0);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            Variable.ra = 2;
            float y = 180;
            transform.rotation = Quaternion.Euler (0, y, 0);
        }
    } 
}