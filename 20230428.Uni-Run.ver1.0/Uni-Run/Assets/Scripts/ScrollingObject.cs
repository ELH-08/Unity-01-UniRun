using UnityEngine;

// 게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour {
    public float speed = 10f; // 이동 속도





    private void Update() 
    {

        if (!GameManager.instance.isGameover)   //게임매니저-인스턴스-게임오버가 아니라면 
        {
            //평행이동
            transform.Translate(Vector3.left * speed * Time.deltaTime); //초당 speed값의 속도로 좌측 평행이동

        }
         

    }








}