using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.left, Space.World);
        } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right,Space.World);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        if (transform.position.x <= -11)
        {
            transform.position = new Vector3(7, transform.position.y);
        }
        else if (transform.position.x >= 8)
        {
            transform.position = new Vector3(-10, transform.position.y);
        }
    }
}
