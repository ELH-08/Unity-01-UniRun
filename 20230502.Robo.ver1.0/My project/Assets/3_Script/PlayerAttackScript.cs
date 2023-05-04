using UnityEngine;
using System.Collections;

//Hammer 객체에 추가한 Collider 의 IsTrigger가 발동되는 시점에, 해당하는 충돌 객체의 정보를 받아와 태그가 적일 경우 HP를 감소

public class PlayerAttackScript : MonoBehaviour 
{
	

	public PlayerScript _PlayerSt;  //PlayerScript 변수

 
    void Start () 
	{
		//초깃값
		_PlayerSt = GameObject.FindWithTag("player").GetComponent<PlayerScript>();  // (소문자) player의 태그를 단 객체의 스크립트를 가져와 저장
		_PlayerSt._attackChkCol = gameObject.GetComponent<BoxCollider>(); //

		gameObject.GetComponent<BoxCollider>().enabled = false;
	
	}
	
 
	void Update () {
	
	}


    void OnTriggerEnter(Collider other) //충돌감지 대신 트리거 이벤트 작동 함수
    {

        if (other.tag == "enemy") //감지한 객체의 태그가 적군이면
        {
            Vector3 _Vec = (other.transform.position - transform.position).normalized; //_Vec에 감지한 객체 위치 - 현 위치 방향정보 저장
            _Vec.y=0;										//_Vec의 y값 초기화
            other.transform.localPosition += _Vec * 0.5f;   //감지한 객체의 지역좌표에 _Vec * 0.5f 만큼 누적
            other.SendMessage("Damaged",10.0f);				//
        }
        
    }
}
