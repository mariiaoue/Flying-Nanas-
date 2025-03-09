using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;



public class gameManager : MonoBehaviour
{
   public GameObject gameOverCanvas;
   public GameObject StartMenuCanvas;
   public GameObject TapToPlay;
   public GameObject ScoreCanvas;
   public GameObject player;
   public GameObject ObstaclesSpawner;

   public GameObject youlose;
   public GameObject youwin;

   public TextMeshProUGUI timerText; // this for countdown display
   public TextMeshProUGUI Score; 
   private float countdownTime = 120f; // 2 minutes (120 seconds)
   private bool isCounting = false; 


   public CinemachineVirtualCamera camera1;
   public CinemachineVirtualCamera camera2;
   public CinemachineVirtualCamera camera3;
   
   //public GameObject jumpButtonCanvas;
  

    private void Start(){
        Time.timeScale = 1;
    }

    void Awake()
     {

        int replay = PlayerPrefs.GetInt("replay");
        if(replay == 1){
        camera1.Priority = 5;
        camera2.Priority = 10;
        camera2.Priority = 5;
       
        StartMenuCanvas.SetActive(false);
        TapToPlay.SetActive(true);
        ScoreCanvas.SetActive(true);
        
        player.transform.rotation = Quaternion.identity;
        player.GetComponent<PlayerController>().enabled = true;
        
        PlayerPrefs.SetInt("replay",0);
        ObstaclesSpawner.SetActive(true);
        StartCoroutine(StartCountdown());
       
       
        
        }
        
        
     }


   public void GameOver(){
    
    Invoke("GameOverDelayed",0.5f);
    
   }

   public void GameOverDelayed()
   {
      gameOverCanvas.SetActive(true);
      ScoreCanvas.SetActive(false);
      youlose.SetActive(true);
      Time.timeScale = 0;
      
   }

   public void Replay()
   {
    PlayerPrefs.SetInt("replay",1);
    FindObjectOfType<AudioManager>().Play("ButtonClick");
    SceneManager.LoadScene(0);
   }

   public void PlayFirstTime()
   {
        camera1.Priority = 5;
        camera2.Priority = 10;
        camera3.Priority = 5;
       
        StartMenuCanvas.SetActive(false);
        TapToPlay.SetActive(true);
        ScoreCanvas.SetActive(true);
        ObstaclesSpawner.SetActive(true);
 
     
        player.transform.rotation = Quaternion.identity;
        player.GetComponent<PlayerController>().enabled = true;
        
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        StartCoroutine(StartCountdown());

        PlayerPrefs.SetInt("replay",0);
   }

   private IEnumerator StartCountdown()
   {
      isCounting = true;
      while (countdownTime > 0)
      {
         int minutes = Mathf.FloorToInt(countdownTime / 60);
         int seconds = Mathf.FloorToInt(countdownTime % 60);
         timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

         yield return new WaitForSeconds(1f);
         countdownTime--;
      }

      GameOverFinishTime(); // Calls game over after time runs out
   }

   public void GameOverFinishTime()
   {
      
      int score = int.Parse(Score.text);

      if(score > 49)
      {
         gameOverCanvas.SetActive(true);
         ScoreCanvas.SetActive(false);
         youwin.SetActive(true);
      }else{
        gameOverCanvas.SetActive(true);
        ScoreCanvas.SetActive(false);
        youlose.SetActive(true);
      }
      Time.timeScale = 0;
      
   }

}
