using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    [SerializeField] protected float rotateSpeed;

    public virtual void Rotate(float xAngle, float yAngle, float zAngle)
    {
        transform.Translate(xAngle * rotateSpeed, yAngle * rotateSpeed, zAngle * rotateSpeed);
    }

    public virtual void RotateRight()
    {
        Rotate(-1, 0, 0);
    }

    public virtual void RotateLeft()
    {
        Rotate(1, 0, 0);
    }

}
