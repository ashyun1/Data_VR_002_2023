using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Myltem            //내 아이템 타입 설정
{
    public string itemName;
    public int itemType;
}

public class MyNode<T> where T : class
{
    public Myltem myltem;
    public MyNode<T> nextNode;
    public MyNode<T> prevNode;

    public string GetMyltemName()
    {
        return myltem.itemName;
    }
}


public class MyLinkedList<T> where T : class
{
    public MyNode<T> head;
    public MyNode<T> tail;
    public uint length = 0;


    public MyLinkedList()
    {
        head = new MyNode<T>()
        {
            myltem = null
        };

        tail = new MyNode<T>()
        {
            myltem = null
        };

        head.prevNode = null;
        head.nextNode = tail;

        tail.prevNode = head;
        tail.nextNode = null;

     
    }
    public bool IsEmpty()
        {
            return (length == 0);
        }

    public void Print()
    {
        MyNode<T> searchNode = head;
        Debug.Log("=========== 가방 =============");
        while(searchNode.nextNode != tail)
        {
            Debug.Log(searchNode.nextNode.myltem.itemName);
            searchNode = searchNode.nextNode;
        }
    }



    public void Add(Myltem _value)
    {
        MyNode<T> newNode = new MyNode<T>
        {
            myltem = _value
        };

        if(IsEmpty())
        {
            head.nextNode = newNode;
            newNode.prevNode = head;
            newNode.nextNode = tail;
            tail.prevNode = newNode;
            Debug.Log(_value.itemName + "를 처음으로 가방에 넣었습니다. ");
        }
        else
        {
            MyNode<T> searchNode = head;
            while (searchNode.nextNode != tail)
            {
                searchNode = searchNode.nextNode;
            }
            searchNode.nextNode.prevNode = newNode;
            newNode.nextNode = searchNode.nextNode;
            newNode.prevNode = searchNode;
            searchNode.nextNode = newNode;
            Debug.Log(_value.itemName + "를 가방에 넣었습니다.");
        }
        ++length;
    }

    public void Remove(Myltem _value)
    {
        MyNode<T> searchNode = head;

        while (searchNode != tail)
        {
            if (searchNode.myltem != null && searchNode.myltem.itemType == _value.itemType)
            {
                searchNode.nextNode.prevNode = searchNode.prevNode;
                searchNode.prevNode.nextNode = searchNode.nextNode;
                Debug.Log(_value.itemName + "를 뺏습니다.");

                --length;
                return;

            }
            searchNode = searchNode.nextNode;
        }
        Debug.Log("뺄 " + _value.itemName + "가 없습니다. ");
    }

    public bool Constrain(Myltem _value)
    {
        MyNode<T> searchNode = head;
        while (searchNode.nextNode != tail)
        {
            if(searchNode.myltem == _value)
            {
                return true;
            }
        }
        return false;
    }
}



public class MyBag : MonoBehaviour
{
    MyLinkedList<string> linkedList = new MyLinkedList<string>();

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Myltem temp = new Myltem();
            temp.itemName = "HP 포션";
            temp.itemType = 1;
            linkedList.Add(temp);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            Myltem temp = new Myltem();
            temp.itemName = "돌맹이";
            temp.itemType = 2;
            linkedList.Add(temp);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            linkedList.Print();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Myltem temp = new Myltem();
            temp.itemName = "HP 포션";
            temp.itemType = 1;
            linkedList.Add(temp);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Myltem temp = new Myltem();
            temp.itemName = "돌맹이";
            temp.itemType = 2;
            linkedList.Add(temp);
        }

    }
}
