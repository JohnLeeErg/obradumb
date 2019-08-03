using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject[] toDisable;
    public Image background;
    public EndingSettings[] endings;
    public Ending pageLayout;
    public float textFadeSpeed;
    private bool exit = false;


    private void Update()
    {
        if (exit)
            if (Input.anyKey)
                Application.Quit();
    }

    public void GameOver(int end)
    {
        for (int i = 0; i <toDisable.Length; i++)
            toDisable[i].SetActive(false);

        background.color = Color.black;
        pageLayout.gameObject.SetActive(true);
        StartCoroutine(FadeOutBackGround());
        pageLayout.LoadEnding(endings[end]);
        
    }

    IEnumerator FadeOutBackGround()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.05f)
        {
            Color c = background.color;
            c.a = ft;
            background.color = c;
            yield return new WaitForSeconds(textFadeSpeed);
        }
        yield return new WaitForSeconds(2f);
        exit = true;
    }
}
