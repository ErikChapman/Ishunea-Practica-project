using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenTeleportDecorator : OutOfScreenTrigger
{
    private void Start()
    {
        onObjectOutOfScreen += Teleport;
    }

    private void Teleport(OutOfScreenDirection direction)
    {
        switch (direction)
        {
            case OutOfScreenDirection.Top:
                transform.position -= new Vector3(0, stageDimensions.y * 2 + spriteRenderer.bounds.size.y);
                break;
            case OutOfScreenDirection.Bottom:
                transform.position += new Vector3(0, stageDimensions.y * 2 + spriteRenderer.bounds.size.y);
                break;
            case OutOfScreenDirection.Right:
                transform.position -= new Vector3(stageDimensions.x * 2 + spriteRenderer.bounds.size.x, 0);
                break;
            case OutOfScreenDirection.Left:
                transform.position += new Vector3(stageDimensions.x * 2 + spriteRenderer.bounds.size.x, 0);
                break;
        }
    }

    private void OnDestroy()
    {
        onObjectOutOfScreen -= Teleport;
    }
}
