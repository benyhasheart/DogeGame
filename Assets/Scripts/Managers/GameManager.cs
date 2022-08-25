using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        instance = this;
        bulletCount = 0;
        gameLevel = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameover = false;
        surviveTime = 0.0f;
        // 플레이어 델리게이트 등록
        player = FindObjectOfType<PlayerCharacter>();

        if ( !ReferenceEquals(player, null))
        {
            player.onDeath += EndGame;
        }
        //nextlevel Check
        StartCoroutine(NextLevelCoroutine());
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

    }

    IEnumerator NextLevelCoroutine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(nextLevelTime);

        while(true)
        {
            onNextLevel();
            gameLevel += 1;
            UIManager.UIManagerInstance.SetLevelValue(GameLevel);
            yield return waitTime;
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
        UIManager.UIManagerInstance.SetResultTimeTextValue(surviveTime);
        //ui manager setup GameOverUI
        UIManager.UIManagerInstance.GameOver();
    }

    public void RestartGame()
    {
        PauseGame(false);
        UIManager.UIManagerInstance.Clear();
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

    public int GameLevel
    {
        get { return gameLevel; }
    }

    public PlayerCharacter Player
    {
        get { return player; }
    }

    //ui text
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordText;
    public TextMeshProUGUI bulletCountText;


    //spawner
    public List<BulletSpawner> spawnerList;
    //spawnData

    public List<SpawnProjectileData> spawnDataList;
    //delegate
    public Action onNextLevel;

    public float nextLevelTime;

    private int gameLevel;

    private static GameManager instance;
    private PlayerCharacter player;

    private int bulletCount;
    private float surviveTime;
    
    private bool isGameover;
}
