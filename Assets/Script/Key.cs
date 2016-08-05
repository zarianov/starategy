using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
    [SerializeField]
    private GameObject gm;
    [SerializeField]
    private Transform _keyForRotate;

    private float posX;
    private float posY;
    private float posZ;


    int i = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        _keyForRotate.eulerAngles = new Vector3(0, i, 0);
        i = i + 2;
    }

    void OnTriggerEnter(Collider other)
    {
        
        RelativeMovement player = other.GetComponent<RelativeMovement>();
        if (player != null)
        {
            posX = player.transform.position.x;
            posY = player.transform.position.y;
            posZ = player.transform.position.z;
            PlayerPrefs.SetFloat("x", posX);
            PlayerPrefs.SetFloat("y", posY);
            PlayerPrefs.SetFloat("z", posZ);
            Menu.level++;
            
            Time.timeScale = 0;
            Menu.newLevel = true;
            gm.active = true;
        
            PlayerPrefs.SetInt("level", Menu.level);

        }

    }
}
