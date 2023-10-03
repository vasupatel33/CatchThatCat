using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject HexagonObj, ParentObj;
    [SerializeField] List<GameObject> AllHexagon,evenObject, oddObject;
    bool flag;
    int no,middlePoint;
    void Start()
    {
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                //GameObject.Instantiate(HexagonObj, spawnPosition, Quaternion.identity,ParentObj.transform);
                GameObject g = Instantiate(HexagonObj, new Vector3(j * 0.9f, i * 0.9f, 0), Quaternion.identity, ParentObj.transform);
                AllHexagon.Add(g);


                if (!flag)
                {
                    //Vector3 spawnPosition = new Vector3();
                   
                }
                else
                {
                    GameObject obj = Instantiate(HexagonObj, new Vector3(0.5f+(j * 0.9f), i * 0.9f, 0), Quaternion.identity, ParentObj.transform);
                }

                HexagonObj.gameObject.name = no.ToString();
                no++;
            }
            flag = !flag;
        }
        MiddlePoint();
        //int no = 0; // Initialize 'no' to some value
        //float hexWidth = 0.9f; // Width of a singal hexagon
        //float hexHeight = Mathf.Sqrt(3f) / 2f; // or space between two hexagon gameobjects
        //HexagonObj.transform.localScale = new Vector3(1.1f, 1.1f);

        //for (int i = 0; i < 11; i++)
        //{
        //    for (int j = 0; j < 11; j++)
        //    {
        //        float xPos = (j * hexWidth * 1.5f)-7.2f; // represent the position where each hexagon will be placed in the Unity scene
        //        float yPos = (i * hexHeight)-4.25f;

        //        // For even rows, shift every other column to the right
        //        if (i % 2 == 1)
        //        {
        //            xPos += hexWidth * 0.75f;
        //        }

        //        Vector3 spawnPosition = new Vector3(xPos, yPos, 0);

        //        GameObject hexagon = Instantiate(HexagonObj, spawnPosition, Quaternion.identity);

        //        hexagon.transform.SetParent(ParentObj.transform); // Set the parent

        //        hexagon.name = no.ToString();
        //        no++;
        //    }
        //}
    }
    public void MiddlePoint()
    {
        middlePoint = 60;

        AllHexagon[middlePoint].gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
