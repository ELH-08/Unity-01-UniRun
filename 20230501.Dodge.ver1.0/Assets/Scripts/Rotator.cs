using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f; //바닥회전속도



    void Start() // (3) - (script 활성화시) 1회 호출 / coroutine 가능
    {

    }


    void Update() // (4) - (script 활성화시) 매 frame마다 호출(불규칙), 화면 rendering 주기와 일치
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f); //1초가 아닌 1프레임에 60도 회전

    }
}
