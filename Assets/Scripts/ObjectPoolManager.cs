using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private Dictionary<GameObject, Queue<GameObject>> objectPool = new Dictionary<GameObject, Queue<GameObject>>();

    public static ObjectPoolManager manager { get; private set; }

    private void Awake()
    {
        manager = this;
    }

    public GameObject GetGameObject(GameObject obj, Vector2 pos, Quaternion rotation)
    {
        if (!objectPool.ContainsKey(obj))
        {
            objectPool.Add(obj, new Queue<GameObject>());
        }

        GameObject prefabObject;

        if (objectPool[obj].Count > 0)
        {
            prefabObject = objectPool[obj].Dequeue();
        }
        else
        {
            prefabObject = Instantiate(obj);

            prefabObject.AddComponent<ObjectReference>().prefabRef = obj;
        }

        prefabObject.transform.position = pos;
        prefabObject.transform.rotation = rotation;
        prefabObject.SetActive(true);

        Debug.Log("Complete");

        return prefabObject;
    }

    public void ReturnToPool(GameObject gameObject)
    {
        var flag = gameObject.GetComponent<ObjectReference>();

        if (flag != null)
        {
            gameObject.SetActive(false);
            objectPool[flag.prefabRef].Enqueue(gameObject);
        }
        else Destroy(gameObject);
    }
}