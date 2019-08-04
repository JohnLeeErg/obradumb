using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterInput : MonoBehaviour
{
    InputField fieldComp;
    TextMesh textComp;
    bool firstTimeDone;
    [SerializeField] blink blinkRef;
    AudioSource audioRef;
    // Start is called before the first frame update
    void Start()
    {
       textComp = GetComponent<TextMesh>();
        audioRef = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            textComp.text += "\n";
        }
        else if(Input.GetKeyDown(KeyCode.Backspace) && textComp.text.Length > 0)
        {
            textComp.text=textComp.text.Substring(0, textComp.text.Length - 1);
        }
        else if (Input.anyKeyDown)
        {
            if (!firstTimeDone)
            {
                blinkRef.PubDestroy();
                firstTimeDone = true;
            }
            textComp.text+=Input.inputString.Replace('e',' ');
            if (audioRef)
            {
                audioRef.pitch = Random.Range(.7f, 1.2f);
                audioRef.Play();
            }
        }
    }
   
    
}
