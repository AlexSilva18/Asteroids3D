using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour{

    // public GameObject Asteroid;
    public Asteroid asteroidPrefab;
    public float spawnRate = 1.0f;
    private Vector3 spawnPoint;
    private float spawnRange = 300;
    public float startSafeRange;
    public float trajectoryVariance = 15.0f;
    private List<Asteroid> objectsToPlace = new List<Asteroid>();
    private float amountToSpawn = 50;
    
    
    void Start(){

        for (int i = 0; i < amountToSpawn; i++){
            PickSpawnPoint();

            //pick new spawn point if too close to player start
            while (Vector3.Distance(spawnPoint, Vector3.zero) < startSafeRange){
                PickSpawnPoint();
            }
            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, Quaternion.Euler(Random.Range(0f,360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
            objectsToPlace.Add(asteroid);
            objectsToPlace[i].transform.parent = this.transform;

            float variance = UnityEngine.Random.Range(-this.trajectoryVariance, this.trajectoryVariance);      
            Vector3 spawnDirection = UnityEngine.Random.insideUnitCircle.normalized * spawnPoint;
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            asteroid.size = UnityEngine.Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.speed = UnityEngine.Random.Range(asteroid.minSpeed, asteroid.maxSpeed);
            // asteroid.SetTrajectory(rotation * -spawnDirection);
        }

        // asteroid2.SetActive(false);
    }

    private void Spawn(){

    }

    public void PickSpawnPoint(){
        spawnPoint = new Vector3(
            Random.Range(-1f,1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f));

        if(spawnPoint.magnitude > 1)
        {
            spawnPoint.Normalize();
        }

        spawnPoint *= spawnRange;
    }

    // Update is called once per frame
    void Update(){
        
    }
}
