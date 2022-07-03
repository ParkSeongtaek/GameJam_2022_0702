using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;         //�� Ŭ������ ��ü�Դϴ�. �츮�� �������� �� ��ü�� ���� �Ŵ������ �����ϰ� ����� ���Դϴ�.
    public GameObject Fever;
    public bool GameOver = false;               //������ �����Ǿ����� �˾ƺ��� �οﰪ�Դϴ�.
    public int Get_Point = 0;                   //���� ������ �� ��Ÿ�� ����Ʈ�Դϴ�.
    public bool isPause = false;                        //��������ΰ�?
    public float FrameTime = 0.5f;
    public float Sound = 0f;


    bool _Time1;
    bool _Time2;
    public bool Time1 { get { return _Time1; } set { _Time1 = value; _Time2 = !(value); } }
    public bool Time2 { get { return _Time2; } set { _Time2 = value; _Time1 = !(value); if (_Time2) { Make_Tetris.Maker.Startsequence(); } } }

    int max_Point = 0;
    public float TetrisSpeed = 0.1f;
    public float PlayerSpeed = 10.0f;

    public float firstHeight = 0.0f; // firstť�� y�� �Դϴ�.
    public bool gameStop; //������ �Ͻ����� �������� Ȯ���ϴ� �οﰪ�Դϴ�.


    //PlayerPrefs
    string strMax_Point = "aenfl;sdkn4felknarvk8ld9fe";

    private void Awake()                        //Scene �̵��� �ϴ��� �� ��ü�� �μ����� �ʽ��ϴ�. Scene �̵��� ���� � ������ ��ü�� �μ����� �ʴ��� Ȯ���غ��ô�. 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        
        max_Point = PlayerPrefs.GetInt(strMax_Point, 0);
        Time2 = true;
    }
    private void Start()
    {
        //Fever = GameObject.Find("Fever");
        Screen.SetResolution(1440, 2960, true);
        max_Point = PlayerPrefs.GetInt(strMax_Point, 0);
    }

    public void SaveData()                                      //���� ���� ����Դϴ�.
    {
        PlayerPrefs.SetInt(strMax_Point, Get_Point);
        max_Point = Get_Point;
    }
    public int Get_Max_Point()                                       //������ ������ �ҷ����� ����Դϴ�.
    {
        return max_Point;
    }

    public void RE_Max_Point()
    {
        max_Point = 0;
    }
    
    public void SaveSound(float sound)
    {
        PlayerPrefs.SetFloat("SoundSave", sound);
    }
    public float GetSound()
    {
        return PlayerPrefs.GetFloat("SoundSave", 0f);
    }


}