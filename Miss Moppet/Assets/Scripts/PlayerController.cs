using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public InputActionReference jump;
    public bool grounded = true;
    public float runSpeed = 5f;
    public GameObject deathParticles;
    public Canvas gameOverCanvas;
    public Canvas pressSpaceToJumpCanvas;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            if (pressSpaceToJumpCanvas != null)
            {
                pressSpaceToJumpCanvas.gameObject.SetActive(false);
                pressSpaceToJumpCanvas = null;
            }
            
            AudioManager.instance.PlayJumpSound();
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            animator.SetTrigger("Jump");
            grounded = false;
        }
    }
    
    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * runSpeed;
        rb.velocity = new Vector3(forwardMove.x, rb.velocity.y, forwardMove.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Crashing
        if (other.CompareTag("Obstacles"))
        {
            FindObjectOfType<GameManager>().ShowGameOver(0.5f);
            HandleDeath();
        }
        
        // Out of Bounds
        if (other.CompareTag("Bounds"))
        {
            AudioManager.instance.PlayDeathSound();
            FindObjectOfType<GameManager>().ShowGameOver(0f);
            Destroy(gameObject);
        }
    }

    private void HandleDeath()
    {
        AudioManager.instance.PlayDeathSound();
        AudioManager.instance.PlayExplosionSound();
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}