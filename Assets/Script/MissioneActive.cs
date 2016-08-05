using UnityEngine;
using System.Collections;

public class MissioneActive : MonoBehaviour {
    [SerializeField]
    private GameObject gm;

    private float posX;
    private float posY;
    private float posZ;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   public void MissioneActiveTrue()
    {
        gm.active = true;
    }
}
