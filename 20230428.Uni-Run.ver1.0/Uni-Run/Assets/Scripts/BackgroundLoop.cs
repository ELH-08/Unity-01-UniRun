using UnityEngine;





// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치
public class BackgroundLoop : MonoBehaviour {
    private float width; // 배경의 가로 길이


    private void Awake() 
    {
        // 가로 길이 측정 
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();   //backgroundCollider에 BoxCollider2D저장 
        width = backgroundCollider.size.x;                                  //길이 측정
    }


    private void Update()
    {
        if (transform.position.x <= -width) //현 위치가 원점에서 x축으로 왼쪽으로 width길이 이상 이동시
        {
            Reposition(); //리셋함수 호출
        }
    }


    // 위치 리셋 함수
    private void Reposition()
    {
        //현위치에서 오른쪽 가로 길이 2만큼 이동
        Vector2 offset = new Vector2(width*2f, 0); //offset에 width 2배만큼 저장
        transform.position = (Vector2) transform.position + offset; 

    }





}