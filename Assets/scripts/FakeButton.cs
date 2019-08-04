using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeButton : MonoBehaviour
{
    [SerializeField] bool rightAnswer;
    TextMesh textComp; 
    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<TextMesh>();
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
        }
        else
        {
            textComp.color = Color.red;
        }
        //maybe have sounds 
    }
}
