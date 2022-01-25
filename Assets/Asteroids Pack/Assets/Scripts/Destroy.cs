using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour{
    
    public GameObject asteroidFragment;
    public Asteroid asteroid;
    private float maxLifetime = 10.0f;
    void Start(){
        asteroid = GetComponent<Asteroid>();
    }


    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Laser"){
            GameObject fragment = Instantiate(asteroidFragment, transform.position, this.transform.rotation);
            fragment.transform.localScale = Vector3.one * (asteroid.size / 600);
            Destroy(fragment.gameObject, this.maxLifetime);
        }
    }
}
