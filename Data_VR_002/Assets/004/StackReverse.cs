using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackReverse : MonoBehaviour
{
    Stack<int> stackNumber = new Stack<int>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            stackNumber.Push(i);                                        //Push 스택에 밀어넣는 함수 
                                                                        // => 0/1/2/3/4/5/6/7/8/9
        }

        string temp = "";

        while (stackNumber.Count > 0)
        {
            temp += stackNumber.Pop().ToString() + " / ";               //Pop 스택에 맨 위에 있는것을 빼낸다. 
        }

        Debug.Log(temp);                                                // => 9/8/7/6/5/4/3/2/1/0/

    }

}
