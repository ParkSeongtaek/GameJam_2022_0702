using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    static GameManager _instance;
    static SystemScript _sys;
    int _MaxPoint;
    int _Point;
    bool _GameOver;
    bool _T_R_Able;
    bool _time1;
    bool _time2;
    float _LavaSpeed;


    public bool T_R_Able { get { return T_R_Able; } set { T_R_Able = value; } }
    public bool time1 { get { return _time1; } set { _time1 = value; } }
    public bool time2 { get { return _time2; } set { _time2 = value; } }
    public float LavaSpeed { get { return _LavaSpeed; } set { _LavaSpeed = value; } }

    public bool GameOver { 
        get { return GameOver; } 
        set { 
            GameOver = value;
            if (GameOver)
            {
                SaveData();
            }
            else
            {

            }
        } 
    }
    public int MaxPoint { get { return _MaxPoint; } set { _MaxPoint = value; } }
    public int Point { get { return _Point; } set { _Point = value; } }



    public static GameManager Instance { get { Init(); return _instance; } }
    //public bool T_R_Able { get { return T_R_Able; } set { T_R_Able = value; } }
    public static SystemScript System_Manager { get {return _sys; } }




    // Start is called before the first frame update
    void Start()
    {

        Init();
        StartSet();
    }

    // Update is called once per frame
    void Update()
    {

    }

    static void Init()
    {
        if (_instance == null)
        {
            GameObject GM = GameObject.Find("GameManager");
            if (GM == null)
            {
                GM = new GameObject("GameManager");
                GM.AddComponent<GameManager>();

            }

            DontDestroyOnLoad(GM);
            _instance = GM.GetComponent<GameManager>();


        }


    }



    void StartSet()
    {

        _MaxPoint = new int();
        _Point = new int();

        _T_R_Able = new bool();
        _time1 = new bool();
        _time2 = new bool();
        _LavaSpeed = new float();

        _T_R_Able = true;
        _time1 = true;
        _time2 = false;

        _LavaSpeed = 0.3f;

        _MaxPoint = PlayerPrefs.GetInt("MaxPoint",0);



    }

    void SaveData()
    {
        _MaxPoint = MaxPoint > Point ? MaxPoint : Point;
        PlayerPrefs.SetInt("MaxPoint", _MaxPoint);
    }


}
