using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerCtrl : MonoBehaviour
{
    Vector2 _charSpeed;
    Vector2 MoveDir;
    bool onJump;
    float speed = 1f;
    float _jumpSpeed = 10f;
    float _gravity = 1f;
    float _minPosition = -10f;
    float _maxPosition = 10f;

    Rigidbody2D rigid;
    public Slider slider;

    public float jumpSpeed { get { return _jumpSpeed; } set { _jumpSpeed = value; } }
    public float gravity { get { return _gravity; } set { _gravity = value; } }
    public float minPosition { get { return _minPosition; } set { _minPosition = value; } }
    public float maxPosition { get { return _maxPosition; } set { _maxPosition = value; } }


    public void P_sliderSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _charSpeed.x = slider.value;
                _charSpeed *= speed;
                rigid.velocity = _charSpeed;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                slider.value = 0f;
            }
        }
        _charSpeed.x = slider.value;
        _charSpeed *= speed;
        rigid.velocity = _charSpeed;
        if (Input.GetMouseButtonUp(0))
        {
            slider.value = 0f;
        }

        //테스트를 위한 키보드 입력
        float inputX = Input.GetAxis("Horizontal");

        Vector2 velocity = new Vector2(inputX * 10f, 0f);
        velocity *= speed;
        if (Input.GetAxis("Horizontal") != 0f)
            rigid.velocity = velocity;
        if (rigid.position.x <= minPosition) rigid.MovePosition(new Vector2(minPosition + 0.1f, rigid.position.y));
        if (rigid.position.x >= maxPosition) rigid.MovePosition(new Vector2(maxPosition - 0.1f, rigid.position.y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onJump = false;
            Debug.Log("ontheground");
        }
    }
    public void P_Jump()
    {
        if (onJump == false)
        {
            rigid.AddForce(new Vector2(0f, 1f) * _jumpSpeed, ForceMode2D.Impulse);
            onJump = true;
            Debug.Log("점프 실행은 함");
        }
        else return;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0f;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        P_sliderSwipe();
    }
}