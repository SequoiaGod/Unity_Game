using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // required to use the Text class
using UnityEngine.SceneManagement;
public class TargetGameController : MonoBehaviour
{
    [SerializeField]public float timeLeft = 300.0f;
    private float enemyLeft;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI enemyText;
    public static int boxres =0;
    public GameObject box;
    public GameObject enemy;
    public Transform enemyPosition;
    public Transform boxPosition;
    public  float enemyRate = 1.0f;
    public GameObject Panel;
    
    public TextMeshProUGUI enemyScore;
    public TextMeshProUGUI boxScore;
    public TextMeshProUGUI bloodScore;
    public TextMeshProUGUI finalScore;

    public ScoreManager scoreManager;
    public int perrEnemy = -200;
    private int perrBlood = 100;
    public int perrBox = 2000;
    public static int killEnemyNum = 0;

    // public TMP_Text enemyScore;

    public float nextEnemy = 10.0f; 

    public GameObject failGame;
    // private PlayerController ply;
    // public TextMeshProUGUI bloodText;
    // private int bloodLeft;


    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("LeftTime").GetComponent<TextMeshProUGUI>();
        enemyText = GameObject.Find("EnemyLeft").GetComponent<TextMeshProUGUI>();
        
        PlayerController.isDead = false;

        // bloodText = GameObject.Find("BloodText").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.isDead ==true)
        {
            failGame.SetActive(true);
            SceneManager.LoadScene(2);
        }
        
        timeLeft -= Time.deltaTime;
        enemyLeft = GameObject.FindObjectsOfType<Destroyable>().Length;
        // bloodLeft = ply.getCurrHealth();

        if (timeLeft < 0) 
        {
            timeLeft=0;
            // Debug.Log("game lost"); 
        }
         timeText.text = timeLeft.ToString("0");
         enemyText.text = enemyLeft.ToString("0");
        //  bloodText.text = bloodLeft.ToString("0");


        if(GameObject.FindGameObjectsWithTag("box").Length <destroyBox.boxNum)
        {
            Instantiate(box,boxPosition.position, Quaternion.identity);
        }

        // Debug.Log(timeLeft%30.0f);
        if(GameObject.FindGameObjectsWithTag("enemy").Length<80){
            if(Time.time >nextEnemy)
            {
                nextEnemy = Time.time + enemyRate;
                Instantiate(enemy,enemyPosition.position, Quaternion.identity);

            }
        }


        checkedEnd(timeLeft);


    }

    public void TargetDestroyed() 
    {
        // if(timeLeft<=0f)//(GameObject.FindObjectsOfType<Destroyable>().Length == 0) 
        // {
        //     Debug.Log("game won");
        //     StartCoroutine(endGame());
        // }

    }


    IEnumerator endGame(){
        yield return new WaitForSeconds(3); 

        SceneManager.LoadScene(0);
    }

    void checkedEnd(float time){
        if(timeLeft<=0f)//(GameObject.FindObjectsOfType<Destroyable>().Length == 0) 
        {

            Panel.SetActive(true);
            bool panelTrue = Panel.activeSelf;
            enemyScore = GameObject.Find("EnemyScore").GetComponent<TextMeshProUGUI>();
            boxScore = GameObject.Find("BoxScore").GetComponent<TextMeshProUGUI>();
            bloodScore = GameObject.Find("BloodScore").GetComponent<TextMeshProUGUI>();
            finalScore = GameObject.Find("TotalScore").GetComponent<TextMeshProUGUI>();
            Debug.Log("game won");
            float res = killEnemyNum * perrEnemy + PlayerController.currHealth * perrBlood + boxres * perrBox;
            enemyScore.text = killEnemyNum.ToString("0");
            bloodScore.text = PlayerController.currHealth.ToString("0");
            boxScore.text = boxres.ToString("0");
            finalScore.text = res.ToString("0");
            
            StartCoroutine(endGame());
            
            scoreManager.setScore(res,SceneManager.GetActiveScene().buildIndex); 
        }

    }
}
