using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject, IPowerUp
{
    public Sprite art;
    public Color color = Color.blue;

    public void ChangeSpriteRender(SpriteRenderer obj)
    {
        obj.sprite = art;
        obj.color = color;
    }
    public float PowerLevel { get; set; }
    public float health;
    
    public float Shields { get; }
}
