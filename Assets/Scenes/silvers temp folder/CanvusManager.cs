using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvusManager : MonoBehaviour
{
    public RectTransform selectedPos;
    private Vector3 previousPos, targetPos;
    public float textMoveSpeed, textFadeSpeed;
    public Transform listHolder;
    private int selected=-1;
    int isOnList = -1;
    public GameObject screenHolder;
    public Button back;
    

    

    void Update()
    {
        if (isOnList >= 0 && selected > 0)
        {
            listHolder.GetChild(selected).GetComponent<RectTransform>().position = Vector3.MoveTowards(listHolder.GetChild(selected).GetComponent<RectTransform>().position, targetPos, textMoveSpeed);

            if (listHolder.GetChild(selected).position == targetPos)
            {
                if (isOnList == 1)
                {
                    ///text got to top of screen
                    StartCoroutine("FadeInBack");
                }
                else if(isOnList==0)
                {
                    //text returned to list
                    StartCoroutine("FadeIn");
                }
                isOnList = -1;
            }

        }

    }



    public void SelectedGame(int n) {
   
        selected = n;
        isOnList = 1;
        previousPos = listHolder.GetChild(n).position;
        targetPos = selectedPos.position;
        print("sell: " + targetPos+":"+ listHolder.GetChild(n).position);
        StartCoroutine("FadeOut");
        //fade in game stuff;
        enableButtons(false);
    }

    private void enableButtons(bool t)
    {
        for (int i = 0; i < listHolder.childCount; i++)
            listHolder.GetChild(i).GetComponent<Button>().interactable = t;
    }

    public void Back() {
        targetPos = previousPos;
        isOnList = 0;
        StartCoroutine("FadeOutBack");
    }

    IEnumerator FadeOut() {
        print("fade out");
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            for (int i = 0; i < listHolder.childCount; i++)
            {
                if (i==selected)
                    continue;
                Color c = listHolder.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().color;
                c.a = ft;
                listHolder.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().color = c;
            }
            yield return new WaitForSeconds(textFadeSpeed);
        }
        for (int i = 0; i < listHolder.childCount; i++)
        {
            if (i == selected)
                continue;
            Color co = listHolder.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().color;
            co.a = 0;
            listHolder.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().color = co;
        }
    }
    IEnumerator FadeIn()
    {
        for (float ft = 0f; ft < 1; ft += 0.1f)
        {
            for (int i = 0; i < listHolder.childCount; i++)
            {
                if (i == selected)
                    continue;
                Color c = listHolder.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().color;
                c.a = ft;
                listHolder.GetChild(i).GetChild(0)  .gameObject.GetComponent<Text>().color = c;
            }
            yield return new WaitForSeconds(textFadeSpeed);
        }

        enableButtons(true);
        selected = -1;
    }

    IEnumerator FadeInBack()
    {
        for (float ft = 0f; ft < 1; ft += 0.1f)
        {
            Color c = back.transform.GetChild(0).gameObject.GetComponent<Text>().color;
            c.a = ft;
            back.transform.GetChild(0).gameObject.GetComponent<Text>().color = c;
            yield return new WaitForSeconds(textFadeSpeed);
        }
        back.GetComponent<Button>().interactable = true;
    }
    IEnumerator FadeOutBack()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
                Color c = back.transform.GetChild(0).gameObject.GetComponent<Text>().color;
                c.a = ft;
                back.transform.GetChild(0).gameObject.GetComponent<Text>().color = c;
            yield return new WaitForSeconds(textFadeSpeed);
        }
        Color co = back.transform.GetChild(0).gameObject.GetComponent<Text>().color ;
        co.a = 0;
        back.transform.GetChild(0).gameObject.GetComponent<Text>().color = co;

        back.GetComponent<Button>().interactable = false;
    }
}
