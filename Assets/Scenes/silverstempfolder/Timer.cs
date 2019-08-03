﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime,flashing;
    private float timeLeft, section;
    public Text timerNumber;
    public Image circle;
    private bool flash;
    // Update is called once per frame
    private void Start()
    {
        flash = true;
        timeLeft = totalTime;
        section = totalTime / 48;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        circle.fillAmount = timeLeft / totalTime;
        timerNumber.text = (Mathf.Floor(timeLeft/section)).ToString();

        if (Mathf.Floor(timeLeft / section) < flashing && flash)
            StartCoroutine(alternateFlash());
    }

    IEnumerator alternateFlash() {
        circle.gameObject.SetActive(!circle.gameObject.activeSelf);
       // timerNumber.gameObject.SetActive(!timerNumber.gameObject.activeSelf);
        flash = false;
        yield return new WaitForSeconds(.2f);
        flash = true;
    }

    


}