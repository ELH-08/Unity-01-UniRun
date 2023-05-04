using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGM : MonoBehaviour
{

 
	void Start () {
	
	}
	
 
	void Update () {
	
	}


    void LoadScene()
    {
        Debug.Log("test");
        SceneManager.LoadScene("1_play");
    }
}
