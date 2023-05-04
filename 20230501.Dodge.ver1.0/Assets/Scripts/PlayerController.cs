using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    //public Rigidbody playerRigidbody;  //물리엔진 (inspector 창에서 물리엔진을 끌어서 저장할 수 있음)
    private Rigidbody playerRigidbody;  //물리엔진
    public float speed = 8f;            //이속('속력')


    void Start() // (3) - (script 활성화시) 1회 호출 / coroutine 가능
    {
        //초깃값
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update() // (4) - (script 활성화시) 매 frame마다 호출(불규칙), 화면 rendering 주기와 일치
    {

        // 키 입력 (키코드를 하나하나 바꿔서 수정해줘야하기에 자주 사용하진 않는다.)
        if (Input.GetKey(KeyCode.UpArrow) == true)      //상 입력키가 감지되면
        {
            playerRigidbody.AddForce(0f,0f,speed);      //z축 방향으로 물리엔진
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)    //하 입력키가 감지되면
        {
            playerRigidbody.AddForce(0f,0f,-speed);     //-z축 방향으로 물리엔진
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)   //우 입력키가 감지되면
        {
            playerRigidbody.AddForce(speed, 0f, 0f);    //x축 방향으로 물리엔진
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)    //좌 입력키가 감지되면
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);   //-x축 방향으로 물리엔진
        }


        //캐릭터 이동 속도
        float xInput = Input.GetAxis("Horizontal"); //x축 입력값 = 수평축 값 저장
        float zInput = Input.GetAxis("Vertical");   //y축 입력값 = 수직축 값 저장

        float xSpeed = xInput * speed;  //x축 이동속도 = x축 값 * 속력
        float zSpeed = zInput * speed;  //y축 이동속도 = y축 값 * 속력 

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);// Vector3 속도를 (xSpeed, 0, zSpeed)으로 생성
        playerRigidbody.velocity = newVelocity; //물리엔진 속도에 newVelocity를 할당
    
    }



    public void Die()     //캐릭터 사망 함수
    {
 
        gameObject.SetActive(false);//객체를 비활성화 (inspector에서 네모박스 체크 해제)

        GameManager gameManager = FindObjectOfType<GameManager>();//game manager 구성요소 저장
        gameManager.EndGame(); //game manager의 EndGame() 호출

    }
}