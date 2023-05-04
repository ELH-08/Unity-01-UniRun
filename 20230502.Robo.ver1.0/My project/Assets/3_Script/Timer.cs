using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {


    private TextMeshProUGUI _timer; //alt+enter네임스페이스 불러오기    ctrl+좌클릭 클래스 찾아보기 
    private float _timerForText;
    private int _secText;
    private int _minText;



	void Start () {
        //초깃값
        _timer = gameObject.GetComponent<TextMeshProUGUI>();
	
	}
	

	void Update () 
    {

        _timerForText += Time.deltaTime;

        if (_timerForText > 1.0f)
        {
            _secText += 1;
            if (_secText > 60)
            {
                _minText += 1;
                _secText = 0;
            }
            _timer.text = string.Format("{0:D2}", _minText) + ":" + string.Format("{0:D2}", _secText); //수정 필요
            
            //_timer.text = string.Format("{0:D2}", _minText.ToString()) + ":" + string.Format("{0:D2}", _secText.ToString());
            _timerForText = 0;
        }

	
	}
}
