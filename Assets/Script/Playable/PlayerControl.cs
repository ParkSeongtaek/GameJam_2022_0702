using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragControl : MonoBehaviour
{
    Vector3 _charSpeed;
    float _jumpSpeed;
    float _gravity;
    
    CharacterController _CharCtrl;
    public Slider slider;

    public float jumpSpeed { get { return _jumpSpeed; } set { _jumpSpeed = value; } }
    public float gravity { get { return _gravity; } set { _gravity = value; } }


    private void P_sliderSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _charSpeed.x = slider.value;
                _CharCtrl.Move(_charSpeed * Time.deltaTime);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                slider.value = 0f;
            }
        }
        _charSpeed.x = slider.value;
        _CharCtrl.Move(_charSpeed * Time.deltaTime);
        if (Input.GetMouseButtonUp(0))
        {
            slider.value = 0f;
        }
    }

    private void P_Jump()
    {
        if (_CharCtrl.isGrounded)
        {
            _charSpeed.y = _jumpSpeed;
        }
        _charSpeed.y -= _gravity * Time.deltaTime;

        _CharCtrl.Move(_charSpeed * Time.deltaTime);
    }
}
