using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] List<GameObject> AllButtons;

    [SerializeField] Sprite oImage, xImage, currentSprite;
    public static Manager instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool isTurn;
    public void BtnCLick(GameObject obj)
    {
        currentSprite = isTurn ? oImage : xImage;

        Debug.Log("Btn clicked");
        if (isTurn)
        {
            obj.GetComponent<Image>().sprite = currentSprite;
            isTurn = false;
        }
        else
        {
            obj.GetComponent<Image>().sprite = currentSprite;
            isTurn = true;
        }
        obj.GetComponent<Button>().interactable = false;
        AllButtons.Remove(obj.gameObject);
        AllButtons.Remove(obj);
        MakingAutoMAtic();
        StartCoroutine(nameof(WaitFOrMove));
    }
    IEnumerator WaitFOrMove()
    {
        yield return new WaitForSeconds(1);
        CheckingWin();
    }
    public void MakingAutoMAtic()
    {
        int val = Random.Range(0, AllButtons.Count);

        GameObject obb = AllButtons[val].gameObject;
        AutoMove(obb);
    }
    public void AutoMove(GameObject obj)
    {
        currentSprite = isTurn ? oImage : xImage;

        Debug.Log("Auto move");
        if (isTurn)
        {
            obj.GetComponent<Image>().sprite = currentSprite;
            isTurn = false;
        }
        else
        {
            obj.GetComponent<Image>().sprite = currentSprite;
            isTurn = true;
        }
        obj.GetComponent<Button>().interactable = false;
        AllButtons.Remove(obj.gameObject);
        AllButtons.Remove(obj);
        //CheckingWin();
    }
    public void CheckingWin()
    {
        if (AllButtons[0].GetComponent<Image>().sprite == currentSprite &&
            AllButtons[1].GetComponent<Image>().sprite == currentSprite &&
            AllButtons[2].GetComponent<Image>().sprite == currentSprite)
        {
            Debug.Log("Matched");
        }
        else if (AllButtons[3].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[4].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[5].GetComponent<Image>().sprite == currentSprite)
        {
            Debug.Log("matching 1");
        }
        else if (AllButtons[6].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[7].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[8].GetComponent<Image>().sprite == currentSprite)
        {
            Debug.Log("matching 2");
        }
        else if (AllButtons[0].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[4].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[8].GetComponent<Image>().sprite == currentSprite)
        {
            Debug.Log("matching 3");
        }
        else if (AllButtons[2].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[4].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[6].GetComponent<Image>().sprite == currentSprite)
        {
            Debug.Log("matching 4");
        }
        else if (AllButtons[0].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[3].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[6].GetComponent<Image>().sprite == currentSprite)
        {
            Debug.Log("matching 5");
        }
        else if (AllButtons[1].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[4].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[7].GetComponent<Image>().sprite == currentSprite)
        {
            Debug.Log("matching 6");
        }
        else if (AllButtons[2].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[5].GetComponent<Image>().sprite == currentSprite &&
                 AllButtons[8].GetComponent<Image>().sprite == currentSprite)
        {
            Debug.Log("matching 7");
        }
        else
        {
            Debug.Log("not matching");
        }
    }
}
