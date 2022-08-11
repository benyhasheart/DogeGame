using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Die()
    {
        gameObject.SetActive(false);

        gameManager.EndGame();
    }

    public void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        Die();
    }

    public PlayerData PlayerData
    {
        get { return playerData; }
    }

    [SerializeField]
    private PlayerData playerData;
    private GameManager gameManager;

}
