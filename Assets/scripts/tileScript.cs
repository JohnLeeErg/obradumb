using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    [SerializeField] MatchingGame matchGameRef;
    [SerializeField] Sprite front, back;
    bool flipped;
    SpriteRenderer spriteRef;
    TextMesh textRef;
    bool currentlyFlipping;
    public static bool midTrans;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRef = GetComponent<SpriteRenderer>();
        textRef = GetComponentInChildren<TextMesh>(true);
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (!currentlyFlipping && !midTrans)
        {

            currentlyFlipping = true;
            StartCoroutine(Flip());
            StartCoroutine(matchGameRef.OnClickTile(this));
            audioSource.pitch = Random.Range(.7f, 1.2f);
            audioSource.Play();
        }
    }

    public IEnumerator Flip()
    {
        Vector3 origScale = transform.localScale;

        while (transform.localScale.x > 0)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale,new Vector3(0, transform.localScale.y,transform.localScale.z),28*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        if (flipped)
        {
            spriteRef.sprite = front;
            textRef.gameObject.SetActive(false);
            //flipback
            flipped = false;

            currentlyFlipping = false;
            midTrans = false;
        }
        else
        {
            spriteRef.sprite = back;
            textRef.gameObject.SetActive(true);

            flipped = true;
        }
        while (transform.localScale.x <origScale.x)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, origScale, 28 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
