﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {

            transform.Translate(Vector3.up *3* Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, 90*Time.deltaTime));
        }
    }
}
