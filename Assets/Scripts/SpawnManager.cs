using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjectPrefabs;

    private ObjectPoolManager poolManager;
    private float timer = 0;

    private void Start()
    {
        poolManager = GetComponent<ObjectPoolManager>();
    }

    private void Update()
    {
        if (timer > 3f)
        {
            //SpawnRandom();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnRandom()
    {
        GameObject gameObject = gameObjectPrefabs[Random.Range(0, gameObjectPrefabs.Length)];

        poolManager.GetGameObject(gameObject, Vector2.up, gameObject.transform.rotation);
    }
}
