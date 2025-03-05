using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public GameObject SoundOn;
    public GameObject SoundOff;
    private GameObject BackgroundSong;
    public Slider mSlider;
    private AudioSource m_MyAudioSource;
    void Awake()
    {
      m_MyAudioSource = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
      BackgroundSong = GameObject.Find("BackgroundSong");

      int mute = PlayerPrefs.GetInt("mute");
       if(mute == 1)
       {
         BackgroundSong.SetActive(false);
       }
       if(mute == 0 || mute == null)
       {
         BackgroundSong.SetActive(true);
       }
  
        foreach (Sound s in sounds)
        {
          s.source = gameObject.AddComponent<AudioSource>();
          s.source.clip = s.clip;
          s.source.volume = s.volume;
          s.source.pitch = s.pitch;
          s.source.loop = s.loop;

        }

    }

    void Start()
    {
       float x = PlayerPrefs.GetFloat("volumeisnull");
       Debug.Log("volume ="+x);
      if(x == 0){
         PlayerPrefs.SetFloat("volume",1);
         PlayerPrefs.SetFloat("volumeisnull",1);
      }else{
        mSlider.value = PlayerPrefs.GetFloat("volume");
      }
      AudioChanger();
    }



    
   public void Play(string name){
     int mute = PlayerPrefs.GetInt("mute");
     if(mute == 0 || mute == null)
     {
      Sound s =  Array.Find(sounds, sound => sound.name == name);
      s.source.Play(); 
     }
      

   }

   public void MuteAudio()
   {
       int mute = PlayerPrefs.GetInt("mute");
       if(mute == 1)
       {
         PlayerPrefs.SetInt("mute",0);
         SoundOn.SetActive(true);
         SoundOff.SetActive(false);
         BackgroundSong.SetActive(true);

       }
       if(mute == 0 || mute == null)
       {
         PlayerPrefs.SetInt("mute",1);
         SoundOn.SetActive(false);
         SoundOff.SetActive(true);
         BackgroundSong.SetActive(false);
       }
        mute = PlayerPrefs.GetInt("mute");
       
   }


   public void AudioChanged()
   {

    foreach (Sound s in sounds)
        {
         
         
          s.source.volume = mSlider.value;
          m_MyAudioSource.volume = mSlider.value;
          PlayerPrefs.SetFloat("volume", mSlider.value);
          
        }

   }

   private void AudioChanger()
   {

    foreach (Sound s in sounds)
        {
         
         mSlider.value = PlayerPrefs.GetFloat("volume"); 
          s.source.volume = mSlider.value;
          m_MyAudioSource.volume = mSlider.value;
          
        }

   }

  
}
