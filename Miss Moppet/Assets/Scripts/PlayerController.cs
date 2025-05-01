using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public InputActionReference jump;
    public bool grounded = true;
    public GameObject deathScreen;
    
    private Rigidbody _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            animator.SetTrigger("Jump");
            grounded = false;
        }
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
        Destroy(gameObject);        deathScreen.SetActive(true);

    }
}