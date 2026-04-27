using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclePrefabs;

    [SerializeField]
    private GameObject[] invisiblePrefabs;

    [SerializeField]
    private GameObject energyPrefab;

    [SerializeField]
    private GameObject healthPrefab;

    private ObjectPoolManager poolManager;

    public float maxTimeObstacle { get; private set; } = 5f;
    public float maxTimeInvisible { get; private set; } = 7f;
    public float maxTimeHealthPower { get; private set; } = 15f;
    public float maxTimeEnergyPower { get; private set; } = 20f;


    private float timerObstacle = 0;
    private float timerInvisible = 0;
    private float timerHealthPower = 0;
    private float timerEnergyPower = 0;

    private void Start()
    {
        poolManager = GetComponent<ObjectPoolManager>();
    }

    private void Update()
    {
        // заменить на GameManager состояние
        if (true)
        {
            if (timerObstacle > maxTimeObstacle)
            {
                SpawnRandomObstacle();
                timerObstacle = 0;
            }

            if (timerInvisible > maxTimeInvisible)
            {
                SpawnRandomInvisible();
                timerInvisible = 0f;
            }

            if (timerHealthPower > maxTimeHealthPower)
            {
                SpawnHP();
                timerHealthPower = 0f;
            }

            if (timerEnergyPower > maxTimeEnergyPower)
            {
                SpawnEnergy();
                timerEnergyPower = 0f;
            }

            UpdateTimers();
        }
    }

    private void SpawnRandomObstacle()
    {
        GameObject gameObject = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        poolManager.GetGameObject(gameObject, new Vector2(15, -1.5f), gameObject.transform.rotation);
    }

    private void SpawnRandomInvisible()
    {
        GameObject gameObject = invisiblePrefabs[Random.Range(0, invisiblePrefabs.Length)];

        gameObject.TryGetComponent<ObstacleClass>(out ObstacleClass obstacleClass);

        if (obstacleClass.direction == ObstacleClass.Direction.Right)
        {
            poolManager.GetGameObject(gameObject, new Vector2(-15, -1.5f), gameObject.transform.rotation);
        }
        else if (obstacleClass.direction == ObstacleClass.Direction.Left)
        {
            poolManager.GetGameObject(gameObject, new Vector2(15, -1.5f), gameObject.transform.rotation);
        }
    }

    private void SpawnEnergy()
    {
        poolManager.GetGameObject(energyPrefab, new Vector2(15, 0.5f), gameObject.transform.rotation);
    }

    private void SpawnHP()
    {
        poolManager.GetGameObject(healthPrefab, new Vector2(15, 0.5f), gameObject.transform.rotation);
    }

    private void UpdateTimers()
    {
        timerObstacle += Time.deltaTime;
        timerInvisible += Time.deltaTime;
        timerHealthPower += Time.deltaTime;
        timerEnergyPower += Time.deltaTime;
    }
}
