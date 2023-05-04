using UnityEngine;
using System.Collections;


//몽둥이에 충돌이 일어나는 시점에, 충돌체의 태그가 Player인 경우 HP를 깎음
public class EnemyAttackScript : MonoBehaviour 
{
	
	public EnemyScript _EnemySt;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "player")
        {
            Vector3 _Vec = (other.transform.position - transform.position).normalized; // A(원하는 목표=플레이어) - B(나의 위치=적) 방향 저장
            _Vec.y=0;
            other.transform.localPosition += _Vec * 0.5f; //플레이어 \하위에 래빗이 있어서 local로   position, rotation, 마다따로있음
			other.SendMessage("Damaged",10.0f);
        }
        
    }
}
