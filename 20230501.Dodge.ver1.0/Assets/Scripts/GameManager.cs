using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                //UI관련 Library
using UnityEngine.SceneManagement;   //Scene 관리 관련 Library



public class GameManager : MonoBehaviour
{
    //선언
    public GameObject gameoverText; //게임오버 텍스트
    public Text timeText;           //생존시간 텍스트
    public Text recordText;         //최고기록 텍스트

    private float surviveTime;      //생존시간
    private bool isGameover;        //게임오버 상태
 
    void Start()  // (3) - (script 활성화시) 1회 호출 / coroutine 가능
    {
        //초깃값
        surviveTime = 0;
        isGameover = false;


        
    }

 
    void Update()  // (4) - (script 활성화시) 매 frame마다 호출(불규칙), 화면 rendering 주기와 일치
    {
        //게임오버가 아니면
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;                  //생존시간 갱신
            timeText.text = "Time:" + (int)surviveTime;     //timeText의 text 영역에 Time : 생존시간 표시
        }
        else //게임오버 상태이면
        {
            if (Input.GetKeyDown(KeyCode.R))            //R키를 누르면
            {
                SceneManager.LoadScene("SampleScene");  //build 목록에 등록된 SampleScene 로드
            }
        }
    }


    public void EndGame() //게임오버 함수
    {
        isGameover = true;              //게임오버 상태이면
        gameoverText.SetActive(true);   //gameoverText 활성화

        float bestTime = PlayerPrefs.GetFloat("BestTime"); //플레이어 설정의 BestTime에 저장된 최고기록 가져오기

        if (surviveTime > bestTime) //생존시간>최고기록 이면
        {
            bestTime= surviveTime;                      //최고기록에 생존시간 값을 저장
            PlayerPrefs.SetFloat("BestTime",bestTime);  //변경된 최고기록을 저장
            recordText.text = "Best Time:" + (int)bestTime; //recordText의 text요소에 Best Time : bestTime값 을 표시

        }
    }





}
