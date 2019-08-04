using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisControls : MonoBehaviour
{
    AudioSource audioBOi;
    [SerializeField] AudioClip move, rotate;
    // Start is called before the first frame update
    void Start()
    {
        audioBOi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.left, Space.World);
            audioBOi.clip = move;
            audioBOi.pitch = Random.Range(.7f, 1.2f);
            audioBOi.Play();

        } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right,Space.World);
            audioBOi.clip = move;
            audioBOi.pitch = Random.Range(.7f, 1.2f);
            audioBOi.Play();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0, 0, 90));

            audioBOi.clip = rotate;
            audioBOi.pitch = Random.Range(.7f, 1.2f);
            audioBOi.Play();
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
