using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
     {
        
        Score.score++;
        FindObjectOfType<AudioManager>().Play("scored");
        Destroy(gameObject);
     }
}
