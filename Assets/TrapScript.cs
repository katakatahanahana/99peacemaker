using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    private float Appearancetime = 10.0f;
    private float Disappearancetime = 3.0f;
    private float probability = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        transform.position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-3.0f, 3.0f), 0);
        StartCoroutine(Trap());

    }
    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Trap()
    {
        while (true)
        {
            // ランダムな確率でオブジェクトを表示する
            bool shouldAppear = Random.value < probability;

            if (shouldAppear)
            {
                transform.position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-3.0f, 3.0f), 0);
                this.gameObject.SetActive(true);
                yield return new WaitForSeconds(Appearancetime);
            }
            else
            {
                this.gameObject.SetActive(false);
                yield return new WaitForSeconds(Disappearancetime);
            }
        }
    }
}
