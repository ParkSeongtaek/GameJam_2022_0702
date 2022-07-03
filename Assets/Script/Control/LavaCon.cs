using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCon : MonoBehaviour
{
    static float upfloat  = 0.25f;
    float uptime = 100f;
    float upnum = 100f;
    float Tick = 0.5f;

    Vector3 Up = new Vector3(0, upfloat, 0);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LavaUp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LavaUp()
    {
        while (GameManager.instance.Time1)
        {
            this.gameObject.transform.position += Up;
            yield return new WaitForSeconds(uptime/upnum);
            upnum += Tick;
        }

    }
}
