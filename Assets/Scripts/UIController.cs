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
    public GameObject BirdChangerCanvas;
    public GameObject StartMenuCanvas;
    public GameObject CreditCanvas;
    public GameObject HowToPlayCanvas;
    public GameObject PauseCanvas;
    public GameObject LevelsCanvas;
    public GameObject CharctersCanvas;

    public Button level1;
    public Button level2;

    public GameObject GroundLevel1;
    public GameObject GroundLevel2;

    public GameObject DashboardContainer;
    public GameObject DashboardCancelButton;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI Level3ButtonText;

    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;
    public CinemachineVirtualCamera camera3;
    public CinemachineVirtualCamera camera4;
    public CinemachineVirtualCamera camera5;
   public GameObject stones;



   public GameObject PlayerNameCanvas;
    public TextMeshProUGUI PlayerNameText;

    public TMP_InputField inputField;
    public TMP_InputField MoreinputField;
    public TextMeshProUGUI MorePlayerNameText;


  void Start()
  {
    int level1 = PlayerPrefs.GetInt("Level");
    if(level1 == 0 || level1 == null)
    {
    level1 = 2;
    }
    if(level1 == 1)
    {
          GroundLevel1.SetActive(true);
          GroundLevel2.SetActive(false);
        
    }
    if(level1 == 2)
    {
          GroundLevel1.SetActive(false);
          GroundLevel2.SetActive(true);
       
    }
    

  }


  public void PlayerNameSelect()
  {
    
   camera4.Priority = 0;
   string player1Name = PlayerNameText.text;
   player.SetActive(true);
      if (string.IsNullOrWhiteSpace(inputField.text))
   { 
       FindObjectOfType<AudioManager>().Play("ClickErroe");
   }
    else
    {
       PlayerPrefs.SetString("playerName", PlayerNameText.text);
       PlayerPrefs.SetInt("firstTry",1);
        PlayerNameCanvas.SetActive(false);
        StartMenuCanvas.SetActive(true);
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }
    
  } 

   

   public void HowToPlayClick()
   {
       FindObjectOfType<AudioManager>().Play("ButtonClick");
      

      GameOverCanvas.SetActive(false);
      ScoreCanvas.SetActive(false);
      
      StartMenuCanvas.SetActive(false);
      HowToPlayCanvas.SetActive(true);

      camera1.Priority = 10;
      camera2.Priority = 5;
      stones.SetActive(false);
    
    
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
      MoreinputField.text = PlayerPrefs.GetString("playerName");
     
   }

   public void MorePlayerNameSelect()
  {
  
   string player1Name = MorePlayerNameText.text;

      if (string.IsNullOrWhiteSpace(MoreinputField.text))
   { 
       FindObjectOfType<AudioManager>().Play("ClickErroe");
   }
    else
    {
       PlayerPrefs.SetString("playerName", MorePlayerNameText.text);
      // PlayerPrefs.SetInt("firstTry",1);
       // PlayerNameCanvas.SetActive(false);
        //StartMenuCanvas.SetActive(true);
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }
    
  } 

   public void DashboardClick()
   {
      camera1.Priority = 5;
      camera2.Priority = 5;
      camera3.Priority = 10;
   
      GameOverCanvas.SetActive(false);
      DashboardCancelButton.SetActive(true);
      DashboardContainer.SetActive(true);
      ScoreCanvas.SetActive(false);
      StartMenuCanvas.SetActive(false);
      FindObjectOfType<AudioManager>().Play("ButtonClick");
   }

   public void CharactersClick()
   {
      
      camera5.Priority = 20;
      CharctersCanvas.SetActive(true);
      StartMenuCanvas.SetActive(false);
      FindObjectOfType<AudioManager>().Play("ButtonClick");
   }

   public void CancelDashboardClick()
   {
     
      camera1.Priority = 5;
      camera2.Priority = 10;
      camera3.Priority = 5;

      DashboardCancelButton.SetActive(false);
      DashboardContainer.SetActive(false);
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
      stones.SetActive(true);

      camera1.Priority = 5;
      camera2.Priority = 10;
      camera3.Priority = 5;
      camera5.Priority = 0;
      
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

    public void LevelsClick()
    {
      FindObjectOfType<AudioManager>().Play("ButtonClick");
      GameOverCanvas.SetActive(false);
      ScoreCanvas.SetActive(false);
      player.SetActive(false);
      StartMenuCanvas.SetActive(false);
      CreditCanvas.SetActive(false);
      LevelsCanvas.SetActive(true);
      int Best = PlayerPrefs.GetInt("HighestScore");
      Score.text = Best.ToString();
      int challengesCompleted = PlayerPrefs.GetInt("challengeCompleted", 0);
      Level3ButtonText.text = $"LEVEL3\n{challengesCompleted}/10 Completed";

      int level = PlayerPrefs.GetInt("Level");
      if(level == 0 || level == null)
      {
        level = 1;
      }
      if(level == 1)
      {
         level1.interactable = false;
         level2.interactable = true;
        
      }
      if(level == 2)
      {
         level1.interactable = true;
         level2.interactable = false;
    
      }
      if(level == 3)
      {
         level1.interactable = true;
         level2.interactable = true;
     
      }

      
    }

    public void CancelLevelsClick()
    {
      FindObjectOfType<AudioManager>().Play("ButtonClick");
      GameOverCanvas.SetActive(false);
      ScoreCanvas.SetActive(false);
      player.SetActive(true);
      StartMenuCanvas.SetActive(true);
      CreditCanvas.SetActive(false);
      LevelsCanvas.SetActive(false);
    }
     
     public void Level1Click()
    {
        level1.interactable = false;
         level2.interactable = true;

         GroundLevel1.SetActive(true);
         GroundLevel2.SetActive(false);
        
         PlayerPrefs.SetInt("Level",1);
    }

    public void Level2Click()
    {
      int Best = PlayerPrefs.GetInt("HighestScore");
      if(Best >= 500){
        level1.interactable = true;
         level2.interactable = false;
   
         GroundLevel1.SetActive(false);
         GroundLevel2.SetActive(true);
      
          PlayerPrefs.SetInt("Level",2);
      }
    }

    public void Level3Click()
    {
      int Best = PlayerPrefs.GetInt("HighestScore");
      if(PlayerPrefs.GetInt("challengeCompleted") >= 10){
        level1.interactable = true;
         level2.interactable = true;
      
         GroundLevel1.SetActive(false);
         GroundLevel2.SetActive(false);
       
         PlayerPrefs.SetInt("Level",3);
      }
    }

 



}
