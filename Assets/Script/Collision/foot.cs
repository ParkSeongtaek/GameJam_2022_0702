using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    GameObject Player;
    Vector3 Startvector3 = new Vector3();

    private void Start()
    {
        Startvector3 = this.transform.localPosition;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        Player.GetComponent<PlayerMove>().Jmp = true;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        if (collision.gameObject.tag == "Ground")
        {
            Player.GetComponent<PlayerMove>().Jmp = true;

        }
    }


    private void Update()
    {
        this.transform.localPosition = Startvector3;
    }
}
