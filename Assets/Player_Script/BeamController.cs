using UnityEngine;
using System.Collections;

public class BeamController : MonoBehaviour
{
    //[SerializeField]public float time;

    void start ()
    {
        
    }
	void Update ()
    {
        //指定位置で消す場合
        if ((transform.position.x > 10)||(transform.position.x < -10)) {
			Destroy (gameObject);
		}
        //時間経過で消す場合
        //Destroy(gameObject,time);
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "enemy")
        {
            Variable.enemyhp = Variable.enemyhp - Variable.power;
            if(Variable.enemyhp <= 0)
            {
                Destroy(coll.gameObject);
            }
            Destroy(gameObject);
        }
    }
}