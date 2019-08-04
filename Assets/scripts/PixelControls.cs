using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelControls : MonoBehaviour
{
    SpriteRenderer spriteComp;
    // Start is called before the first frame update
    void Start()
    {
        spriteComp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            spriteComp.color = Random.ColorHSV(0,1,.7f,1,.7f,1,1,1);
        }
    }
}
