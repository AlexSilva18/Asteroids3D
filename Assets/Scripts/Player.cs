using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public Rigidbody player_body;
    // public Transform Camera;
    // public Vector3 player_input;
    // public float speed = 200.0f;

    // public float rotationSpeed = 100.0f;
    // private float thrustSpeed = 2.0f;
    // private bool _thrusting;
    // private float translation;
    // private float rotation;


    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 1.5f, strafeAcceleration = 1f, hoverAcceleration = 1f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 50f, rollAcceleration = 3.5f;
    public float yroll = 5f;
    float timer = 0.0f;
    


    void Start(){
        player_body = GetComponent<Rigidbody>();

        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        timer += Time.deltaTime;
        float seconds = timer % 60;

        // Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        // if(seconds >= 3){
        //     Cursor.lockState = CursorLockMode.None;
        // }


        
    }

    void Update(){

        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;


        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 0.7f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        if (Input.GetKey(KeyCode.A)){
            transform.Rotate(0, lookRateSpeed * Time.deltaTime,0, Space.Self);
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Rotate(0, -lookRateSpeed * Time.deltaTime,0, Space.Self);
        }

        // transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, 0, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);


        //Store user input as a movement vector
        // player_input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // if (Input.GetKey(KeyCode.Space)){
        //     //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
        //     // player_body.velocity = transform.forward * speed;
        //     _thrusting = true;
        //     transform.position += Vector3.forward * Time.deltaTime * speed;
        // }
        // // else{
        // //     // player_body.velocity = -transform.forward * speed;
        // //     transform.position -= Vector3.forward * Time.deltaTime * speed/4;
        // // }

        // // _thrusting = Input.GetKeyDown(KeyCode.Space);

        // translation = Input.GetAxis("Vertical") * rotationSpeed;
        // rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // // Make it move 10 meters per second instead of 10 meters per frame...
        // translation *= Time.deltaTime;
        // rotation *= Time.deltaTime;

        // // Move translation along the object's z-axis
        // transform.Translate(0, 0, translation);

        // // Rotate around our y-axis
        // transform.Rotate(0, rotation, 0);

        // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
        //     transform.Translate(0, 0, translation);
        // }
        // else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
        //     // Rotate around our y-axis
        //     transform.Rotate(0, rotation, 0);
        // }
        // else {
        //     _turnDirection = 0.0f;
        // }
        // MovePlayer();
    }

    // private void FixedUpdate(){
    //     if(_thrusting){
    //         player_body.AddForce(this.transform.up * thrustSpeed);
    //     }

    //     // if(rotation != 0.0f){
    //     //     player_body.AddTorque(rotation * rotationSpeed);
    //     // }
    // }

    // private void MovePlayer(){
    //     Vector3 MoveVector = transform.TransformDirection(_thrusting) * speed;
    //     player_body.velocity = new Vector3(MoveVector.x, player_body.velocity.y, MoveVector.z);
    // }
}
