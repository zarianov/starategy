using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickReset()
    {
        PlayerPrefs.DeleteAll();
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene(0);
    }
}
