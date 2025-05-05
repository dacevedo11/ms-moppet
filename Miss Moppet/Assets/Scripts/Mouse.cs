using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float runSpeed = 10f;
    void FixedUpdate()
    {
        Vector3 sidewaysMove = transform.right * runSpeed;
        transform.position += sidewaysMove * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }
    }
}