using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraForShootAnd : MonoBehaviour {
    public Camera camera1;
    public Camera camera2;
    public SphereCollider sphere;
    [SerializeField]
    private GameObject _androidButtons;
    [SerializeField]
    private GameObject _joistick;

    private bool _needToShot = true;

    void Start () {
        camera2.enabled = false;
        camera1.enabled = true;
    }
    bool pressMouse = false;

	void Update ()
    {
        if (AndroidButtons.b_shoot == true)
        {
            AndroidButtons.b_shoot = false;
            if (pressMouse == true)
            {  
                camera2.enabled = !camera1.enabled;
                camera1.enabled = !camera2.enabled;
                
                PressMouseFaulse();
                
            }

            if (pressMouse == false)
            {
               
                camera2.enabled = !camera2.enabled;
                camera1.enabled = !camera1.enabled;
                
                PressMouseTrue();
               
            }
        }

        if (AndroidButtons.b_shoot == false)
        {
           
            if (pressMouse == true)
            {
              
            }

            if (pressMouse == false)
            {
               
                camera2.enabled = !camera1.enabled;
                camera1.enabled = !camera2.enabled;              

            }
        }

        if(camera2.enabled)
        {

             Debug.Log("выстрел");
                EventSystem.current.IsPointerOverGameObject();
                Vector3 point = new Vector3(camera2.pixelWidth / 2, camera2.pixelHeight / 2, 0);
                Ray ray = camera2.ScreenPointToRay(point);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                Spider target = hitObject.GetComponent<Spider>();

                    if (target != null)
                    {
                    if (_needToShot == true)
                    {
                        target.ReactToHit();
                        StartCoroutine(NeedToShoot());
                    }
                    }

                    else
                    {     
                        StartCoroutine(SphereIndicator(hit.point));
                    }
                }  
            _androidButtons.active = false;
            _joistick.active = true;

        }
        if (!camera2.enabled)
        {
            _androidButtons.active = true;
            _joistick.active = false;
        }


    }

    void PressMouseTrue()
    {
        pressMouse = true;
    }

    void PressMouseFaulse()
    {
        pressMouse = false;
    }

    void OnGUI()
    {
        int size = 44;
        float posX = camera2.pixelWidth / 2 - size / 4;
        float posY = camera2.pixelHeight / 2 - size / 2;

        float posXForName = camera2.pixelWidth / 2 - size * 5;
        float posYForName = camera2.pixelHeight / 2 - size / 2;

        GUIStyle localStyle = new GUIStyle(GUI.skin.label);
        localStyle.normal.textColor = Color.red;
        localStyle.fontSize = 35;
        if (camera2.enabled == true)
        {
            size = 100;
        }
        if (camera2.enabled == false)
        {
            size = 0;
        }
        GUI.Label(new Rect(posX, posY, size, size), "○", localStyle);
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {

        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Vector3 daleko = new Vector3(80, -1000, 80);
        sphere.transform.position = daleko;
    }

    private IEnumerator NeedToShoot()
    {
       
       _needToShot = false;
        yield return new WaitForSeconds(1f);
       _needToShot = true;

    }

}
