using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;     //탄알 원본 프리팹
    private Transform target;           //조준할 대상의 위치

    private float spawnRate;            //다음 탄알 생성할 때까지 기다릴 시간
    public float spawnRateMin = 0.5f;   //최소 생성 주기
    public float spawnRateMax = 3f;     //최대 생성 주기

    private float timeAfterSpawn;       //마지막 탄알 생성 시점에서 흐른 누적시간
 
    void Start() // (3) - (script 활성화시) 1회 호출 / coroutine 가능
    {
        //탄알 스폰
        timeAfterSpawn = 0; //0으로 초깃값 설정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //탄알 생성 간격을 spawnRateMin, spawnRateMax 사이로 설정
        target = FindObjectOfType<PlayerController>().transform; // 조준대상 : PlayerController 요소를 가진 객체의 위치
    }

 
    void Update() // (4) - (script 활성화시) 매 frame마다 호출(불규칙), 화면 rendering 주기와 일치
    {
        
        //
        timeAfterSpawn += Time.deltaTime; //누적시간 갱신

        if (timeAfterSpawn >= spawnRate) //누적시간이 spawnRate보다 크거나 같으면
        {
            timeAfterSpawn= 0f;         //누적시간 0

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); //탄알 복제본을 transform.position 위치와 transform.rotation 회전으로 생성

            bullet.transform.LookAt(target); //인스턴스로 생성된 탄알의 정면방향이 target을 향하도록

            spawnRate = Random.Range(spawnRateMin, spawnRateMax); //다음 생성 간격을 spawnRateMin, spawnRateMax 사이로 설정

        }
    }
}
