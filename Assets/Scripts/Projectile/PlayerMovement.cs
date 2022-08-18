using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<PlayerController>();
        playerData = GetComponent<PlayerCharacter>().PlayerData;
    }

    //Update is called once per frame
    void Update()
    {
        float speedX = controller.HorizentalAxis * playerData.currentSpeed;
        float speedZ = controller.VerticalAxis * playerData.currentSpeed;

        Vector3 velocity = new Vector3(speedX, 0f, speedZ);

        playerRigidbody.velocity = velocity;
        //Vector3 force = controller.Direction * speed * Time.deltaTime;
        //eplayerRigidbody.AddForce(force, ForceMode.VelocityChange);
       // playerRigidbody.velocity = force;
        //Debug.Log(force);
    }
    

    public float speed;
    private PlayerData playerData;
    private Rigidbody playerRigidbody;
    private PlayerController controller;
}
