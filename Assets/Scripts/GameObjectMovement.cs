using UnityEngine;

public class GameObjectMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * 3;
    }
}
