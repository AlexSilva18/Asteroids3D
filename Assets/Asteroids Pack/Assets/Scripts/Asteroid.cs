using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour{
    
    private Rigidbody asteroid_body;
    public float size;
    public float minSize = 2000f;
    public float maxSize = 4000f;
    public float speed;
    public float minSpeed = 20f;
    public float maxSpeed = 40f;
    private List<Asteroid> halves = new List<Asteroid>();
    // private float speed = 10f;

    private void Awake(){
        asteroid_body = GetComponent<Rigidbody>();
    }


    void Start(){
        this.transform.localScale = Vector3.one * size;
        asteroid_body.velocity = transform.forward * speed;
        // asteroid_body.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Laser"){
            if(this.size >= this.minSize){
                CreateSplit();
                // CreateSplit();
                // score += 10;
            }
            // score += 5;
            FindObjectOfType<AsteroidSpawner>().removeAsteroid(this);
            Destroy(this.gameObject);
            FindObjectOfType<AsteroidSpawner>().UpdateAsteroids();
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
        }
    }

    private void CreateSplit(){
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.8f; 

        Asteroid half1 = Instantiate(this, this.transform.position, this.transform.rotation);
        Asteroid half2 = Instantiate(this, this.transform.position, this.transform.rotation);
        half1.size = this.size * 0.5f;
        half2.size = this.size * 0.5f;
        half1.speed = UnityEngine.Random.Range(half1.minSpeed, half1.maxSpeed);
        half2.speed = UnityEngine.Random.Range(half2.minSpeed, half2.maxSpeed);
        FindObjectOfType<AsteroidSpawner>().addAsteroid(new Asteroid[]{half1, half2});
        // halves.Add(half);
        // halves[(halves.length-1)].transform.parent = this.transform;

    }

}
