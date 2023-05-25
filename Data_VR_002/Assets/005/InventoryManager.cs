using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item                                   //Item Class 선언
{
    public string itemName;
    public int itemID;
    public int itemCount;
}

public class InventoryManager : MonoBehaviour
{
    public Dictionary<int, Item> inventory = new Dictionary<int, Item>();                   //Dictionary 선언 (int, Item)    
    public void AddItem(Item newItem)                                                       //아이템 추가 함수
    {
        if (inventory.ContainsKey(newItem.itemID))                                           //ContainsKey 해당 ID값이 있나 검색
        {
            inventory[newItem.itemID].itemCount += newItem.itemCount;                       //값이 있을경우 itemCount를 늘려준다.
        }
        else
        {
            inventory.Add(newItem.itemID, newItem);                                         //값이 없을경우 새로 입력
        }

    }
    public void RemoveItem(int itemID, int count = 1)                                       //아이템 제거 함수
    {
        if (inventory.ContainsKey(itemID))                                                  //ContainsKey 해당 ID값이 있나 검색                                        
        {
            inventory[itemID].itemCount -= count;                                           //count 를 뺀다. 

            if (inventory[itemID].itemCount <= 0)                                            //0 이하일경우 제거
            {
                inventory.Remove(itemID);
            }
        }
    }
    public Item GetItem(int itemID)
    {
        if (inventory.ContainsKey(itemID))                                                  //ContainsKey 해당 ID값이 있나 검색                                        
        {
            return inventory[itemID];
        }
        else
        {
            return null;
        }
    }

    public void PrintInventory()
    {
        foreach (KeyValuePair<int, Item> item in inventory)                                      //전체적으로 돌면서 프린트
        {
            Debug.Log("Item: " + item.Value.itemName + " , Count : " + item.Value.itemCount);
        }
    }
}
