using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorotineSystem : MonoBehaviour
{
    private Queue coroutineQueue = new Queue();                                         //코루틴 관리하는 큐 자료구조
    public void AddCorutineQueue(IEnumerator coroutine)                                 //관리할 코루틴 Add 함수
    {
        coroutineQueue.Enqueue(coroutine);                                              //함수를 통해서 코루틴을 받는다. 
    }

    void Start()
    {
        AddCorutineQueue(Logging(10));
        AddCorutineQueue(Logging(100));
        AddCorutineQueue(Logging(1000));
        if (coroutineQueue.Count > 0)                                                   //시작점에서 코루틴이 큐에 쌓여있으면 하나 빼내서 실행
        {
            StartCoroutine((IEnumerator)coroutineQueue.Dequeue());
        }
    }
    IEnumerator Logging(int number)                                                     //로깅 
    {
        for (int i = number; i < number + 10; i++)
        {
            Debug.Log(i.ToString() + " <---");
            yield return new WaitForSeconds(0.1f);
        }

        if (coroutineQueue.Count > 0)
        {
            StartCoroutine((IEnumerator)coroutineQueue.Dequeue());
        }
    }
}
