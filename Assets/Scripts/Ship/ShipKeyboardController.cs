using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EngineController), typeof(RotateController), typeof(ShootController))]
public class ShipKeyboardController : MonoBehaviour
{
    [SerializeField] private KeyCode _engineKey;
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _rightKey;
    [SerializeField] private KeyCode _shootKey;
    
    private EngineController _engineController;
    private RotateController _rotateController;
    private ShootController _shootController;
    void Start()
    {
        _engineController = GetComponent<EngineController>();
        _rotateController = GetComponent<RotateController>();
        _shootController = GetComponent<ShootController>();
        GameCore.SetShip(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(_shootKey))
            _shootController.Shoot();
    }
    
    void FixedUpdate()
    {
        if (Input.GetKey(_leftKey))
            _rotateController.RotateLeft();
        else if (Input.GetKey(_rightKey))
            _rotateController.RotateRight();
        

        if (Input.GetKey(_engineKey))
            _engineController.AddForce();
    }
}
