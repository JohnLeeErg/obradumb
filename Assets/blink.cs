using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour
{
    TextMesh textComp;
    [SerializeField] float blinkSpeed = 1;//seconds

    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<TextMesh>();
        StartCoroutine(blinkText());
    }

    IEnumerator blinkText()
    {
        while (true)
        {
            textComp.text = " ";
            yield return new WaitForSeconds(blinkSpeed);
            textComp.text = "|";

            yield return new WaitForSeconds(blinkSpeed);
        }

    }

    public void PubDestroy()
    {
        Destroy(gameObject);
    }
}
