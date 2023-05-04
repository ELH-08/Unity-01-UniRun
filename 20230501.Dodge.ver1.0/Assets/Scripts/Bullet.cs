using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8f; //탄알 속력
    private Rigidbody bulletRigidbody; //탄알 물리엔진


 
    void Start()// (3) - (script 활성화시) 1회 호출 / coroutine 가능
    {
        //초깃값
        bulletRigidbody= GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward*speed; //탄알 물리속도 = 앞 방향 * 속력

        Destroy(gameObject, 3f);//3초뒤 자기 객체 파괴
    }

   
    void Update() // (4) - (script 활성화시) 매 frame마다 호출(불규칙), 화면 rendering 주기와 일치
    {
        
    }

    //충돌 - 트리거일경우
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")  //충돌한 객체의 태그가 플레이어이면
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); //객체의 PlayerController 요소 가져오기

            if (playerController != null) // PlayerController 요소를 가져오는데 성공하면
            {
                playerController.Die();  //PlayerController의 Die() 호출
            }
        }



    }
}
