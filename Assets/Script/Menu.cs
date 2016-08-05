using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    [SerializeField]
    private GameObject _menu;
    public GameObject _mission;
    [SerializeField]
    private Text _missionText;
    [SerializeField]
    private GameObject _key;
    [SerializeField]  
    private GameObject _spider;
    [SerializeField]
    private Image _pictureForLevel;

    [SerializeField]
    private Transform player;   
    [SerializeField]
    private Transform spiderTransform;

    public Sprite[] PictureForLevels;

  public static bool newLevel = false;

    public static int level = 0;
    void Start()
    {
        _mission.active = false;
        Time.timeScale = 0;

        _key.active = false;
        _spider.active = false;
    }
   
    void Update()
    {
        try
        {
            _pictureForLevel.sprite = PictureForLevels[Menu.level];
        }
        catch
        {

        }

        if (newLevel == true && level == 0)
        {
              if(PlayerPrefs.GetFloat("x") == 0 && PlayerPrefs.GetFloat("y") == 0 && PlayerPrefs.GetFloat("z") == 0 )
            {
                player.transform.position = new Vector3(330, -0.5f, 350);
            }
            else
            {
                player.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            }
          
            _missionText.text = "Необходимо найти ключ, который открывает подвал.";
            _key.active = true;
            newLevel = false;
        }
        if (newLevel == true && level == 1)
        {         
            _key.active = false;
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            _missionText.text = "Ключ от подвала у вас. Ищите подвал";
            newLevel = false;
        }
        if (newLevel == true && level == 2)
        {
            Spider.livesSpider = Spider.maxlivesSpider;
            _missionText.text = "Убейте паука";
            _spider.active = true;
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            spiderTransform.transform.position = new Vector3(PlayerPrefs.GetFloat("xSpider"), PlayerPrefs.GetFloat("ySpider"), PlayerPrefs.GetFloat("zSpider"));
            newLevel = false;
        }
        if (newLevel == true && level == 3)
        {
            _missionText.text = "Паук убит. Залезте на крышу деревянной хижины";
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            spiderTransform.transform.position = new Vector3(PlayerPrefs.GetFloat("xSpider"), PlayerPrefs.GetFloat("ySpider"), PlayerPrefs.GetFloat("zSpider"));
            newLevel = false;
        }
        if (newLevel == true && level == 4)
        {
            _missionText.text = "Отлично!";
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            spiderTransform.transform.position = new Vector3(PlayerPrefs.GetFloat("xSpider"), PlayerPrefs.GetFloat("ySpider"), PlayerPrefs.GetFloat("zSpider"));
            newLevel = false;
        }
    }

    public void OnClickStart()
    {
        try
        {
            Menu.level = PlayerPrefs.GetInt("level");
        }
        catch { }
        Menu.newLevel = true;
        _mission.active = true;
        _menu.active = false;
    }

    public void OnClickClose()
    {
        Application.Quit();
    }

    public void OnClickSettings()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCloseMission()
    {
        Time.timeScale = 1;
        _mission.active = false;
    }

  

}

