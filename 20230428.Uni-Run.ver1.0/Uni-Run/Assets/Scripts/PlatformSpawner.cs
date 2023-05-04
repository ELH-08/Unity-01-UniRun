using UnityEngine;

// 발판을 생성하고 주기적으로 재배치하는 스크립트
public class PlatformSpawner : MonoBehaviour {
    public GameObject platformPrefab; // 생성할 발판의 원본 프리팹
    public int count = 3; // 생성할 발판의 개수

    public float timeBetSpawnMin = 1.25f; // 다음 배치까지의 시간 간격 최솟값
    public float timeBetSpawnMax = 2.25f; // 다음 배치까지의 시간 간격 최댓값
    private float timeBetSpawn; // 다음 배치까지의 시간 간격

    public float yMin = -3.5f; // 배치할 위치의 최소 y값
    public float yMax = 1.5f; // 배치할 위치의 최대 y값
    private float xPos = 20f; // 배치할 위치의 x 값

    private GameObject[] platforms; // 미리 생성한 발판들
    private int currentIndex = 0; // 사용할 현재 순번의 발판

    private Vector2 poolPosition = new Vector2(0, -25); // 초반에 생성된 발판들을 화면 밖에 숨겨둘 위치
    private float lastSpawnTime; // 마지막 배치 시점





    void Start() 
    {

        /* 발판 미리 생성 */
        platforms = new GameObject[count]; //초깃값 설정

        for (int i=0; i<count;  i++) //count만큼 무한반복 
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity); //발판 생성 : 인스턴트화해서 생성해 배열에 저장
        }

        lastSpawnTime = 0f; //배치 시점 초기화
        timeBetSpawn = 0f;  //배치 시간간격 0으로 초기화

    }





    void Update() 
    {


        //게임오버일때 실행 금지
        if (GameManager.instance.isGameover) //게임오버 상태이면
        { 
            return; //실행X 
        }


        // 순서를 돌아가며 주기적으로 발판을 배치
        if (Time.time >= lastSpawnTime + timeBetSpawn) //마지막배치 시점에서 timeBetSpawn 이상 시간이 흐르면
        {
            lastSpawnTime= Time.time; //기록된 마지막배치시점을 현 시점으로 갱신

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax); //다음배치 시간간격을 랜덤설정

            float yPos = Random.Range(yMin, yMax);//배치할 위치의 높이 랜덤 설정


            platforms[currentIndex].SetActive(false); //현재 순서의 발판 객체를 비활성화
            platforms[currentIndex].SetActive(true);  //현재 순서의 발판 객체를 다시 활성화, 이때 onEnable() 실행?

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos); //현재 순서의 발판 객체를 화면 오른쪽에 재배치

            currentIndex++; //순번 넘기기

            if (currentIndex >= count) //현 순서가 마지막 순번을 초과하면
            {
                currentIndex = 0; //순서 리셋

            }
        }






    }







}