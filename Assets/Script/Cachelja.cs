using UnityEngine;
using System.Collections;

public class Cachelja : MonoBehaviour {
    [SerializeField]
    private Transform doska;
    [SerializeField]
    private Transform player;
    public static bool fly = false;
    // Use this for initialization
    void Start ()
    {
        
    }
    bool up = true;
    float i = 0;
    float heithForJump = 1;
    // Update is called once per frame

    void Update ()
    {
        if (i == 15)
        {
            up = false;
        }
        if (i == -15)
        {
            up = true;
        }
        if (up == false)
        {
            doska.eulerAngles = new Vector3(doska.eulerAngles.x, doska.eulerAngles.y, doska.eulerAngles.z-5);
            i= i-5;
          //  doska.rotation = new Quaternion(doska.rotation.x, doska.rotation.y, doska.rotation.z + 1, doska.rotation.w);
        }
        if (up == true)
        {
            doska.eulerAngles = new Vector3(doska.eulerAngles.x, doska.eulerAngles.y, doska.eulerAngles.z + 5);
            i=i+5;
        }


    }

    void OnTriggerEnter(Collider other)
    {

        RelativeMovementAnd player = other.GetComponent<RelativeMovementAnd>();
        if (player != null)
        {
            Debug.Log("Коснулся качели!");
            fly = true;
        }

    }


}
