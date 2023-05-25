using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, int> inventory = new Dictionary<string, int>();

        inventory.Add("Apple", 3);
        inventory.Add("Banana", 5);
        inventory.Add("Orange", 2);

        int appleCount = inventory["Apple"];
        Debug.Log("Apple count : " + appleCount);

        inventory["Apple"] = 4;

        inventory.Remove("Banana");

        foreach (KeyValuePair<string, int> item in inventory)
        {
            Debug.Log("Item : " + item.Key + ", Count : " + item.Value);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
