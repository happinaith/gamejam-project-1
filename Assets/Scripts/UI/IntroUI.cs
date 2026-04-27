using UnityEngine;
using System.Collections;

public class IntroUI : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondImage;

    void Start()
    {
        StartCoroutine(RunSequence());
    }

    IEnumerator RunSequence()
    {
        firstObject.SetActive(true);
        secondImage.SetActive(false);
        yield return new WaitForSecondsRealtime(15f);

        // 2. Скрываем первый, показываем второй
        firstObject.SetActive(false);
        secondImage.SetActive(true);
        yield return new WaitForSecondsRealtime(8f); 

        // 3. Грузим сцену
        Loader.Load(Loader.Scene.GameScene);
    }
}
