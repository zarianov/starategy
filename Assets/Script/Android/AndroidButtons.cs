using UnityEngine;
using System.Collections;

public class AndroidButtons : MonoBehaviour {
   
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   public static bool b_vverh = true;
    public void OnChangedUp()
    {
        b_vverh = true;
    }
    public void OnChangedDown()
    {
        b_vverh = false;
    }

    // Вниз для Андроида
    public static bool b_vniz = true;
    public void OnChangedUpVniz()
    {
        b_vniz = true;
    }
    public void OnChangedDownVniz()
    {
        b_vniz = false;
    }
    //идти вправо
    public static bool b_GoRigt = true;
    public void OnChangedUpGoRigt()
    {
        b_GoRigt = true;
    }
    public void OnChangedDownGoRigt()
    {
        b_GoRigt = false;
    }
    //идти влево
    public static bool b_GoLeft = true;
    public void OnChangedUpGoLeft()
    {
        b_GoLeft = true;
    }
    public void OnChangedDownGoLeft()
    {
        b_GoLeft = false;
    }

    //прыгать
    public static bool b_jump = false;
    public void Jump()
    {
        b_jump = true;
    }
    public static bool b_shoot = false;
    public void ClickShoot()
    {
        b_shoot = true;
    }

  
}
