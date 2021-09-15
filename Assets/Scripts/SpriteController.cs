using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRender;
    [SerializeField] private StateController stateController;
    private int currentSprite;
    private bool haveStates;
    private void Awake()
    {
        currentSprite = 0;
        if (stateController == null)
            haveStates = false;
        else
            haveStates = true;

    }
    private int GetSpriteIndex(Vector3 direction)
    {
        int changeSprite;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            if (direction.x > 0)
                changeSprite = 0;
            else changeSprite = 1;
        else
            if (direction.y > 0)
            changeSprite = 3;
        else changeSprite = 2;
        return changeSprite;
    }

    internal void OnStateChanged()
    {
        ChangeSprite();
    }

    public void CheckSpriteDirection(Vector3 direction)
    {
        int spriteIndex = GetSpriteIndex(direction);
        
        if (spriteIndex != currentSprite)
        {
            currentSprite = spriteIndex;
            ChangeSprite();
        }
    }
    public void ChangeSprite()
    {
        int offset;
        if (haveStates)
            offset = stateController.State * 4;
        else
            offset = 0;
        spriteRender.sprite = sprites[currentSprite+ offset];
    }
}
