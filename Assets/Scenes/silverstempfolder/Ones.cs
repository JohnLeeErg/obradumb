using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ones : MonoBehaviour
{
    public GameObject damage;
    public float lifeSpan, speed, dist;
    public Camera cam;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(BecomingOne());
    }

    IEnumerator BecomingOne() {
        GameObject dam = Instantiate(damage);
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        print(mousePos.x + ":" + mousePos.y);
        dam.transform.position = cam.ScreenToWorldPoint(new Vector3(mousePos.x-.5f, mousePos.y+ .1f, -1));
        for (int i = 0; i < lifeSpan; i++)
        {
            dam.transform.position = new Vector3(dam.transform.position.x + dist, dam.transform.position.y + dist, -1);
            yield return new WaitForSeconds(speed);
        }
        Destroy(dam);
    }
}
