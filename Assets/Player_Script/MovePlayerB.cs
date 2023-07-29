using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerB : MonoBehaviour
{
    public static float moveSpeedb = 5;
    public static float beamSpeedb = 15;

    private Rigidbody2D rb;
    private SpriteRenderer player;
    private Transform objectPlayer;
    public GameObject BeamPrefab;
    public bool flipX = false;

    public float span = 0.01f;
    private float currentTime = 0f;
    public float angle = 0f;
    float f =1f;

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
        float moveHorizontal = Input.GetAxisRaw("Player2Horizontal");
        float moveVertical = Input.GetAxisRaw("Player2Vertical");
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Variable.directionb = 2;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Variable.directionb = 1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Variable.directionb = 3;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Variable.directionb = 4;
        }
        Rotate();
        
        Vector2 posi = this.transform.position;
        
        if (Input.GetKeyDown (KeyCode.Return)) 
        {
            if(Variable.rb == 1)
            {
                
                if(Variable.directionb == 1)
                {
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x+1.5f,posi.y+0.8f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, angle) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if(Variable.directionb == 3)
                {
                    float d = angle + 90;
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x+1.5f,posi.y+0.8f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d ) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if(Variable.directionb == 4)
                {
                    float d = angle + 270;
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x+1.5f,posi.y+0.8f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d ) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
            }
            else if(Variable.rb == 2)
            {
                if(Variable.directionb == 2)
                {
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x-1.5f,posi.y+0.8f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, angle) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if(Variable.directionb == 4)
                {
                    float d = angle + 90;
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x-1.5f,posi.y+0.8f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d ) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
                else if(Variable.directionb == 3)
                {
                    float d = angle + 270;
                    GameObject Beam = Instantiate (BeamPrefab, new Vector2(posi.x-1.5f,posi.y+0.8f), Quaternion.identity);
                    Vector2 shootDirection = Quaternion.Euler(0f, 0f, d ) *transform.right;
                    Rigidbody2D rb = Beam.GetComponent<Rigidbody2D>();
                    rb.velocity = shootDirection * beamSpeedb; // 進行方向はスクリプトをアタッチしたGameObjectの右方向とします
                }
            }
		}
             
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * moveSpeedb;

        rb.velocity = movement;
    }
    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.rotation = transform.rotation * Quaternion.Euler (0, 180, 0);
            Variable.rb = 1;
            float y = 0;
            transform.rotation = Quaternion.Euler (0, y, 0);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Variable.rb = 2;
            float y = 180;
            transform.rotation = Quaternion.Euler (0, y, 0);
        }
    } 
}