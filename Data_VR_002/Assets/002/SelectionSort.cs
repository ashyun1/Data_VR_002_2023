using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SelectionSort : MonoBehaviour
{
    public int NumberOfCubes = 10;
    public int CubeHeightMax = 10;
    public GameObject[] Cubes;
    // Start is called before the first frame update
    void Start()
    {
        InitalizeRandom();
        StartCoroutine(SelectionSortfunction(Cubes));
    }
    void InitalizeRandom()
    {
        Cubes = new GameObject[NumberOfCubes];  //10개 큐브를 생성한다. 

        for (int i = 0; i < NumberOfCubes; i++)
        {
            int randomNumber = Random.Range(1, CubeHeightMax + 1);  //랜덤하게 큐브를 생성 (1 ~ 10)

            GameObject Temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Temp.transform.localScale = new Vector3(0.9f, randomNumber / 2.0f, 1);
            Temp.transform.position = new Vector3(i - 5, randomNumber / 4.0f, -1);
            Temp.transform.parent = this.transform;                     //부모 오브젝트 하이러키 안쪽에 넣는다. 
            Cubes[i] = Temp;
        }
    }

    IEnumerator SelectionSortfunction(GameObject[] unsortedList)
    {
        int min;
        GameObject temp;
        Vector3 tempPosition;

        for (int i = 0; i < unsortedList.Length; i++)    //GameObject 길이동안 반복
        {
            min = i;
            yield return new WaitForSeconds(1); // for 문안에서 1초씩 끈어서 동작을 보여준다. 
            for (int j = i + 1; j < unsortedList.Length; j++)
            {
                if (unsortedList[j].transform.localScale.y < unsortedList[min].transform.localScale.y)
                {   //높이를 비교하여서 변경할 것을 선정
                    min = j;
                }
            }

            if (min != 1)    //변경이 필요한 경우 
            {
                yield return new WaitForSeconds(1);
                temp = unsortedList[i];
                unsortedList[i] = unsortedList[min];
                unsortedList[min] = temp;               //배열에서의 위치 교환을 한다. 
                tempPosition = unsortedList[i].transform.localPosition; //실제로 화면에서 교체되어야할 위치를 선정 

                LeanTween.moveLocalX(unsortedList[i], unsortedList[min].transform.localPosition.x, 1);
                LeanTween.moveLocalZ(unsortedList[i], -3, 0.5f).setLoopPingPong(1);

                LeanTween.moveLocalX(unsortedList[min], tempPosition.x, 1);
                LeanTween.moveLocalZ(unsortedList[min], 3, 0.5f).setLoopPingPong(1);
            }
            LeanTween.color(unsortedList[i], Color.green, 1.0f);    //교체될것 초록색으로 표시 
        }
    }

}
