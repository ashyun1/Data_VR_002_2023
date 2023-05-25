using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashTableExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Hashtable hashtable = new Hashtable();                  //해시 테이블 선언 

        // 키-값 쌍 추가
        hashtable.Add("Apple", 3);
        hashtable.Add("Banana", 5);
        hashtable.Add("Orange", 2);

        // 값 검색
        int appleCount = (int)hashtable["Apple"];
        Debug.Log("Apple count : " + appleCount);

        // 키-값 쌍 수정
        hashtable["Apple"] = 4;
        // 키-값 삭제
        hashtable.Remove("Banana");

        // 값 검색 
        int appleCount2 = (int)hashtable["Apple"];
        Debug.Log("Apple count : " + appleCount2);

    }

    // Update is called once per frame
    void Update()
    {

    }
}

