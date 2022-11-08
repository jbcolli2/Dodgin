using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Asteroid asteroidPrefab;

    private float timer = 0;

    [SerializeField]
    private float asteroidTimeInterval = 20;   // How long between new astroids

    [SerializeField] private Vector2 scaleRange = new Vector2(.1f, 1.0f);

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > asteroidTimeInterval)
        {
            Camera camera = Camera.main;

            float scale = Random.Range(scaleRange[0], scaleRange[1]);
            float startX = Random.Range(0.0f, 1.0f);
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
            
            Vector3 newAsteroidPosition = camera.ViewportToWorldPoint(new Vector3(startX, 1.0f, camera.nearClipPlane));
            Asteroid temp = Instantiate(asteroidPrefab, newAsteroidPosition, rotation);
            temp.transform.localScale = new Vector3(scale, scale, 1.0f);
            timer = 0;
        }
    }



    public void Pause()
    {
        foreach(Asteroid asteroid in FindObjectsOfType<Asteroid>())
        {
            asteroid.enabled = false;
        }

        this.enabled = false;
    }
}
