using UnityEngine;
using System.Collections;

public class Pogreb : MonoBehaviour {
    [SerializeField]
    private GameObject gm;
    [SerializeField]
    private Transform cubeUnderPogreb;
    [SerializeField]
    private GameObject spider;
    [SerializeField]
    private GameObject player;

    private float posX;
    private float posY;
    private float posZ;

    private float posXSpider;
    private float posYSpider;
    private float posZSpider;

    bool aroundPogreb = false;
    float i = 1f;
    void Start()
    {
        
    }
    void Update()
    {
       
        if (aroundPogreb == true && Menu.level == 2)
        {
            if (i < 1.3f && Time.timeScale == 1)
            {
                //door.eulerAngles = new Vector3(0, 0, 0);
                //i = i + 3.1415f;
                cubeUnderPogreb.position = new Vector3(cubeUnderPogreb.position.x, cubeUnderPogreb.position.y + i, cubeUnderPogreb.position.z);
                i = i + 0.121f;
            }
            if (i > 1.3f && Time.timeScale == 1)
            {
                
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {

        RelativeMovement player = other.GetComponent<RelativeMovement>();
        if (Menu.level == 1 && player != null)
        {
            posX = player.transform.position.x;
            posY = player.transform.position.y;
            posZ = player.transform.position.z;

            posXSpider = spider.transform.position.x;
            posYSpider = spider.transform.position.y;
            posZSpider = spider.transform.position.z;

            Menu.level++;
            PlayerPrefs.SetInt("level", Menu.level);
            PlayerPrefs.SetFloat("x", posX);
            PlayerPrefs.SetFloat("y", posY);
            PlayerPrefs.SetFloat("z", posZ);
            PlayerPrefs.SetFloat("xSpider", posXSpider);
            PlayerPrefs.SetFloat("ySpider", posYSpider);
            PlayerPrefs.SetFloat("zSpider", posZSpider);

            Menu.newLevel = true;
            gm.active = true;
            Time.timeScale = 0;
            aroundPogreb = true;
           
        }

    }

    

}
