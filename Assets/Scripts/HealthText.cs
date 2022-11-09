using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    [SerializeField]
    private Color defaultColor = Color.white;

    [SerializeField]
    private Color damageColor = Color.red;

    [SerializeField]
    private float damageDuration = 1.0f;
    
    private float timer;
    private bool isDamageColor;
    private TMPro.TMP_Text healthText;

    void Start()
    {
        timer = 0;
        healthText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        
        if (isDamageColor)
        {
            timer += Time.deltaTime;

            if (timer > damageDuration)
            {
                healthText.color = defaultColor;
                isDamageColor = false;
            }
        }
        
    }

    public void InitHealth(int health)
    {
        healthText.text = "Health: " + health;
    }
    
    public void DecreaseHealth(int newHealth)
    {
        isDamageColor = true;
        timer = 0;
        healthText.text = "Health: " + newHealth;
        healthText.color = damageColor;
    }
    
    
}
