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
    public Image background;
    public Image strike;
    public bool strikeSelected;

    public GameObject[] screens;

    private void Start()
    {
        print( Screen.width);
        textMoveSpeed = textMoveSpeed* (Screen.width/400);
        back.GetComponent<Button>().interactable = false;
    }

    void Update()
    {
        if (isOnList >= 0 && selected >= 0)
        {
            listHolder.GetChild(selected).GetComponent<RectTransform>().position = Vector3.MoveTowards(listHolder.GetChild(selected).GetComponent<RectTransform>().position, targetPos, textMoveSpeed);
            if ((Mathf.Round(listHolder.GetChild(selected).position.x) == Mathf.Round(targetPos.x)) && (Mathf.Round(listHolder.GetChild(selected).position.y) == Mathf.Round(targetPos.y)))
            {
                listHolder.GetChild(selected).position = targetPos;
                if (isOnList == 1)
                {
                    StartCoroutine("FadeInBack");
                    StartCoroutine("FadeOutBackGround");
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

    private void StrikeOut(int n)
    {
        if (listHolder.GetChild(n).childCount == 1)
        {
            selected = n;
            Image striker = Instantiate(strike, listHolder.GetChild(n));
            striker.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(listHolder.GetChild(n).GetComponent<RectTransform>().rect.width, strike.GetComponent<RectTransform>().rect.height);
            StartCoroutine(FadeToGrey());
        }
        else {
            selected = n;
            Destroy(listHolder.GetChild(n).GetChild(1).gameObject);
            StartCoroutine(FadeToBlack());
        }
    }

    public void SelectedGame(int n) {

        if (strikeSelected)
        {
            StrikeOut(n);
            return;
        }
        else if (listHolder.GetChild(n).childCount>1)
            return;

        selected = n;
        isOnList = 1;
        previousPos = listHolder.GetChild(selected).position;
        targetPos = selectedPos.position;
        print("sell: " + targetPos+":"+ listHolder.GetChild(selected).position);
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
        StartCoroutine("FadeInBackGround");
    }

    IEnumerator FadeToBlack()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            listHolder.GetChild(selected).GetChild(0).gameObject.GetComponent<Text>().color = Color.Lerp(Color.black, Color.grey, ft);
            yield return new WaitForSeconds(textFadeSpeed);
        }
    }
    IEnumerator FadeToGrey(){
        print("here");
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            listHolder.GetChild(selected).GetChild(0).gameObject.GetComponent<Text>().color = Color.Lerp(Color.grey, Color.black, ft);
            listHolder.GetChild(selected).GetChild(1).gameObject.GetComponent<Image>().color = Color.Lerp(Color.grey, Color.black, ft);
            yield return new WaitForSeconds(textFadeSpeed);
        }
    }

    IEnumerator FadeOut() {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            for (int i = 0; i < listHolder.childCount; i++)
            {
                if (i==selected)
                    continue;
                Color c = listHolder.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().color;
                c.a = ft;
                listHolder.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().color = c;
                if (listHolder.GetChild(i).childCount == 2)
                {
                    listHolder.GetChild(i).GetChild(1).gameObject.GetComponent<Image>().color = c;
                }
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
            if (listHolder.GetChild(i).childCount == 2)
            {
                listHolder.GetChild(i).GetChild(1).gameObject.GetComponent<Image>().color = co;
            }
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

                if (listHolder.GetChild(i).childCount== 2) {
                    listHolder.GetChild(i).GetChild(1).gameObject.GetComponent<Image>().color = c;
                }

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

    IEnumerator FadeInBackGround()
    {
        for (float ft = 0f; ft < 1; ft += 0.1f)
        {
            Color c = background.color;
            c.a = ft;
            background.color = c;
            yield return new WaitForSeconds(textFadeSpeed);
        }
        Destroy(screenHolder);
    }
    IEnumerator FadeOutBackGround()
    {
        screenHolder = Instantiate(screens[selected]);
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            Color c = background.color;
            c.a = ft;
            background.color = c;
            yield return new WaitForSeconds(textFadeSpeed);
        }
        Color co = background.color;
        co.a = 0;
        background.color = co;
    }
}
