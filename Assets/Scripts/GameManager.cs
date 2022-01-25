using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    public Player player;
    private int lives = 3;
    private int score;
    private int stageLevel = 1;
    public Text scoreValue;
    public Text GameOverText;
    public Text PlayerDiedText;
    public Text RespawnText;
    public Text NewGameText;
    public Text LivesText;
    public Text GameExitText;
    public Text ContinueText;
    public Text StageLevelText;
    public Text StageText;


    void Start(){
         toggleText();
         UpdateLives(this.lives);
         UpdateStage(this.stageLevel);
         // this.asteroidNumber = FindObjectOfType<AsteroidSpawner>().getNumberAsteroids();
         // Debug.Log("asteroids: " + FindObjectOfType<AsteroidSpawner>().getNumberAsteroids());
         // UpdateAsteroids(this.asteroidNumber);
    }

    
    void Update(){
        
    }

    private void UpdateScore(int score){
        this.score = score;
        this.scoreValue.text = score.ToString();
    }

    private void UpdateLives(int lives){
        this.lives = lives;
        this.LivesText.text = lives.ToString();
    }

    private void UpdateStage(int level){
        this.stageLevel = level;
        this.StageLevelText.text = stageLevel.ToString();
    }


    public void AsteroidDestroyed(Asteroid asteroid){
        if(asteroid.size > 20f)
            UpdateScore(this.score + 50);
        else if (asteroid.size > 40f)
            UpdateScore(this.score + 70);
        else
            UpdateScore(this.score + 100);
    }

    public int PlayerDied(){
        UpdateLives(this.lives - 1);
        if(this.lives <= 0){
            GameOver();
        }
        else{
            this.PlayerDiedText.enabled = true;
            this.RespawnText.enabled = true;
        }
        return this.lives;
    }

    private void GameOver(){
        this.GameOverText.enabled = true;
        this.NewGameText.enabled = true;
    }

    public void Respawn(){
        toggleText();
    }

    public void NewGame(){
        SetScore(0);
        SetLives(3);
        toggleText();
    }

    public void ExitGame(){
        this.GameExitText.enabled = true;
        this.ContinueText.enabled = true;
        if (Input.GetKey(KeyCode.C)){
            Application.Quit();
        }
        else if (Input.anyKey){
            toggleText();
        }
    }

    public void StageLevelUp(){
        UpdateStage(this.stageLevel + 1);
        toggleText();
    }

    private void SetLives(int lives){
        this.lives = lives;
    }

    private void SetScore(int score){
        this.score = score;
    }

    private void disableStage(){
        this.StageLevelText.enabled = false;
        this.StageText.enabled = false;
    }

    // public void setAsteroids(int asteroidNumber){
    //     this.asteroidNumber = asteroidNumber;
    // }

    private void toggleText(){
        this.GameOverText.enabled = false;
        this.PlayerDiedText.enabled = false;
        this.RespawnText.enabled = false;
        this.NewGameText.enabled = false;
        this.GameExitText.enabled = false;
        this.ContinueText.enabled = false;
        this.StageLevelText.enabled = true;
        this.StageText.enabled = true;
        Invoke("disableStage", 3);
    }
}
