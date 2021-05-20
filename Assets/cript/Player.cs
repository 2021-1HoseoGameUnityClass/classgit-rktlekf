//라이브러리
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//클래스
public class Player : MonoBehaviour
{   // 유지보수 및 보안에 의해 public은 위험해 !!
    // → private로 바꾸고 해당 변수 위에 [SerializeField] 설정
    // 변수 선언
    //public float moveSpeed = 3f;
    [SerializeField]
    private float moveSpeed = 3f;


    // Start is called before the first frame update
    // 스크립트가 시작될 때 함수가 실행됨
    void Start()
    {
        
    }

    // Update is called once per frame
    // 프레임마다 함수가 실행됨
    void Update() // == private void Update()
    {
        // 쌍따옴표 사용 시 string 문자열값 받아온다.
        float h = Input.GetAxis("Horizontal");
        float playerSpeed = h * moveSpeed * Time.deltaTime;
        Vector3 vector3 = new Vector3();
        vector3.x = playerSpeed;
        // 해당하는 오브젝트를 이동시킨다.
        transform.Translate(vector3);

        // Horizontal값이 음수라면
        if(h<0)
        {
            // 움직이면 애니메이션값을 바꾼다.
            GetComponent<Animator>().SetBool("Walk", true);
            // 스케일 x값을 -1로 바꾼다.
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(h == 0)
        {
            // 움직이지 않는다면 False로
            GetComponent<Animator>().SetBool("Walk", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walk", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
