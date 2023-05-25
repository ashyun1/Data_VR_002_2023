using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;    // Linq 시스템 가져온다.

public class PositionList : MonoBehaviour    // 나와 2거리 이상에 있는 것을 정렬
{
    public List<Vector3> positionList;             // 원본 Vector 리스트를 가져오기 위해서 선언
    public List<Vector3> filter_positionList;    // 필터 후 정렬할 리스트
    void Start()
    {
        LINQFunction();
        
    }

    public void LINQFunction()
    {
        filter_positionList = new List<Vector3>();

        filter_positionList = positionList
            .Where(n => Vector3.Distance(transform.position, n) > 2f)
            .OrderBy(n => Vector3.Distance(transform.position, n))
            .ToList();
    }

   
}
