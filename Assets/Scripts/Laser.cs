using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour{
    
    public float speed = 200.0f;
    private float maxLifetime = 5.0f;
    private Rigidbody laser_body;

    private void Awake(){
        laser_body = GetComponent<Rigidbody>();
    }

    void Start(){
        
    }

    public void Project(Vector2 direction){
        laser_body.velocity = transform.forward * speed;
        this.transform.rotation = this.transform.rotation * Quaternion.Euler (0f, 0f, 0f);
        // transform.rotation = Quaternion.LookRotation(direction) * transform.rotation;
        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Asteroid"){
            Destroy(this.gameObject);
        }
        
    }

    public void Supersonic(bool on){
        if(on){
            this.speed = 400.0f;
        }
        else{
            this.speed = 200.0f;
        }
    } 

    // Update is called once per frame
    void Update(){

        
    }
}
