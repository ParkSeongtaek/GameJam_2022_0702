using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controllable_Collision : MonoBehaviour
{

    Make_Tetris Maker;
    const float Dtime = 0.5f;
    float timer = 0.0f;
    Vector3 current;

    bool Coll = false;
    bool Physics = true;
    bool currentcheck = false;

    float DownSpeed = 15f;

    float fortest = 1f;
    float FirstHeight = 0.0f;

    int Left = 0;
    bool LeftAble = true;
    bool RightAble = true;

    Vector3 downFrame = new Vector3(0, 0.25f, 0);
    
    private void Start()
    {
        Maker = Make_Tetris.Maker;
        //FirstHeight = GameManager.instance.firstHeight;

        StartCoroutine("this_Down");


    }
    private void Update()
    {

        if (Input.anyKey && GameManager.instance.Time2)
        {
            if(this.gameObject.tag == "Controllable")
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (LeftAble)
                    {
                        Left = 1;
                        transform.position += Vector3.left * 0.5f;//* GameManager.instance.TetrisSpeed;
                        RightAble = true;
                    }
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (RightAble)
                    {
                        Left = -1;
                        transform.position += Vector3.right * 0.5f; //* GameManager.instance.TetrisSpeed;
                        LeftAble = true;
                    }
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (!Coll)
                    {
                        transform.position += Vector3.down * Time.deltaTime  * DownSpeed;

                    }
                }
            }
        }

        if (this.Physics)
        {
            if (this.transform.position.y < FirstHeight - 25 * fortest)
            {
                if (!this.currentcheck)
                {
                    current = this.transform.position;
                    this.currentcheck = true;
                }
                timer += Time.deltaTime;
                if (timer >= Dtime)
                {
                    this.currentcheck = false;
                    timer = 0.0f;
                    if (current.y < this.transform.position.y + 0.5f && current.y > this.transform.position.y - 0.5f && current.x > this.transform.position.x - 0.5f && current.x < this.transform.position.x + 0.5f)
                    {

                        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                        this.Physics = false;
                    }

                }

            }

        }
        else
        {
            if (this.transform.position.y < GameManager.instance.firstHeight - 75 * fortest)
            {
                Destroy(this.gameObject);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Block" && this.gameObject.tag == "Controllable")
        {

            //Debug.Log("????????????????????????????????????????????????????/");
            if (Left > 0)
            {
                LeftAble = false;
            }
            else if (Left < 0)
            {
                RightAble = false;
            }
        }

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        float y = this.gameObject.transform.position.y;
        
        
        if (col.gameObject.tag == "Ground" && this.gameObject.tag == "Controllable")
        {
            Coll = true;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, y, this.gameObject.transform.position.z);
            this.gameObject.tag = "Ground";
            StopCoroutine("this_Down");
            GameManager.instance.firstHeight = this.gameObject.transform.position.y;

            Maker.num++;
            if (Maker.num >= 5)
            {
                Maker.num = 0;
                GameManager.instance.Time1 = true;          
            }
            else
            {
                Maker.Startsequence();
            }
            

        }
        

    }
    

    IEnumerator this_Down()
    {
        while (true)
        {
            this.gameObject.transform.position -= downFrame;

            //Debug.Log("Hello");
            Debug.Log(GameManager.instance.FrameTime);
            yield return new WaitForSeconds(GameManager.instance.FrameTime);
        }
        
    }
    IEnumerator TagChange(float Time)
    {
        yield return new WaitForSeconds(Time);

        this.gameObject.tag = "Ground";
        GameManager.instance.firstHeight = this.gameObject.transform.position.y;

        Maker.Startsequence();
        //StopCoroutine("this_Down");

        
    }


}
