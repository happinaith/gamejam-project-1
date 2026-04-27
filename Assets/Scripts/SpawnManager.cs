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

    public float minTimeObstacle = 3f;
    public float maxTimeObstacle = 6f;

    public float minTimeInvisible = 5f;
    public float maxTimeInvisible = 10f;

    public float minTimeHealthPower = 15f;
    public float maxTimeHealthPower = 25f;

    public float minTimeEnergyPower = 10f;
    public float maxTimeEnergyPower = 18f;

    private float timerObstacle = 0;
    private float timerInvisible = 0;
    private float timerHealthPower = 0;
    private float timerEnergyPower = 0;

    private float currentMaxTimeObstacle;
    private float currentMaxTimeInvisible;
    private float currentMaxTimeHealthPower;
    private float currentMaxTimeEnergyPower;

    private void Start()
    {
        poolManager = GetComponent<ObjectPoolManager>();

        // Сразу задаем первые случайные тайминги
        SetNextSpawnTimeObstacle();
        SetNextSpawnTimeInvisible();
        SetNextSpawnTimeHealth();
        SetNextSpawnTimeEnergy();
    }

    private void Update()
    {
        // Только если игра идет
        if (GameManager.instance != null && !GameManager.instance.isDead)
        {
            UpdateTimers();

            // Проверяем каждого кандидата
            if (timerObstacle > currentMaxTimeObstacle)
            {
                SpawnRandomObstacle();
                SetNextSpawnTimeObstacle();
            }

            if (timerInvisible > currentMaxTimeInvisible)
            {
                SpawnRandomInvisible();
                SetNextSpawnTimeInvisible();
            }

            if (timerHealthPower > currentMaxTimeHealthPower)
            {
                SpawnHP();
                SetNextSpawnTimeHealth();
            }

            if (timerEnergyPower > currentMaxTimeEnergyPower)
            {
                SpawnEnergy();
                SetNextSpawnTimeEnergy();
            }
        }
    }

    private void SetNextSpawnTimeObstacle()
    {
        timerObstacle = 0f;
        currentMaxTimeObstacle = Random.Range(minTimeObstacle, maxTimeObstacle);
    }

    private void SetNextSpawnTimeInvisible()
    {
        timerInvisible = 0f;
        currentMaxTimeInvisible = Random.Range(minTimeInvisible, maxTimeInvisible);
    }

    private void SetNextSpawnTimeHealth()
    {
        timerHealthPower = 0f;
        currentMaxTimeHealthPower = Random.Range(minTimeHealthPower, maxTimeHealthPower);
    }

    private void SetNextSpawnTimeEnergy()
    {
        timerEnergyPower = 0f;
        currentMaxTimeEnergyPower = Random.Range(minTimeEnergyPower, maxTimeEnergyPower);
    }

    private void SpawnRandomObstacle()
    {
        GameObject gameObject = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        poolManager.GetGameObject(gameObject, new Vector2(15, -4.8f), gameObject.transform.rotation);
    }

    private void SpawnRandomInvisible()
    {
        GameObject gameObject = invisiblePrefabs[Random.Range(0, invisiblePrefabs.Length)];

        gameObject.TryGetComponent<ObstacleClass>(out ObstacleClass obstacleClass);

        if (obstacleClass.direction == ObstacleClass.Direction.Right)
        {
            poolManager.GetGameObject(gameObject, new Vector2(-15, -4.4f), gameObject.transform.rotation);
        }
        else if (obstacleClass.direction == ObstacleClass.Direction.Left)
        {
            poolManager.GetGameObject(gameObject, new Vector2(15, -4.4f), gameObject.transform.rotation);
        }
    }

    private void SpawnEnergy()
    {
        poolManager.GetGameObject(energyPrefab, new Vector2(15, -3f), gameObject.transform.rotation);
    }

    private void SpawnHP()
    {
        poolManager.GetGameObject(healthPrefab, new Vector2(15, -3f), gameObject.transform.rotation);
    }

    private void UpdateTimers()
    {
        timerObstacle += Time.deltaTime;
        timerInvisible += Time.deltaTime;
        timerHealthPower += Time.deltaTime;
        timerEnergyPower += Time.deltaTime;
    }
}
