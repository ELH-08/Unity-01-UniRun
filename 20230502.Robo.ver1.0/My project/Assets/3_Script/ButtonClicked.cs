using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{

    //private GUITexture _thisObjBtn;
    //private Image _thisObjBtn;



    public GameObject _target;                  //목표 : 플레이어
    public string methodName = "ReGame";    //_functionName 변수에 ReGame(게임 재시작 함수) 함수명을 저장



    void Start()
    {

        //_thisObjBtn = gameObject.GetComponentInChildren<Image>();

    }



    public void BtnReGame() //버튼 재시작 함수
    {
        if (_target != null)                                                         //목표 변수가 있으면
            _target.SendMessage(methodName, SendMessageOptions.DontRequireReceiver); //플레이어에게 메세지보내기(게임 재시작 함수를 찾아라)

    }


    /*    // Update is called once per frame
        void Update()
        {

            if( Input.GetMouseButtonDown(0))
            {
                if (_thisObjBtn.Raycast(Input.mousePosition, Camera.main))
                {

                    if (_target != null)
                    {
                    }
                }
            }
        }*/
}
