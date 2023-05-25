using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;    // Linq �ý��� �����´�.

public class PositionList : MonoBehaviour    // ���� 2�Ÿ� �̻� �ִ� ���� ����
{
    public List<Vector3> positionList;             // ���� Vector ����Ʈ�� �������� ���ؼ� ����
    public List<Vector3> filter_positionList;    // ���� �� ������ ����Ʈ
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
