using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float transparencyValue = 0.7f;
    [SerializeField] private float transparencyFadeTime = 0.4f;

    private SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private IEnumerator Fade(SpriteRenderer spriteTransparency, float fadeTime, float startValue, float targetTransparency)
    {
        float timeElapsed = 0;
        while (timeElapsed < fadeTime) {
            timeElapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransparency, timeElapsed / fadeTime);
            spriteTransparency.color = new Color(spriteTransparency.color.r, spriteTransparency.color.g, spriteTransparency.color.b, newAlpha);
            yield return null;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            StartCoroutine(Fade(sprite, transparencyFadeTime, sprite.color.a, transparencyValue));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            StartCoroutine(Fade(sprite, transparencyFadeTime, sprite.color.a, 1f));
        }
    }
}
