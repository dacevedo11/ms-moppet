using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public InputActionReference jump;
    public bool grounded = true;
    public float runSpeed = 5f;
    public GameObject deathParticles;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
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
        if (other.CompareTag("Obstacles"))
        {
            HandleDeath();
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