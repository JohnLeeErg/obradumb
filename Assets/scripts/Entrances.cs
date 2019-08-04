using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script for general entrance effects for objects
/// </summary>
public class Entrances : MonoBehaviour
{
    [SerializeField] entrances startAnim;
    [SerializeField] Transform target, start;
    [SerializeField] AnimationCurve swoopCurve;
    [SerializeField] float time=1;
    enum entrances
    {
        swoop,
        appear,
        orbit

    }
    [SerializeField] float delay;
    Renderer rendComp;
    // Start is called before the first frame update
    void Start()
    {
        rendComp = GetComponent<Renderer>();
        switch (startAnim) {
            case entrances.swoop:
                StartCoroutine(Swoop());
                break;
            case entrances.appear:
                StartCoroutine(Appear());
                break;
            case entrances.orbit:
                StartCoroutine(Orbit());
                break;
        }
      
    }
    IEnumerator Appear()
    {
        rendComp.enabled = false;
        
        yield return new WaitForSeconds(delay);
        rendComp.enabled = true;
        //should have an appear sound
    }
    IEnumerator Swoop()
    {
        transform.position = start.position;
        yield return new WaitForSeconds(delay);
        float i = 0;
        while (i <= time)
        {
            transform.position = Vector3.Lerp(start.position, target.position, swoopCurve.Evaluate(i/time));
            i += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Orbit()
    {
        transform.position = start.position;
        yield return new WaitForSeconds(delay);

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 1*Time.deltaTime);
            transform.Translate(Vector3.Cross(transform.position, target.position).normalized*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
