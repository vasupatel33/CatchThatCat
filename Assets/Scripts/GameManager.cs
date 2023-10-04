using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject HexagonObj, ParentObj;
    [SerializeField] List<GameObject> AllHexagon,evenObject, oddObject;
    bool flag;
    int no = 1;
    public int middlePoint;
    public static GameManager instance;
    
    void Start()
    {
        instance = this;
        //middlePoint = 60;
        for (int i = 1; i <= 11; i++)
        {
            for (int j = 1; j <= 11; j++)
            {
                GameObject game = Instantiate(HexagonObj ,ParentObj.transform);
                AllHexagon.Add(game);
                game.name = no.ToString();
                no++;
                if (!flag)
                {
                    HexagonObj.transform.position = new Vector3(j * 0.9f, i * 0.9f, 0);
                    evenObject.Add(game);
                }
                else
                {
                    HexagonObj.transform.position = new Vector3(0.5f + (j * 0.9f), i * 0.9f, 0);
                    oddObject.Add(game);
                }
                
            }
            flag = !flag;
        }
        ParentObj.transform.position = new Vector3(-5.4f,-5.5f,0);
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
        middlePoint = 54;

        AllHexagon[middlePoint].gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        if (oddObject.Contains(AllHexagon[middlePoint]))
        {
            AllHexagon[middlePoint + 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint + 12].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint + 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 10].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            AllHexagon[middlePoint + 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint + 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint + 10].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 12].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
