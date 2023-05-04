using UnityEngine;





// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour 
{
    public GameObject[] obstacles;      // 장애물 오브젝트
    private bool stepped = false;       // 플레이어가 밟았는지 여부




    // Component 활성화시 한 번 실행
    private void OnEnable() 
    {
        //밟음 상태 리셋
        stepped = false;

        //장애물 수만큼 루프
        for (int i=0;  i< obstacles.Length;  i++) 
        {
            if (Random.Range(0,3)==0)   //랜덤범위 1/3확률 (0~2 비교시 0이면)
            {
                obstacles[i].SetActive(true); //장애물 오브젝트 활성화
            }
            else 
            {
                obstacles[i].SetActive(false); //장애물 오브젝트 false
            }
        }




    }



    //충돌 처리
    void OnCollisionEnter2D(Collision2D collision) {
        
        // 플레이어가 자신을 밟았을때 점수를 추가하는 처리
        if (collision.collider.tag == "Player" && !stepped) //충돌 태그가 플레이어고 밟지 않았다면
        {
            stepped= true;  //밟은 상태 true
            GameManager.instance.AddScore(1); //게임매니저 점수 추가
            
        }




    }
}