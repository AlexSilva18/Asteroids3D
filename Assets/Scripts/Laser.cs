using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour{
    
    private float speed = 150.0f;
    private float maxLifetime = 10.0f;
    private Rigidbody laser_body;

    private void Awake(){
        laser_body = GetComponent<Rigidbody>();
    }

    void Start(){
        
    }

    public void Project(Vector2 direction){
        laser_body.velocity = transform.forward * speed;
        this.transform.rotation = this.transform.rotation * Quaternion.Euler (90f, 0f, 0f);
        // transform.rotation = Quaternion.LookRotation(direction) * transform.rotation;
        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter(Collision collision){
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update(){

        
    }
}
