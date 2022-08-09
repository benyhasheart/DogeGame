using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        gameManager = FindObjectOfType<GameManager>();

        verticalAxis = 0.0f;
        horizentalAxis = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        verticalAxis = Input.GetAxis("Vertical");
        horizentalAxis = Input.GetAxis("Horizontal");

     

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

    private GameManager gameManager;

    private float verticalAxis;
    private float horizentalAxis;

    public float VerticalAxis
    {
        get { return verticalAxis; }
    }

    public float HorizentalAxis
    {
        get { return horizentalAxis; }
    }

}
