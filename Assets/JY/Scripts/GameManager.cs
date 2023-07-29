using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private GameObject ingamePanel;
    private GameObject curPanel;

    [SerializeField]
    private List<int> points = new List<int>();
    [SerializeField]
    private List<Image> pointGuages = new List<Image>();

    [SerializeField, Tooltip("When the score reaches maxScore, call WinCheck(). // スコアがmaxScoreに達したら、WinCheck()を呼び出します。"), Range(1, 100)]
    private int maxScore = 45;
    [SerializeField]
    private Transform canvasTransform;

    private void Awake()
    {
        if (GameObject.FindObjectsOfType<GameManager>().Length > 1) { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        // 델리게이트 체인 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        // 시작할때 캔버스 받아오기, 기본 ui설정
        canvasTransform = FindObjectOfType<Canvas>().transform;

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                Instantiate(ingamePanel, canvasTransform);
                pointGuages[0] = GameObject.Find("PlayerA Point").GetComponent<Image>();
                pointGuages[1] = GameObject.Find("PlayerB Point").GetComponent<Image>();
                points[0] = 0;
                points[1] = 0;
                //Debug.Log(GameObject.Find("PlayerA Point").GetComponent<Image>());
                //Debug.Log(GameObject.Find("PlayerB Point").GetComponent<Image>());
                break;
        }

    }

    void OnDisable()
    {
        // 델리게이트 체인 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// loadScene , 次のシーンを読み込む 0:title 1:gameScene
    /// </summary>
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }


    /// <summary>
    /// check who is winner. 0:playerA, 1:playerB  勝者が誰なのか確認します。0:playerA, 1:playerB
    /// </summary>
    /// <param name="playerNum"></param>
    public void WinCheck(int playerNum)
    {
        if (curPanel != null) { return; }
        curPanel = Instantiate(resultPanel, canvasTransform);
        curPanel.GetComponentInChildren<Text>().text = "Player" + (char)(65 + playerNum) + " Wins";

        Button[] buttons = curPanel.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(() => LoadScene(0));
        buttons[1].onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        //Debug.Log(buttons[0] + "" + buttons[1]);
    }

    /// <summary>
    /// Called When player Gets Point. プレイヤーがポイントを獲得したときに呼び出されます
    /// </summary>
    /// <param name="playerNum"></param>
    /// <param name="point"></param>
    public void GetPoint(int playerNum, int point)
    {
        points[playerNum] += point;
        pointGuages[playerNum].fillAmount = (float)points[playerNum] / maxScore;
        Debug.Log(pointGuages[playerNum].fillAmount);
        if (points[playerNum] > maxScore) WinCheck(playerNum);
    }
    public void GetPointA()
    {
        GetPoint(0, 1);
    }
}
