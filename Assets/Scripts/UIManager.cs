using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Clear();
    }

    public void GameOver()
    {
        gameOverHUD.SetActive(true);
        gameHUD.SetActive(false);
    }

    public void Clear()
    {
        gameOverHUD.SetActive(false);
        gameHUD.SetActive(true);
    }

    public void SetTimeTextValue(float time)
    {
        timeText.text = "Time : " + ((int)time).ToString();
    }

    public void SetResultTimeTextValue(float time)
    {
        resultTime.text = "Time : " + ((int)time).ToString();
    }

    public void SetBulletCountTextValue(int counts)
    {
        bulletCountText.text = "Bullet : " + counts.ToString();
    }

    public void SetRecoredTimeValue(float time)
    {
        recordText.text = "Best Record : " + ((int)time).ToString();
    }

    public void SetLevelValue(int level)
    {
        levelText.text = "Level : " + level.ToString();
    }

    public static UIManager UIManagerInstance
    {
        get { return instance; }
    }

    public GameObject GameOverHUD
    {
        get { return gameOverHUD; }
    }

    private static UIManager instance;
    [SerializeField]
    private GameObject gameOverHUD;
    [SerializeField]
    private GameObject gameHUD;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private TextMeshProUGUI bulletCountText;
    [SerializeField]
    private TextMeshProUGUI recordText;
    [SerializeField]
    private TextMeshProUGUI resultTime;
    [SerializeField]
    private TextMeshProUGUI levelText;

}
