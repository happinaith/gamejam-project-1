using Unity.VisualScripting;
using UnityEngine;

public class ObstacleClass : MonoBehaviour
{
    [SerializeField] private PlayerState requiredState;
    [SerializeField] private bool isInvisible = false;
    [SerializeField] private bool isHealth = false;
    [SerializeField] private bool isPower = false;

    SpriteRenderer sr;
    AudioSource audioCl;

    private float dist = 5f;

    [field: SerializeField]
    public Direction direction { get; private set; }


    public enum Direction 
    {
        Left,
        Right,
    }

    private void OnEnable()
    {
        dist = 5f;
    }

    private void OnDisable()
    {
        dist = 0f;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioCl = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isInvisible)
        {
            if (direction == Direction.Right)
            {
                transform.Translate(Vector2.right * 8f * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * 8f * Time.deltaTime);
            }

            MaterialPropertyBlock propBlock = new MaterialPropertyBlock();

            dist -= Time.deltaTime/2;

            if (dist >= 0)
            {
                sr.GetPropertyBlock(propBlock);

                propBlock.SetFloat("_Speed", dist);

                sr.SetPropertyBlock(propBlock);
            }
            return;
        }

        var position = gameObject.transform.position.x;

        if (position > 20f || position < -20f) ObjectPoolManager.manager.ReturnToPool(gameObject);


        if (!isInvisible) transform.Translate(Vector2.left * 4f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController controller))
        {
            if (isHealth)
            {
                controller.GiveHealth();
                if (audioCl != null && audioCl.clip != null)
                {
                    AudioSource.PlayClipAtPoint(audioCl.clip, transform.position);
                }
                ObjectPoolManager.manager.ReturnToPool(gameObject);
                return;
            }

            if (isPower)
            {
                controller.GiveEnergy();
                if (audioCl != null && audioCl.clip != null)
                {
                    AudioSource.PlayClipAtPoint(audioCl.clip, transform.position);
                }
                ObjectPoolManager.manager.ReturnToPool(gameObject);
                return;
            }
            if (isInvisible && controller.state != requiredState)
            {
                controller.TakeEnergy();
                return;
            }
            else if (isInvisible) return;

            if (controller.state != requiredState) controller.TakeDamage();
        }
    }

}
