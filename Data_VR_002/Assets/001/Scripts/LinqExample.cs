using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqExample : MonoBehaviour
{
    public List<int> numbersA = new List<int>();
    public List<int> numbersB = new List<int>();
    public List<int> except = new List<int>();
    public List<int> intersect = new List<int>();
    public List<int> union = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        numbersA.Add(1);
        numbersA.Add(2);
        numbersA.Add(5);
        numbersA.Add(8);

        numbersB.Add(1);
        numbersB.Add(3);
        numbersB.Add(5);
        numbersB.Add(7);
        numbersB.Add(9);

        // 차집합 : numbersA에서 numberB가 중복 되면 제외한다.
        //결과 2,8
        except = numbersA.Except(numbersB).ToList();

        //교집합 : numbersA에서 numbersB가 중복 되면 저장한다
        //결과 1, 5
        intersect = numbersA.Intersect(numbersB).ToList();

        //합집합 : numbersA에서 numbersB가 중복을 하나로 처리하여 모두 저장한다.
        //결과 1, 2, 5, 8, 3, 7, 9

        union = numbersA.Union(numbersB).ToList();

    }

}
