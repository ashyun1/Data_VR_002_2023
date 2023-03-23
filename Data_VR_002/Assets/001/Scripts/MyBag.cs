using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Myltem            //�� ������ Ÿ�� ����
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
        Debug.Log("=========== ���� =============");
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
            Debug.Log(_value.itemName + "�� ó������ ���濡 �־����ϴ�. ");
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
            Debug.Log(_value.itemName + "�� ���濡 �־����ϴ�.");
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
                Debug.Log(_value.itemName + "�� �����ϴ�.");

                --length;
                return;

            }
            searchNode = searchNode.nextNode;
        }
        Debug.Log("�� " + _value.itemName + "�� �����ϴ�. ");
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
            temp.itemName = "HP ����";
            temp.itemType = 1;
            linkedList.Add(temp);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            Myltem temp = new Myltem();
            temp.itemName = "������";
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
            temp.itemName = "HP ����";
            temp.itemType = 1;
            linkedList.Add(temp);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Myltem temp = new Myltem();
            temp.itemName = "������";
            temp.itemType = 2;
            linkedList.Add(temp);
        }

    }
}
