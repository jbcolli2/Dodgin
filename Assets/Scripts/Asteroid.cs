using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 1.0f;


    void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.y -= fallSpeed * Time.deltaTime;
        transform.position = position;
    }
    
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
