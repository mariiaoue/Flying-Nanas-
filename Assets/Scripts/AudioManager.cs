using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public GameObject SoundOn;
    public GameObject SoundOff;
    private GameObject BackgroundSong;
    void Awake()
    {
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

  
}
