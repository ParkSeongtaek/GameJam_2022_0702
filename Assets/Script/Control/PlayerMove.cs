using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour
{
    bool Left = false;
    bool Right = false;
    
    float Power = 10.0f;
    public bool Jmp;
    // Start is called before the first frame update
    void Start()
    {
        Jmp = true;
    }
    public void PointerDownL()
    {
        Left= true;
    }

    public void PointerUpL()
    {
        Left = false;
    }
    public void PointerDownR()
    {
        Right= true;
    }

    public void PointerUpR()
    {
        Right = false;
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.anyKey && GameManager.instance.Time1)
        {
            //if (Left)
            if(Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * Time.deltaTime * GameManager.instance.PlayerSpeed;

            }
            //if (Right)
            if (Input.GetKey(KeyCode.D))

            {
                transform.position += Vector3.right * Time.deltaTime * GameManager.instance.PlayerSpeed;

            }
            if (Input.GetKeyDown(KeyCode.Space) && Jmp)
            {
                Jmp = false;
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Power) , ForceMode2D.Impulse);

            }



        }
    }
    void Jump()
    {
        if (Jmp)
        {
            Jmp = false;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Power), ForceMode2D.Impulse);
        }
    }

}
