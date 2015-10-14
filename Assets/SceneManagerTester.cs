using UnityEngine;
using System.Collections;

public class SceneManagerTester : MonoBehaviour {

    public int sceneToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.Instance.SetScene(sceneToLoad);
        }
	}
}
