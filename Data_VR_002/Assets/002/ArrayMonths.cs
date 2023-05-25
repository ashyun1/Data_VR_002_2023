using System.Collections;
using System.Collections.Generic;
using System.Globalization;                   
using System;                                
using UnityEngine;

public class ArrayMonths : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] months = new string[12];    

        for (int month = 1; month <= 12; month++)
        {
            DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
            string name = firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-us"));
            months[month - 1] = name;    
        }

        foreach (string month in months)
        {
            Debug.Log(month);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}