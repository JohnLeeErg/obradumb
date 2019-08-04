using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public Image background;
    public GameObject[] text;
    public float textFadeSpeed, timer;
    private bool fin= true;
    // Update is called once per frame
    void Update()
    {
        if (fin &&timer<0) {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                StartCoroutine(FadeOutBackGround());
            }
        }

        timer -= Time.deltaTime;
    }

    IEnumerator FadeOutBackGround()
    {
        fin = false;

        for(int i =0;i<text.Length;i++)
            Destroy(text[i]);
        for (float ft = 1f; ft >= 0; ft -= 0.05f)
        {
            Color c = background.color;
            c.a = ft;
            background.color = c;
            yield return new WaitForSeconds(textFadeSpeed);
        }
        Destroy(background);
        Destroy(gameObject);
    }
}
