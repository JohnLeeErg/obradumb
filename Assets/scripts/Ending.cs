using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] TextMesh title, score, quote;
    [SerializeField] SpriteRenderer gameImage;
    [SerializeField] Transform starParent;
    [SerializeField] Sprite fullStar, emptyStar;
    SpriteRenderer[] stars;
    public EndingSettings endingToPlay;
    // Start is called before the first frame update
    void Start()
    {
        stars = starParent.GetComponentsInChildren<SpriteRenderer>();
        LoadEnding();
    }
    public void LoadEnding(EndingSettings ending = null)
    {
        if (ending != null)
        {
            endingToPlay = ending;
        }
        quote.text = endingToPlay.quote;
        title.text = endingToPlay.gameTitle;
        score.text = endingToPlay.ratingCount.ToString("000");
        gameImage.sprite = endingToPlay.gameImage;
        for(int i = 0; i < stars.Length; i++)
        {
            if (i < endingToPlay.rating)
            {
                stars[i].sprite = fullStar;
            }
            else
            {
                stars[i].sprite = emptyStar;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}


