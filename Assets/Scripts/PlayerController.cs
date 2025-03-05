using UnityEngine;
using GG.Infrastructure.Utils.Swipe;
using TMPro;
using System.Collections; // Needed for coroutine
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 5f;
    public float maxRunSpeed = 15f;
    public float speedIncreaseRate = 0.1f;
    public float laneChangeSpeed = 10f;
    public float laneDistance = 2f;

    private Rigidbody rb;
    private int currentLaneX = 1;
    private int currentLaneY = 1;
    private Vector3 targetPosition;

    public Animator anim1;
    public Animator anim2;
    private bool isLeft = true;

    public SwipeListener swipeListener;
    public gameManager gamemanager;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI GameOverBestScore;
    public TextMeshProUGUI GameOverScore;

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
        // Gradually increase speed over time, capped at maxRunSpeed
        runSpeed = Mathf.Min(maxRunSpeed, runSpeed + speedIncreaseRate * Time.deltaTime);

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

            if (isLeft)
            {
                anim1.SetBool("DeathRight", true);
                anim2.SetBool("DeathRight", true);
            }
            else
            {
                anim1.SetBool("DeathLeft", true);
                anim2.SetBool("DeathLeft", true);
            }
        }
    }
}

    public void Dashboard()
    {
        int First = PlayerPrefs.GetInt("HighestScore");
        if (int.Parse(Score.text) > First)
        {
            PlayerPrefs.SetInt("HighestScore", int.Parse(Score.text));
        }
        int Best = PlayerPrefs.GetInt("HighestScore");
        BestScore.text = Best.ToString();
        GameOverBestScore.text = Best.ToString();
        GameOverScore.text = Score.text;
    }
}
