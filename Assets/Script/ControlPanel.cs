using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ControlPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject gm;
    [SerializeField]
    private GameObject calculator;

    [SerializeField]
    private Text _textFirst;
    [SerializeField]
    private Text _textSecond;
    [SerializeField]
    private Text _time;

    [SerializeField]
    private InputField _inputField;

    private float posX;
    private float posY;
    private float posZ;

    private int first;
    private int second;

    private float timeF = 0;
    private float timeEq;
    // Use this for initialization
    void Start()
    {
        timeEq = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (calculator.active == true)
        {
            _time.text = timeEq.ToString(); // Присвоить тексту число переведённое в строку.
            timeF += Time.deltaTime; // Складываем значение для расчёта времени.
            if (timeF >= 1) // Если значение больше либо равно 1.2, то:
            {

                timeEq--; // Уменьшаем число времени на 1.
                timeF = 0; // Значение для расчёта времени равно 0;

            }
            if (timeEq <= 0) // Если число отсчёта времени меньше либо равно 0, то:
            {
                _inputField.text = "";
                NewNumbers();
                timeEq = 5;
            }
        }
        if (one == true)
        {
            _inputField.text += "1";
            one = false;
        }
        if (two == true)
        {
            _inputField.text += "2";
            two = false;
        }
        if (three == true)
        {
            _inputField.text += "3";
            three = false;
        }
        if (five == true)
        {
            _inputField.text += "5";
            five = false;
        }
        if (four == true)
        {
            _inputField.text += "4";
            four = false;
        }
        if (six == true)
        {
            _inputField.text += "6";
            six = false;
        }
        if (seven == true)
        {
            _inputField.text += "7";
            seven = false;
        }
        if (eight == true)
        {
            _inputField.text += "8";
            eight = false;
        }
        if (nine == true)
        {
            _inputField.text += "9";
            nine = false;
        }
        if (zero == true)
        {
            _inputField.text += "0";
            zero = false;
        }

        if (ok == true)
        {
            int inputAnswer = Int32.Parse(_inputField.text);
            if (inputAnswer == (first + second))
            {
                calculator.active = false;
                RelativeMovement player = gameObject.GetComponent<RelativeMovement>();
                posX = player.transform.position.x;
                posY = player.transform.position.y;
                posZ = player.transform.position.z;

                Menu.level++;
                PlayerPrefs.SetInt("level", Menu.level);
                PlayerPrefs.SetFloat("x", posX);
                PlayerPrefs.SetFloat("y", posY);
                PlayerPrefs.SetFloat("z", posZ);

                Menu.newLevel = true;
                gm.active = true;
                Time.timeScale = 0;
            }
            else
            {
                _inputField.text = "";
                timeEq = 5;
            }
            ok = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        RelativeMovement player = other.GetComponent<RelativeMovement>();
        if (Menu.level == 3 && player != null)
        {
            NewNumbers();
        }
       

    }

 


    public static bool one = false;
    public void OneClick()
    {
        one = true;
    }

    public static bool two = false;
    public void TwoClick()
    {
        two = true;
    }

    public static bool three = false;
    public void ThreeClick()
    {
        three = true;
    }

    public static bool four = false;
    public void FourClick()
    {
        four = true;
    }

    public static bool five = false;
    public void FiveClick()
    {
        five = true;
    }

    public static bool six = false;
    public void SixClick()
    {
        six = true;
    }

    public static bool seven = false;
    public void SevenClick()
    {
        seven = true;
    }

    public static bool eight = false;
    public void EightClick()
    {
        eight = true;
    }

    public static bool nine = false;
    public void NineClick()
    {
        nine = true;
    }

    public static bool zero = false;
    public void ZeroClick()
    {
        zero = true;
    }



    public static bool ok = false;
    public void OkClick()
    {
        ok = true;
    }

    private void NewNumbers()
    {
        System.Random rand = new System.Random();
        first = rand.Next(100, 999);
        second = rand.Next(11, 99);
        _textFirst.text = first.ToString();
        _textSecond.text = second.ToString();
        calculator.active = true;
    }

}
