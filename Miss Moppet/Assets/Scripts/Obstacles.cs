using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 5f;
    
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
