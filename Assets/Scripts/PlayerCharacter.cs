using System;
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

        //gameManager.EndGame();

        onDeath();
    }

    public void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        Die();
    }

    public PlayerData PlayerData
    {
        get { return playerData; }
    }
    public Action onDeath;

    [SerializeField]
    private PlayerData playerData;
    private GameManager gameManager;


}
