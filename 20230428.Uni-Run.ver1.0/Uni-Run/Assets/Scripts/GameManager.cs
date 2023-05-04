using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




// 게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : MonoBehaviour 
{

    public static GameManager instance;     // singleton을 할당할 전역 변수

    public bool isGameover = false;         // 게임오버 여부
    public Text scoreText;                  // 점수를 출력할 UI 텍스트  P51
    public GameObject gameoverUI;           // 게임 오버시 활성화 할 UI 게임 오브젝트

    private int score = 0;                  // 게임 점수






    void Awake() 
    {

        // 싱글톤 : 게임 시작과 동시에 구성
        if (instance == null) //싱글톤 변수 instance가 비어있으면 
        {
            instance = this; //이 스크립트를 할당
        }
        else // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!"); // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            Destroy(gameObject); // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
        }

    }


    void Update() {


        //게임 재시작
        if (isGameover && Input.GetMouseButtonDown(0))  // 게임오버 && 마우스 좌측 키 입력시 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재 씬 재시작
        }
    }




    // Score 증가 함수
    public void AddScore(int newScore) 
    {
        if (!isGameover) //게임오버가 아닐때
        {
            score += newScore; //점수 증가 
            scoreText.text = "Score : " + score;    //텍스트UI에 표시
        }
    }


    // 플레이어 사망
    public void OnPlayerDead() 
    {
        isGameover = true;           //게임오버 true
        gameoverUI.SetActive(true); //게임오버 UI true
        
    }
}