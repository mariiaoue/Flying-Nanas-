using UnityEngine;
using GG.Infrastructure.Utils.Swipe;
using TMPro;
using System.Collections; // Needed for coroutine
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 5f;
    private float timeElapsed = 0f;
    public float speedIncreaseRate = 0.1f;
    public float laneChangeSpeed = 10f;
    public float laneDistance = 2f;

    private Rigidbody rb;
    private int currentLaneX = 1;
    private int currentLaneY = 1;
    private Vector3 targetPosition;

    public Animator anim1;
    public Animator anim2;
    public Animator anim3;

    private bool isLeft = true;

    public SwipeListener swipeListener;
    public gameManager gamemanager;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI GameOverScore;
    public TextMeshProUGUI YouwinScore;

    private float startZPosition;
    private float distance;

    // Speed Boost Variables
    public float boostMultiplier = 2f; // Speed increase factor
    public float boostDuration = 2f; // How long the boost lasts
    private bool isBoosting = false;
    private int lives = 3; // Player starts with 3 lives
    public Image[] lifeStars; // Assign the 3 star images in the Inspector

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; 
        rb.isKinematic = false;
        targetPosition = transform.position;
    
        anim1.SetTrigger("Start");
        anim2.SetTrigger("Start");
        anim3.SetTrigger("Start");
        startZPosition = transform.position.z;
    }

    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    private void OnSwipe(string swipe)
    {
        switch (swipe)
        {
            case "Left":
                if (currentLaneX > 0)
                {
                    FindObjectOfType<AudioManager>().Play("Swipe");
                    currentLaneX--;
                    isLeft = true;
                    UpdateTargetPosition();
                }
                break;
            case "Right":
                if (currentLaneX < 2)
                {
                    FindObjectOfType<AudioManager>().Play("Swipe");
                    currentLaneX++;
                    isLeft = false;
                    UpdateTargetPosition();
                }
                break;
            case "Up":
                if (currentLaneY < 2)
                {
                    FindObjectOfType<AudioManager>().Play("Swipe");
                    currentLaneY++;
                    UpdateTargetPosition();
                }
                break;
            case "Down":
                if (currentLaneY > 0)
                {
                    FindObjectOfType<AudioManager>().Play("Swipe");
                    currentLaneY--;
                    UpdateTargetPosition();
                }
                break;
        }
    }

    void Update()
    {
        

        // Speed Boost Activation
        if (Input.GetKeyDown(KeyCode.Space) && !isBoosting)
        {
            StartCoroutine(SpeedBoost());
        }

        // Automatic running
        transform.position += transform.forward * runSpeed * Time.deltaTime;

        // Smoothly move to the target lane position using Lerp
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

        // Calculate the distance traveled
        distance = transform.position.z - startZPosition;

        // make the player faster each 20 sec
        timeElapsed += Time.deltaTime;
       if (timeElapsed >= 20f)
        {
        runSpeed += 5f;
        timeElapsed = 0f; // Reset timer
          }


        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
    {
        OnSwipe("Left");
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
    {
        OnSwipe("Right");
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
    {
        OnSwipe("Up");
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
    {
        OnSwipe("Down");
    }
    }

    IEnumerator SpeedBoost()
    {
        isBoosting = true;
        float originalSpeed = runSpeed;
        runSpeed *= boostMultiplier; // Apply speed boost

        yield return new WaitForSeconds(boostDuration); // Wait for boost duration

        runSpeed = originalSpeed; // Reset speed
        isBoosting = false;
    }

    void UpdateTargetPosition()
    {
        targetPosition = new Vector3((currentLaneX - 1) * laneDistance, (currentLaneY - 1) * laneDistance, transform.position.z);
    }

    void OnCollisionEnter(Collision col)
{
    if (col.gameObject.CompareTag("Obstacle"))
    {
        lives--; // Reduce a life
        FindObjectOfType<AudioManager>().Play("death");

        if (lives >= 0 && lives < lifeStars.Length)
            {
                Destroy(lifeStars[lives].gameObject);
            }

        if (lives > 0)
        {
            // Reset player instead of ending game
            //ResetPlayer();
            Destroy(col.gameObject);
        }
        else
        {
            // Game Over when lives reach zero
            rb.isKinematic = true;
            Dashboard();
            gamemanager.GameOver();
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }
}

    public void Dashboard()
    {
        
        GameOverScore.text = Score.text + " gems";
        YouwinScore.text = Score.text + " gems";
    }
}
