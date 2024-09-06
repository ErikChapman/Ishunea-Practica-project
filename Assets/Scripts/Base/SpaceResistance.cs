using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceResistance : MonoBehaviour
{
    [SerializeField] private float _resistance;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rigidbody2D.AddForce(-_resistance * _rigidbody2D.velocity, ForceMode2D.Force);
    }
}
