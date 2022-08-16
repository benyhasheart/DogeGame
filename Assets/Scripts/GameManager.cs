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
        // 플레이어 델리게이트 등록
        player = FindObjectOfType<PlayerCharacter>();

        if ( !ReferenceEquals(player, null))
        {
            player.onDeath += EndGame;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( !isGameover)
        {
            surviveTime += Time.deltaTime;
            UIManager.UIManagerInstance.SetTimeTextValue(surviveTime);
            UIManager.UIManagerInstance.SetBulletCountTextValue(bulletCount);
        }        

        //move to eventManager                

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
        PauseGame(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if ( surviveTime > bestTime)
        {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        UIManager.UIManagerInstance.SetRecoredTimeValue(bestTime);
        //ui manager setup GameOverUI
        UIManager.UIManagerInstance.GameOverHUD.SetActive(true);
    }

    public void RestartGame()
    {
        PauseGame(false);
        SceneManager.LoadScene("GameScene");      
    }

    public void PauseGame(bool active)
    {
        if ( active)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void addBulletCount(int value = 1)
    {
        bulletCount += value;
    }

    public static GameManager GameManagerInstance
    {
        get { return instance; }
    }

    //ui text
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordText;
    public TextMeshProUGUI bulletCountText;


    //spawner
    public List<BulletSpawner> spawnerList;

    private static GameManager instance;
    private PlayerCharacter player;
    private readonly float timeOffset = 5.0f;
    private int bulletCount;

    private float surviveTime;
    private float spawnTime;
    private bool isGameover;
}
