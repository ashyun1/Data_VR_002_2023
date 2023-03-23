using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<int> scores = new List<int>();

 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스왼쪽 버튼
        {
            int randomNumber = Random.Range(0, 100); //랜덤넘버생성
            scores.Add(randomNumber); //리스트에 입력
        }

        if (Input.GetMouseButtonDown(1))
        {
            scores.RemoveAt(3);
        }
        
    }
}
