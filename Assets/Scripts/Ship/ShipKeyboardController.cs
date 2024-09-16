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

    public Animator engineAnimator; // Аниматор для управления состоянием двигателя
    public AudioSource EngineAudio; // Аудио для двигателя
    public AudioSource ShootAudio; // Аудио для выстрела

    public float _targetHeight = 10f;  // Целевая высота

    void Start()
    {
        _engineController = GetComponent<EngineController>();
        _rotateController = GetComponent<RotateController>();
        _shootController = GetComponent<ShootController>();

        engineAnimator = GetComponent<Animator>();

        if (EngineAudio == null)
            EngineAudio = GetComponent<AudioSource>();  // Убедитесь, что AudioSource для двигателя присвоен

        if (EngineAudio == null)
            EngineAudio = gameObject.AddComponent<AudioSource>();  // Добавьте AudioSource для двигателя, если он отсутствует

        if (ShootAudio == null)
            ShootAudio = gameObject.AddComponent<AudioSource>();  // Добавьте AudioSource для звука выстрела, если он отсутствует

        GameCore.SetShip(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            _shootController.Shoot();
            if (ShootAudio != null)
            {
                ShootAudio.Play(); // Воспроизвести звук выстрела
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(_leftKey))
            _rotateController.RotateLeft();
        else if (Input.GetKey(_rightKey))
            _rotateController.RotateRight();

        // Проверка высоты корабля
        if (transform.position.y >= _targetHeight || Input.GetKey(_engineKey))
        {
            _engineController.AddForce();
            if (!EngineAudio.isPlaying)
                EngineAudio.Play();  // Воспроизведение звука двигателя, если он еще не играет
            engineAnimator.SetBool("EngineOn", true); // Устанавливаем параметр анимации в true
        }
        else
        {
            engineAnimator.SetBool("EngineOn", false); // Устанавливаем параметр анимации в false
        }
    }
}
