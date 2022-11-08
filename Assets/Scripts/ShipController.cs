using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private float speed = 7.0f;         // Speed at which the ship moves

    [SerializeField] 
    private int maxHealth = 10;
    [SerializeField] 
    private float maxHitDamage = 10.0f;
    private int health;      // Health of the ship

    [SerializeField] 
    private GameOverScreen gameOverScreen;
    
    [SerializeField] private TMPro.TMP_Text healthText;
    
    
    private Vector2 positionDelta = new Vector2(0, 0);

    private SpriteRenderer m_spriteRenderer = null;
    private float screenRight;
    private float screenLeft;
    private float screenBottom;
    [SerializeField]
    private float boundHeight = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthText.text = "Health: " + health;
        
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        
        Camera mainCamera = Camera.main;
        screenLeft = mainCamera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x;
        screenRight = mainCamera.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, 0.0f)).x;
        screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, 0.0f)).y;
    }

    // Update is called once per frame
    void Update()
    {
        positionDelta.x = Input.GetAxis("Horizontal") * speed;
        positionDelta.y = Input.GetAxis("Vertical") * speed;

        if (health == 0)
        {
            gameOverScreen.StartUp();
            FindObjectOfType<GameManager>().Pause();
            this.enabled = false;
        }
    }


    void FixedUpdate()
    {
        Vector3 shipExtent = m_spriteRenderer.localBounds.extents;
        
        Vector2 position = transform.position;
        position += positionDelta * Time.deltaTime;
        
        // Wrap around left and right
        if (position.x - shipExtent.x > screenRight)
            position.x = screenLeft - shipExtent.x;
        else if (position.x + shipExtent.x < screenLeft)
            position.x = screenRight + shipExtent.x;
        
        // y Bounds
        if (position.y - shipExtent.y <= screenBottom)
            position.y = transform.position.y;
        else if (position.y + shipExtent.y > screenBottom + boundHeight)
            position.y = transform.position.y;
        
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            float asteroidSize = collision.gameObject.transform.localScale.x;
            health -= (int)(maxHitDamage * asteroidSize);
            health = Math.Max(health, 0);
            healthText.text = "Health: " + health;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("Hello");
    }
}
