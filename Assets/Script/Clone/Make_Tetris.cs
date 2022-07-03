using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_Tetris : MonoBehaviour
{
    public static Make_Tetris Maker; 
    // Start is called before the first frame update
    public GameObject worldCube;
    public GameObject[] prefabCube;

    public GameObject BeforeCube;
    float Feverxval = 2.1f;
    int idx = 0;

    public int num = 0;
    bool isMove;
    float gravity = 0;
    bool start;
    int cubenum;
    Vector3 StartPoint;
    int cnt = 0;
    int cubeBeforeNum;


    Vector3 Down = new Vector3(0, -1, 0);
    private void Start()
    {
        Maker = this;

        prefabCube = Resources.LoadAll<GameObject>("Prefab/T");
        start_true();
        cubenum = prefabCube.GetLength(0);
        Startsequence();
        start = false;
    }

    
    public void Startsequence()    //시작 시퀀스 블록을 조건에 따라 생성한다
    {
        if (BeforeCube == null || BeforeCube.gameObject.tag != "Controllable" )
        {
            if (GameManager.instance.Time2)
            {
                //StopCoroutine("WaitAFrame");

                cubeBeforeNum = Random.Range(0, cubenum);
                worldCube = Instantiate(prefabCube[cubeBeforeNum]);
                worldCube.transform.position = transform.position;
                StartPoint = worldCube.transform.position;
                worldCube.GetComponent<Rigidbody2D>().gravityScale = 0;
                isMove = false;
            }
            
        }

    }

    void start_true()
    {
        start = true;
    }
    // Update is called once per frame

    public void GetKeyDown()
    {
        if (BeforeCube == null)
        {
            if (!GameManager.instance.GameOver && !GameManager.instance.gameStop && !isMove)
            {

                isMove = true;
                worldCube.GetComponent<Rigidbody2D>().gravityScale = 12;
                worldCube.GetComponent<Rigidbody2D>().AddForce(Down * 500f, ForceMode2D.Impulse);
                Invoke("start_true", 2f);

            }
        }
        else if (BeforeCube.gameObject.tag != "Controllable")
        {
            if (!GameManager.instance.GameOver && !GameManager.instance.gameStop && !isMove)
            {
                isMove = true;
                worldCube.GetComponent<Rigidbody2D>().gravityScale = 12;
                worldCube.GetComponent<Rigidbody2D>().AddForce(Down * 500f, ForceMode2D.Impulse);
                Invoke("start_true", 2f);

            }
        }

    }
    IEnumerator WaitAFrame()
    {
        yield return new WaitForSeconds(GameManager.instance.FrameTime);


    }
    public void RotateWorldCube()
    {
        if(GameManager.instance.Time2)
        {
            worldCube.transform.eulerAngles += new Vector3(0, 0, 90);
        }
        else
        {
            GameManager.instance.Time2 = true;

        }

    }

}

