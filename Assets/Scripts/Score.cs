using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public static int score = 0;
    public TextMeshProUGUI YouwinScore;
    private GameObject player;
    private Rigidbody rb;
    public gameManager gamemanager;
  
   
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();

        if (score > 99)
    {
            rb.isKinematic = true;
            YouwinScore.text = score.ToString() + " gems";
            gamemanager.GameOver();
            player.GetComponent<PlayerController>().enabled = false;
    }
    
    }
}
