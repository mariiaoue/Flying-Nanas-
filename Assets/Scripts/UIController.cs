using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class UIController : MonoBehaviour
{
    public GameObject GameOverCanvas;
   

    public GameObject ScoreCanvas;
    public GameObject MoreCanvas;
    public GameObject player;
    public GameObject SoundOn;
    public GameObject SoundOff;

    public GameObject StartMenuCanvas;

    public GameObject HowToPlayCanvas;
    public GameObject PauseCanvas;

    public GameObject CharctersCanvas;

    public TextMeshProUGUI Score;


    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;
    public CinemachineVirtualCamera camera3;
  


   

   public void HowToPlayClick()
   {
       FindObjectOfType<AudioManager>().Play("ButtonClick");
      

      GameOverCanvas.SetActive(false);
      ScoreCanvas.SetActive(false);
      
      StartMenuCanvas.SetActive(false);
      HowToPlayCanvas.SetActive(true);
      
      camera1.Priority = 5;
      camera2.Priority = 10;
      camera3.Priority = 5;
      
    
    
   }

   public void PauseClick()
   {
       FindObjectOfType<AudioManager>().Play("ButtonClick");
      

      Time.timeScale = 0;
      
      

       FindObjectOfType<AudioManager>().Play("ButtonClick");
      int mute = PlayerPrefs.GetInt("mute");
      
       if(mute == 1)
       {
         SoundOn.SetActive(false);
         SoundOff.SetActive(true);
       }
       if(mute == 0 || mute == null)
       {
         SoundOn.SetActive(true);
         SoundOff.SetActive(false);
       }

      
      ScoreCanvas.SetActive(false);
      GameOverCanvas.SetActive(false);
      StartMenuCanvas.SetActive(false);
      PauseCanvas.SetActive(true);
     
   }


   public void MoreClick()
   {
    
       FindObjectOfType<AudioManager>().Play("ButtonClick");
      int mute = PlayerPrefs.GetInt("mute");
      
       if(mute == 1)
       {
         SoundOn.SetActive(false);
         SoundOff.SetActive(true);
       }
       if(mute == 0 || mute == null)
       {
         SoundOn.SetActive(true);
         SoundOff.SetActive(false);
       }

      
      ScoreCanvas.SetActive(false);
      GameOverCanvas.SetActive(false);
      StartMenuCanvas.SetActive(false);
      MoreCanvas.SetActive(true);
      
     
   }

  
   public void CharactersClick()
   { 
     
      CharctersCanvas.SetActive(true);
      StartMenuCanvas.SetActive(false);
      FindObjectOfType<AudioManager>().Play("ButtonClick");
      camera1.Priority = 5;
      camera2.Priority = 5;
      camera3.Priority = 10;
   }


   public void CancelPauseClick()
   {
       FindObjectOfType<AudioManager>().Play("ButtonClick");
      

      Time.timeScale = 1;
      PauseCanvas.SetActive(false);
      ScoreCanvas.SetActive(true);
      
    
   }


   public void CancelMoreClick()
   {
      FindObjectOfType<AudioManager>().Play("ButtonClick");
      int gameoverr = PlayerPrefs.GetInt("gameOver");
      if(gameoverr == 1)
      {
         GameOverCanvas.SetActive(true);
      
      }
      if(gameoverr == 0)
      {
         StartMenuCanvas.SetActive(true);
      }

      MoreCanvas.SetActive(false);


      player.SetActive(true);
    
      
   }

   public void CancelHowToPlayClick()
   {
      FindObjectOfType<AudioManager>().Play("ButtonClick");
      int gameoverr = PlayerPrefs.GetInt("gameOver");
      if(gameoverr == 1)
      {
         GameOverCanvas.SetActive(true);
      
      }
      if(gameoverr == 0)
      {
         StartMenuCanvas.SetActive(true);
      }

      HowToPlayCanvas.SetActive(false);
      CharctersCanvas.SetActive(false);


      player.SetActive(true);
     
      camera1.Priority = 10;
      camera2.Priority = 5;
      camera3.Priority = 5;
    
      
   }

   


   public void FromGameOverMrnu()
   {
       PlayerPrefs.SetInt("gameOver",1);
   }
   public void FromStartMenu()
   {
     PlayerPrefs.SetInt("gameOver",0);
   }

 
    public void Quit()
    {
      PlayerPrefs.SetInt("replay",0);
      FindObjectOfType<AudioManager>().Play("ButtonClick");
      SceneManager.LoadScene(0);
    }


    public void QuitGame()
    {
      Application.Quit();
    }



}
