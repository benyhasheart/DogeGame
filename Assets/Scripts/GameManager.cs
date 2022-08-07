using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        instance = this;
        bulletCount = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameover = false;
        surviveTime = 0.0f;
        spawnTime = timeOffset;               
    }

    // Update is called once per frame
    void Update()
    {
        if ( !isGameover)
        {
            surviveTime += Time.deltaTime;

            timeText.text = "Time : " + (int)surviveTime;
            bulletCountText.text = "Bullet : " + bulletCount;
        }
        else
        {
            if ( Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("GameScene");
            }
        }

        //move to eventManater                

        if ( surviveTime > spawnTime)
        {
            foreach( BulletSpawner spawner in spawnerList)
            {
                spawner.SpawnBullet();                
            }            
            spawnTime += timeOffset;
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if ( surviveTime > bestTime)
        {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time : " + (int)bestTime;
    }

    public void addBulletCount(int value = 1)
    {
        bulletCount += value;
    }

    public static GameManager GameManagerInstance
    {
        get { return instance; }
    }

    private readonly float timeOffset = 1.0f;
    //ui text
    public GameObject gameoverText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordText;
    public TextMeshProUGUI bulletCountText;

    //spawner
    public List<BulletSpawner> spawnerList;

    private static GameManager instance;
    private int bulletCount;

    private float surviveTime;
    private float spawnTime;
    private bool isGameover;
}
