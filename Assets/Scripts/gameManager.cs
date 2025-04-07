using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;



public class gameManager : MonoBehaviour
{
   public GameObject gameOverCanvas;
   public GameObject youwinCanvas;
   public GameObject StartMenuCanvas;
   public GameObject ChooseGemCanvas;

   public GameObject ScoreCanvas;
   public GameObject player;
   public GameObject ObstaclesSpawner;

   public TextMeshProUGUI timerText; // this for countdown display
   public TextMeshProUGUI Score; 
   private float countdownTime = 120f; // 2 minutes (120 seconds)
   private bool isCounting = false; 


   public AudioClip loosingClip; // Assign this in the inspector
   public AudioClip winClip; // Assign this in the inspector
   public AudioClip background_music; // Assign this in the inspector
   private AudioSource audioSource;



   
   //public GameObject jumpButtonCanvas;
  

    private void Start(){
        Time.timeScale = 1;
         audioSource = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
         audioSource.clip = background_music;
          audioSource.Play();
    }

    void Awake()
     {

        int replay = PlayerPrefs.GetInt("replay");
        if(replay == 1){

       
        StartMenuCanvas.SetActive(false);
       
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
      ScoreCanvas.SetActive(false);
      Time.timeScale = 0;
      GameOverFinishTime();
   }

   public void Replay()
   {
    PlayerPrefs.SetInt("replay",1);
    FindObjectOfType<AudioManager>().Play("ButtonClick");
    audioSource.clip = background_music;
    audioSource.Play();
    SceneManager.LoadScene(0);
   }

   public void PlayFirstTime()
   {
   
        ChooseGemCanvas.SetActive(false);

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

      if(score < 100)
      {
         gameOverCanvas.SetActive(true);
         ScoreCanvas.SetActive(false);
         audioSource.clip = loosingClip;
         audioSource.Play();
         
      }else{
        youwinCanvas.SetActive(true);
        ScoreCanvas.SetActive(false);
        audioSource.clip = winClip;
        audioSource.Play();
       
      }
      Time.timeScale = 0;
      
   }

}
