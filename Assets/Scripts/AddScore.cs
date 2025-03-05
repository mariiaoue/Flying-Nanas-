using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
     {
        
        Score.score++;
        int total = PlayerPrefs.GetInt("TotalScore");
        total ++;
         PlayerPrefs.SetInt("TotalScore",total );
        FindObjectOfType<AudioManager>().Play("scored");
        Destroy(gameObject);
     }
}
