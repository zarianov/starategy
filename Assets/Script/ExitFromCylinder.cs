using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitFromCylinder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        RelativeMovementAnd player = other.GetComponent<RelativeMovementAnd>();
        if (player != null)
        {
          
            if (!AndroidButtons.b_GoRigt || !AndroidButtons.b_vverh || !AndroidButtons.b_GoLeft || !AndroidButtons.b_vniz)
            {
                AndroidButtons.b_GoRigt = true;
                AndroidButtons.b_vverh = true;
                AndroidButtons.b_GoLeft = true;
                AndroidButtons.b_vniz = true;
            }
          
            SceneManager.LoadScene(0);
      
        }

    }
}
