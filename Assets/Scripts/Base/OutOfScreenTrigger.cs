using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OutOfScreenTrigger : MonoBehaviour
{ 
    protected Vector2 stageDimensions;
    protected SpriteRenderer spriteRenderer;
    public Action<OutOfScreenDirection> onObjectOutOfScreen;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
    }
    
    void Update()
    {
        if (transform.position.x - spriteRenderer.bounds.size.x / 2 > stageDimensions.x)
            onObjectOutOfScreen(OutOfScreenDirection.Right);
        else if (transform.position.x + spriteRenderer.bounds.size.x / 2 < -stageDimensions.x)
            onObjectOutOfScreen(OutOfScreenDirection.Left);
        else if (transform.position.y - spriteRenderer.bounds.size.y / 2 > stageDimensions.y)
            onObjectOutOfScreen(OutOfScreenDirection.Top);
        else if (transform.position.y + spriteRenderer.bounds.size.y / 2 < -stageDimensions.y)
            onObjectOutOfScreen(OutOfScreenDirection.Bottom);
    }
}

public enum OutOfScreenDirection
{
    Top, Bottom, Left, Right
}
