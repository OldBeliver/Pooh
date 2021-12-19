using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class BeeSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _sprites;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        int randomIndex = GetSpriteIndex(_sprites.Length);

        _spriteRenderer.sprite = _sprites[randomIndex];
    }

    private int GetSpriteIndex(int spritesCount)
    {
        return Random.Range(0, spritesCount);
    }
}
