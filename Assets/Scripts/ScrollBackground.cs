using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField]
    private RawImage background;

    [SerializeField]
    private Vector2 speed;

    // Update is called once per frame
    void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + speed * Time.deltaTime, background.uvRect.size);
    }
}
