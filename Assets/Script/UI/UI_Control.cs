using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Control : MonoBehaviour
{
    // Start is called before the first frame update
    public void TimeToTime()
    {
        if (GameManager.instance.Time1)
        {
            GameManager.instance.Time1 = !GameManager.instance.Time1;
        }
        
    }


}
