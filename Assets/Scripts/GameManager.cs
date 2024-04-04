using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject HexagonObj, ParentObj, winPanel, GameOverPanel, CatObject;
    [SerializeField] List<GameObject> AllHexagon, evenObject, oddObject, clickedObjectList, PossibilityObjectList;
    [SerializeField] Animator CatAnimator;
    [SerializeField] GameObject CatCharacter;

    bool flag;
    int no = 0;
    public int middlePoint;
    public static GameManager instance;

    void Start()
    {
        CatObject.SetActive(true);
        middlePoint = 60;
        instance = this;
        for (int i = 1; i <= 11; i++)
        {
            for (int j = 1; j <= 11; j++)
            {
                GameObject game = Instantiate(HexagonObj, ParentObj.transform);
                AllHexagon.Add(game);
                
                game.name = no.ToString();
                AllHexagon[no].gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                no++;
                if(i==1 || i==11 || j==2 || j==1)
                {
                    //game.GetComponent<SpriteRenderer>().color = Color.blue;
                    game.tag = "Border";
                }

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
        ParentObj.transform.position = new Vector3(-5.4f, -5.5f, 0);
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
        AllHexagon[middlePoint].gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        AllHexagon[middlePoint].gameObject.GetComponent<PolygonCollider2D>().enabled= false;

        PossibilityObjectList.Clear();
        

        if (oddObject.Contains(AllHexagon[middlePoint]))
        {
            AllHexagon[middlePoint + 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint + 12].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint + 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 10].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            PossibilityObjectList.Add(AllHexagon[middlePoint + 1]);
            PossibilityObjectList.Add(AllHexagon[middlePoint - 1]);
            PossibilityObjectList.Add(AllHexagon[middlePoint + 12]);
            PossibilityObjectList.Add(AllHexagon[middlePoint + 11]);
            PossibilityObjectList.Add(AllHexagon[middlePoint - 11]);
            PossibilityObjectList.Add(AllHexagon[middlePoint - 10]);
        }
        else
        {
            AllHexagon[middlePoint + 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 1].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint + 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint + 10].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 12].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            AllHexagon[middlePoint - 11].gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            PossibilityObjectList.Add(AllHexagon[middlePoint + 1]);
            PossibilityObjectList.Add(AllHexagon[middlePoint - 1]);
            PossibilityObjectList.Add(AllHexagon[middlePoint + 11]);
            PossibilityObjectList.Add(AllHexagon[middlePoint + 10]);
            PossibilityObjectList.Add(AllHexagon[middlePoint - 12]);
            PossibilityObjectList.Add(AllHexagon[middlePoint - 11]);
        }
        CheckObject();
    }
    public void ClickedObjectFun(GameObject clickedObj)
    {
        clickedObjectList.Add(clickedObj);
        clickedObj.GetComponent<PolygonCollider2D>().enabled = false;
        clickedObj.GetComponent<SpriteRenderer>().color = Color.gray;
        CheckObject();
        CatMove();
    }
    //public void CheckObject()
    //{
    //    for (int i = 0; i < PossibilityObjectList.Count; i++)
    //    {
    //        if (clickedObjectList.Contains(PossibilityObjectList[i]))
    //        {
    //            Debug.Log("Value deleted = " + PossibilityObjectList[i]);
    //            PossibilityObjectList.Remove(PossibilityObjectList[i]);
    //        }
    //    }
    //}
    List<GameObject> itemsToRemove = new List<GameObject>();
    public void CheckObject()
    {
        for (int i = 0; i < PossibilityObjectList.Count; i++)
        {
            if (clickedObjectList.Contains(PossibilityObjectList[i]))
            {
                Debug.Log("Value deleted = " + PossibilityObjectList[i]);
                itemsToRemove.Add(PossibilityObjectList[i]);
            }
        }

        foreach (GameObject item in itemsToRemove)
        {
            PossibilityObjectList.Remove(item);
        }
    }

    //public void CatMove()
    //{
    //    AllHexagon[middlePoint].gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    //    AllHexagon[middlePoint].gameObject.GetComponent<PolygonCollider2D>().enabled = true;
    //    //CheckObject();
    //    int val = Random.Range(0, PossibilityObjectList.Count);
    //    middlePoint = int.Parse(PossibilityObjectList[val].gameObject.name);
    //    Debug.Log("Midle point is = " + middlePoint);
    //    AllHexagon[middlePoint].gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    //    CatCharacter.transform.position = AllHexagon[middlePoint].transform.position;
    //    CatAnimator.SetTrigger("Jump");
    //    if (AllHexagon[middlePoint].CompareTag("Border"))
    //    {
    //        Debug.Log("Game overr");
    //        winPanel.SetActive(true);
    //    }
    //    else
    //    {
    //        MiddlePoint();
    //    }
    //}
    private bool isMoving = false; 

    public void CatMove()
    {
        if (!isMoving)
        {
            // Calculate the new position for the cat
            AllHexagon[middlePoint].gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            AllHexagon[middlePoint].gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            int val = Random.Range(0, PossibilityObjectList.Count);
            if (PossibilityObjectList.Count == 0)
            {
                Debug.Log("No move available");
                winPanel.SetActive(true);
                CatObject.SetActive(false);
            }
            else
            {
                middlePoint = int.Parse(PossibilityObjectList[val].gameObject.name);
                Vector3 targetPosition = AllHexagon[middlePoint].transform.position;

                // Start the jump animation coroutine
                StartCoroutine(PlayJumpAnimation(targetPosition));
            }
        }
    }
    bool winn;
    private IEnumerator PlayJumpAnimation(Vector3 targetPosition)
    {
        if(winn)
        {
            winPanel.SetActive(true);
        }
            isMoving = true; // Set the flag to indicate that the cat is moving

            // Trigger the jump animation
            CatAnimator.SetTrigger("Jump");

            // Wait for a brief moment to allow the jump animation to start
            yield return new WaitForSeconds(0.1f); // Adjust the delay as needed

            // Move the cat to the new position (you can use physics-based or keyframe animation here)
            float jumpDuration = 0.7f; // Adjust the jump duration
            float elapsedTime = 0;
            Vector3 initialPosition = CatCharacter.transform.position;

            while (elapsedTime < jumpDuration)
            {
                float t = elapsedTime / jumpDuration;
                CatCharacter.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the cat reaches the exact target position
            CatCharacter.transform.position = targetPosition;

            // Reset the flag
            isMoving = false;

            // Check if the cat reached a border
            if (AllHexagon[middlePoint].CompareTag("Border"))
            {
                Debug.Log("Game overr");
                GameOverPanel.SetActive(true);

                CatObject.SetActive(false);
                winn = true;
                //winPanel.SetActive(true);
            }
            else
            {
                MiddlePoint();
            }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }
    public void HomeScene()
    {
        SceneManager.LoadScene(0);
    }

}