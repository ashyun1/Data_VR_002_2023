using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemies : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpInterval = 1f;

    private Queue<GameObject> enemyQueue = new Queue<GameObject>();

    void Start()
    {
        StartCoroutine(SetJumpEnemies());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddEnemyToQueue();
        }
    }

    void AddEnemyToQueue()
    {
        GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);                              //프리미티브 큐브 제작
        enemy.transform.position = new Vector3(Random.Range(-5, 5), 0.5f, Random.Range(-5, 5));         //-5 , 5 범위에 랜덤으로 생성
        enemy.AddComponent<Rigidbody>();                                                                //물리 Rigidbody 붙여준다.
        enemyQueue.Enqueue(enemy);                                                                      //큐에 넣는다.
    }

    IEnumerator SetJumpEnemies()                                            //점프 무한루프 코루틴
    {
        while (true)
        {
            if (enemyQueue.Count > 0)                                        //관리하는 큐에 오브젝트가
            {
                GameObject enemy = enemyQueue.Dequeue();                    //오브젝트 하나를 뺴낸다.
                Rigidbody rb = enemy.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);     //순간힘으로 점프를 시킨다.
                yield return new WaitForSeconds(jumpInterval);              //점프 사이 간격 시간

                Destroy(enemy);                                             //게임 오브젝트 파괴
            }
            yield return null;
        }
    }
}
