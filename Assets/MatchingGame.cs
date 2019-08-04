using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingGame : MonoBehaviour
{
    [SerializeField] int gridSize;
    [SerializeField] float cardSize;
    [SerializeField] GameObject cardPrefab;
    GameObject[] grid;
    List<int> tempList = new List<int>();
    int cardCount;
    tileScript one;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 curPos = transform.position;
        cardCount = gridSize * gridSize;
        grid = new GameObject[cardCount];
        int col = 0;
        int row = 0;
        for (int i = 0; i < cardCount; i++)
        {
            grid[i] = Instantiate(cardPrefab, curPos, Quaternion.identity);
            col++;

            tempList.Add(i + 1);
            curPos += Vector3.right * cardSize;
            if (col >= gridSize)
            {
                row++;
                col = 0;
                curPos = transform.position + Vector3.down * row * cardSize;
            }
        }
        for (int i = 0; i < cardCount; i++)
        {
            int randomNumber = tempList[Random.Range(0, tempList.Count)];
            grid[i].GetComponentInChildren<TextMesh>(true).text = randomNumber.ToString("00");
            tempList.Remove(randomNumber);
        }
    }
    // Update is called once per frame
    public IEnumerator OnClickTile(tileScript tile)
    {
        if (one == null)
        {
            one = tile;
            yield return null;
        }
        else
        {
            tileScript.midTrans = true;
            //2 tiles flipped
            yield return new WaitForSeconds(1);
            //flip them back
            StartCoroutine(one.Flip());

            StartCoroutine(tile.Flip());
            one = null;
        }
    }
}
