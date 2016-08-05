using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour {
    public static int livesSpider = 12;
    public static int maxlivesSpider = 12;
    bool dead = false;
    public Animation anim;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject munuLevel;
    [SerializeField]
    private Transform spider;
    [SerializeField]
    private GameObject gm;
    [SerializeField]
    private Camera camera1;
    [SerializeField]
    private Camera camera2;
    [SerializeField]
    private GameObject hitImage;

    private float posX;
    private float posY;
    private float posZ;

    private float posXSpider;
    private float posYSpider;
    private float posZSpider;

    private bool needToShoot = false;

    private bool firstDeadSpider = true;

    void Start ()
    {
        anim.CrossFade("Run");
    }
	
	// Update is called once per frame
	void Update ()
    {
        float x = (player.position.x - spider.position.x)* (player.position.x - spider.position.x);
        float y = (player.position.y - spider.position.y) * (player.position.y - spider.position.y);
        float z = (player.position.z - spider.position.z) * (player.position.z - spider.position.z);
        if (x < 1 && y<1 && z<1 && dead == false && Menu.level == 2)
        {
            Menu.level = PlayerPrefs.GetInt("level");
            Menu.newLevel = true;
            //player.transform.position = new Vector3( PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            //spider.transform.position = new Vector3(PlayerPrefs.GetFloat("xSpider"), PlayerPrefs.GetFloat("ySpider"), PlayerPrefs.GetFloat("zSpider"));
            munuLevel.active = true;
            Time.timeScale = 0;
        }
          
            if (dead == false)
            {
                transform.Translate(0, 0, 4 * Time.deltaTime);
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                //if (Physics.SphereCast(ray, 0.75f, out hit))
                //{
                //    if (hit.distance < 6)
                //    {
                //float angle = Random.Range(-110, 110);
                // transform.Rotate(0, angle, 0);
                //}
                //}
                transform.LookAt(player);
            }
        
    }

    public void ReactToHit()
    {
        livesSpider--;
        Debug.Log(livesSpider);
        if (livesSpider >= 1)
        {
            HitClass HT = gameObject.GetComponent<HitClass>();
            StartCoroutine(HT.HitImageActive());
        }
       
        if (livesSpider <= 0 && firstDeadSpider == true)
        {
           // Spider behavior = GetComponent<Spider>();
            dead = true;
            anim.CrossFade("Death");

            Menu.level=3;
            Time.timeScale = 0;
            Menu.newLevel = true;
            //camera2.enabled = !camera1.enabled;
            //camera1.enabled = !camera2.enabled;
            gm.active = true;

            firstDeadSpider = false;

            posX = player.transform.position.x;
            posY = player.transform.position.y;
            posZ = player.transform.position.z;

            posXSpider = spider.transform.position.x;
            posYSpider = spider.transform.position.y;
            posZSpider = spider.transform.position.z;
            PlayerPrefs.SetInt("level", Menu.level);
            PlayerPrefs.SetFloat("x", posX);
            PlayerPrefs.SetFloat("y", posY);
            PlayerPrefs.SetFloat("z", posZ);
            PlayerPrefs.SetFloat("xSpider", posXSpider);
            PlayerPrefs.SetFloat("ySpider", posYSpider);
            PlayerPrefs.SetFloat("zSpider", posZSpider);
        }
      
    }




}

