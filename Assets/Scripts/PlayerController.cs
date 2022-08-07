using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        gameManager = FindObjectOfType<GameManager>();

        //Physics.gravity = new Vector3(0, -200.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float inputZ = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        float speedX = inputX * speed;
        float speedZ = inputZ * speed;

        Vector3 velocity = new Vector3(speedX, 0f, speedZ);

        playerRigidbody.velocity = velocity;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);

        gameManager.EndGame();
    }



    public float speed;
    private Rigidbody playerRigidbody;

    private GameManager gameManager;

}
