using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightControllerA : MonoBehaviour
{
    public Transform target;// 追尾する対象のTransform（物体AのTransformをアサイン）
    public GameObject SightPrefab;

    public float moveSpeed = 100f; // 物体Bの移動速度

    void Update()
    {

        if(Variable.ra == 1)
        {
            if(Variable.directiona == 1)
            {
                float angle = MovePlayerA.angle;
            //    Vector3 direction = Quaternion.Euler(0f, 0f, angle) * transform.right;
         Vector2 shootDirection = Quaternion.Euler(0f, 0f, angle) * transform.right;
       // ベクトルを正規化して長さを1にする
        shootDirection.Normalize();

        // 物体Bの位置を計算して移動させる（少しだけ前にずらす）
        Vector2 newPosition = (Vector2)target.position + shootDirection * 1f;
        transform.position = Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
                //Vector3 targetPosition = new Vector3(target.position.x+0.5f, target.position.y, transform.position.z);
                //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
            // else if(Variable.directiona == 2)
            // {
            //     float d = MovePlayerA.angle + 180;
            //     transform.position = Quaternion.Euler(0f, 0f, d)*transform.right;
            // }
            // else if(Variable.directiona == 3)
            // {
            //     float d = MovePlayerA.angle + 90;
            //     transform.position = Quaternion.Euler(0f, 0f, d)*transform.right;
            // }
            // else if(Variable.directiona == 4)
            // {
            //     float d = MovePlayerA.angle + 270;
            //     transform.position = Quaternion.Euler(0f, 0f, d)*transform.right;
            // }
        }
        else if(Variable.ra == 2)
        {
            if(Variable.directiona == 1)
            {
                transform.position = Quaternion.Euler(0f, 0f, MovePlayerA.angle) *transform.right;
            }   
            else if(Variable.directiona == 2)
            {
                float d = MovePlayerA.angle + 180;
                transform.position = Quaternion.Euler(0f, 0f, d) *transform.right;
            }
            else if(Variable.directiona == 3)
            {
                float d = MovePlayerA.angle + 90;
                transform.position = Quaternion.Euler(0f, 0f, d) *transform.right;
            }
            else if(Variable.directiona == 4)
            {
                float d = MovePlayerA.angle + 270;
                transform.position = Quaternion.Euler(0f, 0f, d) *transform.right;
            } 
        }
    }
}
