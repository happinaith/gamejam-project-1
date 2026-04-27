using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [Header("Настройки скорости")]
    public float speedMultiplier; // 0.1 - для дальних слоев, 1.0 - для ближних

    // Статические переменные общие для ВСЕХ слоев
    public static float globalSpeed = 2f;
    public static float acceleration = 0.1f;

    private float _width;
    private Vector3 _startPosition;

    void Start()
    {
        // Определяем ширину спрайта автоматически
        _width = GetComponent<SpriteRenderer>().bounds.size.x;
        _startPosition = transform.position;
    }

    void Update()
    {
        // Ускоряем только один раз (проверка по ID объекта, чтобы не частить)
        if (gameObject.GetEntityId() == GetEntityId())
        {
            globalSpeed += acceleration * Time.deltaTime;
        }

        // Остальной код движения остается таким же
        transform.position += Vector3.left * (globalSpeed * speedMultiplier * Time.deltaTime);

        if (transform.position.x < _startPosition.x - _width)
        {
            transform.position += new Vector3(_width * 2f, 0, 0);
        }
    }
}