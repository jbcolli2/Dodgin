using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    private Vector2 positionDelta = new Vector2(0, 0);
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        positionDelta.x = Input.GetAxis("Horizontal") * speed;
        positionDelta.y = Input.GetAxis("Vertical") * speed;
    }


    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position += positionDelta * Time.deltaTime;
        transform.position = position;
    }
}
