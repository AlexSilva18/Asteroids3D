using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public Rigidbody player_body;
    public Laser laserPrefab1, laserPrefab2;
    // public Transform Camera;
    // public Vector3 player_input;
    // public float speed = 200.0f;

    // public float rotationSpeed = 100.0f;
    // private float thrustSpeed = 2.0f;
    // private bool _thrusting;
    // private float translation;
    // private float rotation;


    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 50f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 3.5f, strafeAcceleration = 1f, hoverAcceleration = 1f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 50f, rollAcceleration = 3.5f;
    public float yroll = 5f;
    float timer = 0.0f;


    private bool canMove = true;
    private int currentCameraIndex;
    public Camera[] cameras;
    public Transform leftLaser, rightLaser;





    void Start(){
        player_body = GetComponent<Rigidbody>();

        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        timer += Time.deltaTime;
        float seconds = timer % 60;

        // Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;

        currentCameraIndex = 0;
        if (cameras.Length>0){
             cameras[0].gameObject.SetActive(true);
         }
        // if(seconds >= 3){
        //     Cursor.lockState = CursorLockMode.None;
        // }


    }

    void Update(){

        if(Input.GetKey(KeyCode.R)){
            canMove = true;
        }

        if(canMove == true){
            lookInput.x = Input.mousePosition.x;
            lookInput.y = Input.mousePosition.y;

            mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
            mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;


            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 0.7f);

            rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

            // if (Input.GetKey(KeyCode.A)){
            //     transform.Rotate(0, lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);
            // }
            // else if(Input.GetKey(KeyCode.D)){
            //     transform.Rotate(0, -lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);
                
            // }


            // plane
            // transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, -mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

            // spacheship
            transform.Rotate(mouseDistance.y * lookRateSpeed * Time.deltaTime,  rollInput * rollSpeed * Time.deltaTime, -mouseDistance.x * lookRateSpeed * Time.deltaTime, Space.Self);
            

            // transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, 0, rollInput * rollSpeed * Time.deltaTime, Space.Self);

            activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
            activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
            activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

            transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
            
            // plane
            // transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

            // spaceship
            transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.forward * activeHoverSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.C)){
             currentCameraIndex ++;

             if (currentCameraIndex < cameras.Length){
                 cameras[currentCameraIndex-1].gameObject.SetActive(false);
                 cameras[currentCameraIndex].gameObject.SetActive(true);
             }
             else{
                 cameras[currentCameraIndex-1].gameObject.SetActive(false);
                 currentCameraIndex = 0;
                 cameras[currentCameraIndex].gameObject.SetActive(true);
             }
         }

         if(Input.GetMouseButtonDown(0)){
            Shoot();
        }

        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Asteroid"){
            canMove = false;

            // player_body.velocity = Vector3.zero;
            // player_body.angularVelocity = Vector3.zero;

            // this.gameObject.SetActive(false);

            // FindObjectOfType<GameManager>().PlayerDied();

        }
    }

    private void Shoot(){
        // Laser laser1 = Instantiate(this.laserPrefab1, , transform.rotation);
        // Laser laser2 = Instantiate(this.laserPrefab2, rightLaser.position, transform.rotation);
        Laser laser1 = Instantiate(this.laserPrefab1, leftLaser.position, transform.rotation);
        Laser laser2 = Instantiate(this.laserPrefab2, rightLaser.position, transform.rotation);
        laser1.Project(this.transform.up);
        laser2.Project(this.transform.up);
    }
}
