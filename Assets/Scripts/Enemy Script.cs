using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public static int enemyHealth = 0;
    public float moveSpeed = 4f;
    public Rigidbody rb;
    bool isGrounded;
    public float speed;
    LayerMask groundLayerMask;
    public Transform respawnPoint;
    private PlayerScript playerHealth;
    public int damage = 1;
    AudioSource audioSource;
    public AudioClip sfx1;  // sound effect asset from sfx folder 

    public EnemyScript()
    {
        enemyHealth++;
    }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        groundLayerMask = LayerMask.GetMask("Ground");
        
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = false;

        if (collision.gameObject.tag == "Player")
        {
            if(playerHealth == null)
            {
                playerHealth = collision.gameObject.GetComponent<PlayerScript>();
            }
            playerHealth.TakeDamage(damage);
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Player.transform.position = respawnPoint.position;
            other.transform.position = respawnPoint.position;
        }
    }
    void PlaySoundEffect()
    {
        audioSource.PlayOneShot(sfx1, 0.7f); // play audio clip with volume 0.7
    }

}
