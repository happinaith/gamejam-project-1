using Unity.VisualScripting;
using UnityEngine;

public class ObstacleClass : MonoBehaviour
{
    [SerializeField] private PlayerState requiredState;

    private void Update()
    {
        transform.Translate(Vector2.left * 3f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController controller))
        {
            if (controller.state != requiredState) Debug.Log("Не прошло " + requiredState + " получено: " + controller.state);
            else Debug.Log("Прошло " + controller.state + " " + requiredState);
        }
    }

}
