using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeButton : MonoBehaviour
{
    [SerializeField] bool rightAnswer;
    [SerializeField] AudioClip win, lose;
    AudioSource aud;
    TextMesh textComp; 
    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<TextMesh>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (rightAnswer)
        {
            textComp.color = Color.green;
            aud.clip = win;
            aud.Play();
        }
        else
        {
            textComp.color = Color.red;
            aud.clip = lose;
            aud.Play();
        }
        //maybe have sounds 
    }
}
