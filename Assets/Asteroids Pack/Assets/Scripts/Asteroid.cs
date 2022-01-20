using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour{
    
    private Rigidbody asteroid_body;
    public float size;
    public float minSize = 10f;
    public float maxSize = 35f;
    public float speed;
    public float minSpeed = 20f;
    public float maxSpeed = 40f;
    // private float speed = 10f;

    private void Awake(){
        asteroid_body = GetComponent<Rigidbody>();
    }


    void Start(){
        this.transform.localScale = Vector3.one * size;
        asteroid_body.velocity = transform.forward * speed;
        // asteroid_body.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update(){
        
    }
}
