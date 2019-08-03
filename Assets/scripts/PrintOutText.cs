using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintOutText : MonoBehaviour
{
    [Tooltip("time it takes to print 1 char")]
    [SerializeField] float printSpeed;
    [SerializeField] char missingLetter;
    TextMesh textMeshComp;
    Text textComp; //if you're using ui text
    bool ui;
    string storedText;
    // Start is called before the first frame update
    void Start()
    {
        textMeshComp = GetComponent<TextMesh>();
        textComp = GetComponent<Text>();

        if (textComp)
        {
            ui = true;
            storedText = textComp.text;
            textComp.text = "";

            StartCoroutine(PrintText());
        }
        else
        {
            //otherwise use the text mesh
            storedText = textMeshComp.text;
            textMeshComp.text = "";
            StartCoroutine(PrintTextMesh());
        }

    }

    IEnumerator PrintTextMesh()
    {
        int i = 0;
        while (textMeshComp.text.Length < storedText.Length)
        {
            if (storedText[i] == missingLetter)
            {
                textMeshComp.text += " ";
            }
            else
            {
                textMeshComp.text += storedText[i];
            }
            i++;
            yield return new WaitForSeconds(printSpeed);
        }
    }
    IEnumerator PrintText()
    {
        int i = 0;
        while (textComp.text.Length <storedText.Length)
        {
            if (storedText[i] == missingLetter)
            {
                textComp.text += " ";
            }
            else
            {
                textComp.text += storedText[i];
            }
            i++;
            yield return new WaitForSeconds(printSpeed);
        }
    }
}
