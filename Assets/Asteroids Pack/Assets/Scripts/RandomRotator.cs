using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour{
    [SerializeField]
    private float tumble;
    private Rigidbody asteroid_body;
    

    void Start(){
    	asteroid_body = GetComponent<Rigidbody>();

        asteroid_body.angularVelocity = Random.insideUnitSphere * tumble;
        
    }
}