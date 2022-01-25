using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidSpawner : MonoBehaviour{

    // public GameObject Asteroid;
    public Asteroid asteroidPrefab;
    public float spawnRate = 1.0f;
    private Vector3 spawnPoint;
    private float spawnRange = 100;
    public float startSafeRange;
    public float trajectoryVariance = 15.0f;
    private List<Asteroid> objectsToPlace = new List<Asteroid>();
    private float amountToSpawn = 10;
    private int asteroidNumber;
    public Text AsteroidNumberText;
    public Text AsteroidText;
    
    
    void Start(){
        Init();
    }

    void Init(){
        for (int i = 0; i < amountToSpawn; i++){
            PickSpawnPoint();

            //pick new spawn point if too close to player start
            while (Vector3.Distance(spawnPoint, Vector3.zero) < startSafeRange){
                PickSpawnPoint();
            }
            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, Quaternion.Euler(Random.Range(0f,360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
            objectsToPlace.Add(asteroid);

            // float variance = UnityEngine.Random.Range(-this.trajectoryVariance, this.trajectoryVariance);      
            // Vector3 spawnDirection = UnityEngine.Random.insideUnitCircle.normalized * spawnPoint;
            // Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            asteroid.size = UnityEngine.Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.speed = UnityEngine.Random.Range(asteroid.minSpeed, asteroid.maxSpeed);
            // asteroid.SetTrajectory(rotation * -spawnDirection);
        }
        // Debug.Log("objects: " + objectsToPlace.Count);
        this.asteroidNumber = objectsToPlace.Count;
        UpdateAsteroids();
        // UpdateAsteroids(objectsToPlace.Count);
        // FindObjectOfType<GameManager>().setAsteroids(objectsToPlace.Count);
        // asteroid2.SetActive(false);
    }

    public void setAmountToSpawn(int spawnAmount){
        this.amountToSpawn = spawnAmount;
    }

    public void UpdateAsteroids(){
        int asteroidsNum = objectsToPlace.Count;
        this.asteroidNumber = asteroidsNum;
        this.AsteroidNumberText.text = asteroidNumber.ToString();
        if (this.asteroidNumber == 0){
            FindObjectOfType<Player>().StageLevelUp();
            // FindObjectOfType<GameManager>().AsteroidDestroyed(this);
        }
    }

    public void addAsteroid(Asteroid[] asteroids){
        objectsToPlace.AddRange(asteroids);
        // objectsToPlace.Add(asteroid2);
        // UpdateAsteroids(this.asteroidNumber + 1);
        // Debug.Log("AddTotal: " + (this.asteroidNumber + 1));
        // FindObjectOfType<GameManager>().setAsteroids(getNumberAsteroids());
        // objectsToPlace[i].transform.parent = this.transform;
    }

    public void removeAsteroid(Asteroid asteroid){
        objectsToPlace.Remove(asteroid);
        // UpdateAsteroids(this.asteroidNumber - 1);
        // Debug.Log("DesTotal: " + (this.asteroidNumber - 1));
    }

    // private void setNumberAsteroids(int asteroidNumber){
    //     this.asteroidNumber = asteroidNumber;
    //     UpdateAsteroids()this.asteroidNumber;
    //     Debug.Log("#: " + this.asteroidNumber);
    // }

    public int getNumberAsteroids(){
        return this.asteroidNumber;
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
