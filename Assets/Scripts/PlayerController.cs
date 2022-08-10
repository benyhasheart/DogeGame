using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        gameManager = FindObjectOfType<GameManager>();
        joystick = FindObjectOfType<VariableJoystick>();
        verticalAxis = 0.0f;
        horizentalAxis = 0.0f;
    }
    void Update()
    {
        //verticalAxis = Input.GetAxis("Vertical");
        //horizentalAxis = Input.GetAxis("Horizontal");

        if (joystick)
        {
            direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
            verticalAxis = joystick.Vertical;
            horizentalAxis = joystick.Horizontal;
            //Debug.Log(direction);
        }
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
    private VariableJoystick joystick;

    private float verticalAxis;
    private float horizentalAxis;
    private Vector3 direction;

    public float VerticalAxis
    {
        get { return verticalAxis; }
    }

    public float HorizentalAxis
    {
        get { return horizentalAxis; }
    }

    public Vector3 Direction
    {
        get { return direction; }
    }

}
