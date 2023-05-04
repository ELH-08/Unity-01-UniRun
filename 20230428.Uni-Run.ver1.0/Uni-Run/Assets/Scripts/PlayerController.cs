using UnityEngine;
using UnityEngine.Analytics;


// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour 
{

   public float jumpForce = 700f;       // 점프 힘

   private int jumpCount = 0;           // 누적 점프 횟수
   private bool isGrounded = false;     // 바닥에 닿았는지 여부
   private bool isDead = false;         // 사망 상태


   private Rigidbody2D playerRigidbody; // 물리엔진

   private Animator animator;           // Animator 

   private AudioSource playerAudio;     // AudioSource
   public AudioClip backgroundClip;     // 배경음 저장
   public AudioClip deathClip;          // 사망음 저장


    private void Start() 
   {
       // 초깃값 
        playerRigidbody= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        
        //시작시 배경음 반복재생
        playerAudio.clip = backgroundClip;
        playerAudio.loop = true;    //반복 true로 설정한 뒤
        playerAudio.Play();         //재생




   }

   private void Update() {
        // 사용자 입력을 감지하고 점프하는 처리


        //사망시 점프 금지
        if (isDead)     //isDead가 true이면
        {
            return;     //종료 (처리 진행하지 않음)
        }

        //점프
        if (Input.GetMouseButton(0) && jumpCount < 2) //마우스 좌 클릭시 && 최대 점프 횟수 2 미만
        {

            jumpCount++;             //점프 횟수 증가

            playerRigidbody.velocity = Vector2.zero;             //플레이어 물리속도 = (0,0)
            playerRigidbody.AddForce(new Vector2(0, jumpForce)); //플레이어 물리 힘 : 위쪽(y)으로 힘주기
            playerAudio.Play();                                  //플레이어 오디오 재생

        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0 ) //마우스 좌 클릭시 && 플레이어 객체 물리 속도 y(위)가 양이면(상승) 
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f; //플레이어 물리속도= 원래 속도의 절반


        }
        animator.SetBool("Grounded", isGrounded);   //Animator 매개변수 Grounded를 isGrounded값으로 갱신


        

    }

    //사망함수
   public void Die() 
   {
        //애니메이터
        animator.SetTrigger("Die");     // Animator 매개변수 Die 활성화

        //오디오
        playerAudio.clip = deathClip;   // 오디오 소스의 오디오 클립을 deathClip으로 변경
        playerAudio.Play();             // 플레이어 오디오 재생 (사망 효과음)
        
        //처리
        playerRigidbody.velocity = Vector2.zero;    //플레이어 물리속도 (0,0)
        isDead = true;                              //사망 상태 true

        //처리2
        GameManager.instance.OnPlayerDead();    //게임매니저 - 게임오버처리 실행

   }



    // Collider 충돌 - Trigger 감지
    private void OnTriggerEnter2D(Collider2D other) {
 
        if (other.tag == "Dead" && !isDead)  //충돌한 태그가 Dead && 사망하지 않은 상태면
        {
            Die();      //사망 함수 호출
        }

   }

    //collider 충돌 (닿음)
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // 바닥에 닿았음을 감지하는 처리

        if (collision.contacts[0].normal.y > 0.7f) //collider와 닿은 충돌 표면이 위를 보고 있으면
        {
            isGrounded = true;  //바닥착지 여부 true로 변경
            jumpCount = 0;      //누적점프횟수 0
        }

    }

    //collider 충돌 (벗어남)
    private void OnCollisionExit2D(Collision2D collision) {


        isGrounded = false;     //바닥착지 여부 false로 변경

    }




}