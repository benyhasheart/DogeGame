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
        
    }

    // Update is called once per frame

    public void SetTimeTextValue(float time)
    {
        timeText.text = ((int)time).ToString();
    }

    public void SetResultTimeTextValue(float time)
    {
        resultTime.text = time.ToString();
    }

    public void SetBulletCountTextValue(int counts)
    {
        bulletCountText.text = counts.ToString();
    }

    public void SetRecoredTimeValue(float time)
    {
        recordText.text = ((int)time).ToString();
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
    private TextMeshProUGUI timeText;
    [SerializeField]
    private TextMeshProUGUI bulletCountText;
    [SerializeField]
    private TextMeshProUGUI recordText;
    [SerializeField]
    private TextMeshProUGUI resultTime;

}
