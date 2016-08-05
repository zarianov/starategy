using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnterToCylinder : MonoBehaviour {
    private float posX;
    private float posY;
    private float posZ;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        RelativeMovement player = other.GetComponent<RelativeMovement>();
        if (player != null)
        {
            posX = player.transform.position.x+3;
            posY = player.transform.position.y;
            posZ = player.transform.position.z;

            PlayerPrefs.SetFloat("x", posX);
            PlayerPrefs.SetFloat("y", posY);
            PlayerPrefs.SetFloat("z", posZ);
            if (!AndroidButtons.b_GoRigt || !AndroidButtons.b_vverh || !AndroidButtons.b_GoLeft || !AndroidButtons.b_vniz)
            {
                AndroidButtons.b_GoRigt = true;
                AndroidButtons.b_vverh = true;
                AndroidButtons.b_GoLeft = true;
                AndroidButtons.b_vniz = true;
            }
            SceneManager.LoadScene(2);
        }

    }

}
