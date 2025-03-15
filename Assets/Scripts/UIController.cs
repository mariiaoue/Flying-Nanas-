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

    public GameObject player;
    public GameObject SoundOn;
    public GameObject SoundOff;

    public GameObject StartMenuCanvas;

    public GameObject HowToPlayCanvas;
    public GameObject PauseCanvas;
    public GameObject ChooseGemCanvas;

    public GameObject CharctersCanvas;

    public GameObject backstory1;
    public GameObject backstory2;

    public TextMeshProUGUI Score;

  


   

   public void HowToPlayClick()
   {
       FindObjectOfType<AudioManager>().Play("ButtonClick");
      
      ScoreCanvas.SetActive(false);
      
      StartMenuCanvas.SetActive(false);
      HowToPlayCanvas.SetActive(true);
      

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


  

   public void BackstoryNext()
   {
      backstory1.SetActive(false);
      backstory2.SetActive(true);
   }

   public void BackstoryMainMenu()
   {
      HowToPlayCanvas.SetActive(false);
      StartMenuCanvas.SetActive(true);
      backstory1.SetActive(true);
      backstory2.SetActive(false);
   }

   public void StartMenuCanvasPlayButton()
   {
      StartMenuCanvas.SetActive(false);
      ChooseGemCanvas.SetActive(true);
   }

 


   public void CancelPauseClick()
   {
       FindObjectOfType<AudioManager>().Play("ButtonClick");
      

      Time.timeScale = 1;
      PauseCanvas.SetActive(false);
      ScoreCanvas.SetActive(true);
      
    
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
