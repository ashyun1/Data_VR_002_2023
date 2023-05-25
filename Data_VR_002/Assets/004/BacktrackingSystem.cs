using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktrackingSystem : MonoBehaviour
{
    private Stack<Vector3> positionStack = new Stack<Vector3>();            //스택 Vetor3 위치값 저장 모델 

    public float speed = 5f;                                                //이동속도

    private Rigidbody rb;                                                   //물리 컴포넌트
    public float checkTime = 0.0f;                                          //반복되는 시간 설정하기 위한 변수 

    void Start()
    {
        rb = GetComponent<Rigidbody>();                                     //캐릭터 컴포넌트 가져오기
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Backspace))                                     //백스페이스를 눌렀을때
        {
            if (positionStack.Count > 0)                                     //스택이 비어있지 않다면
            {
                Vector3 prevPos = positionStack.Pop();                      //스택에서 빼내서 내 위치를 갱신
                transform.position = prevPos;
            }
        }
        checkTime += Time.deltaTime;                                         //Update 에서 프레임간격 초를 쌓아서 시간 설정

        if (checkTime > 0.2f)                                                 //0.2초마다 
        {
            Vector3 currPos = transform.position;                            //지금 위치를 스택에 넣는다.
            positionStack.Push(currPos);
            checkTime = 0.0f;
        }

    }
    private void FixedUpdate()                                               //움직임 구현
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical);            //이동 백터 설정
        if (movement != Vector3.zero)                                         //이동 백터가 Zero 가 아닐경우
        {
            transform.rotation = Quaternion.LookRotation(movement);          //이동 방향 백터로 캐릭터 전환
        }
        rb.velocity = movement.normalized * speed;                           //물리 컴포넌트 이동 설정
    }

}
