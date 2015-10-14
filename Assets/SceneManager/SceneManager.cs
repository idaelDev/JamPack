using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : Singleton<SceneManager> {

    public Color fadeColor = Color.black;
    public float StartFadeTime = 1.5f;
    public float EndFadeTime = 1.5f;

    private bool isSceneStarting = true;
    private GameObject CanvasObject;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        CanvasObject = new GameObject("SceneFader");
        CanvasObject.transform.SetParent(transform);
        CanvasObject.AddComponent(typeof(Canvas));
        CanvasObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasObject.AddComponent(typeof(Image));
        CanvasObject.AddComponent(typeof(CanvasGroup));
        canvasGroup = CanvasObject.GetComponent<CanvasGroup>();
        Image image = CanvasObject.GetComponent<Image>();
        image.color = fadeColor;
    }

    void Update()
    {
        if(isSceneStarting)
        {
            StartCoroutine(StartScene());
        }
    }

    public void SetScene(int sceneToLoad)
    {
        StartCoroutine(EndScene(sceneToLoad));
    }

    private IEnumerator EndScene(int sceneToLoad)
    {
        float t = 0;
        while (t < EndFadeTime)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / EndFadeTime);
            t += Time.deltaTime;
            yield return 0;
        }
        Application.LoadLevel(sceneToLoad);
    }

    private IEnumerator StartScene()
    {
        float t = 0;
        isSceneStarting = false;
        while (t < StartFadeTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / StartFadeTime);
            t += Time.deltaTime;
            yield return 0;
        }
    }

}
