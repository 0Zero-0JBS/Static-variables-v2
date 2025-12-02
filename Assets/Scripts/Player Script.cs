using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScript : MonoBehaviour
{
    public int playerHealth;
    private Vector3 startPosition;
    public int startHealth = 3;
    private int currentHealth;
    public Rigidbody body;
    float xv, zv;
    bool isGrounded;
    LayerMask groundLayerMask;
    AudioSource audioSource;
    public AudioClip sfx1;  // sound effect asset from sfx folder 
    public int playerScore = 0; //This is the player's score.
    public int highScore = 1000;
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = startHealth;

        body = GetComponent<Rigidbody>();

        // set the mask to be "Ground"
        groundLayerMask = LayerMask.GetMask("Ground");
        playerHealth = 3;

        startPosition = transform.position;
        currentHealth = startHealth;

        LevelManagerScript.instance.SetHighScore(50);

        audioSource = GetComponent<AudioSource>();

        // Before reading the key, check to see if a value has been stored in it.
        if (PlayerPrefs.HasKey("High_score") == true)
        {
            // the key musicVol holds a value, therefore we can
            //retrieve it and store it in a variable
            highScore = PlayerPrefs.GetInt("High_score");
        }
        else
        {
            // the key musicVol is null so give it a default value of 0.5f
            PlayerPrefs.SetInt("High_score", 1000);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float xvel;
        float zvel;

        xvel = body.linearVelocity.x;
        zvel = body.linearVelocity.z;

        if (Input.GetKey("d"))
        {
            xvel = 5;
        }

        if (Input.GetKey("a"))
        {
            xvel = -5;
        }

        if (Input.GetKey("w"))
        {
            zvel = 5;
        }

        if (Input.GetKey("s"))
        {
            zvel = -5;
        }

        body.linearVelocity = new Vector3(xvel, 0, zvel);

        if (Input.GetKey("+"))
        {
            playerScore += 10;
        }

        if (Input.GetKey("-"))
        {
            playerScore -= 10;
        }

        
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    public void ResetPlayer()
    {
        transform.position = startPosition; // Reset position
        currentHealth = startHealth;        // Reset health
        // Add other reset logic here (e.g., reset score in UI)
        Debug.Log("Player has been reset!");
    }

    public void RestartLevel()
    {
        // Get the index of the current open scene and reload it
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlaySoundEffect()
    {
        audioSource.PlayOneShot(sfx1, 0.7f); // play audio clip with volume 0.7
    }
    static void Main(string[] args)
    {
        Console.Title = "Player score: ";

        string input;

        int[] 
    }
}
