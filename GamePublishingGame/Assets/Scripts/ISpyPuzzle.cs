using System;
using TMPro;
using UnityEngine;

public class ISpyPuzzle : MonoBehaviour
{
    [SerializeField] TMP_Text tileCounter;
    int numTilesClicked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numTilesClicked = 0;
        tileCounter.text = "0/6";
    }

    // Update is called once per frame
    void Update()
    {
        if (numTilesClicked == 6)
        {
            FindAnyObjectByType<Scrabbleton>().PuzzleWin();
        }
    }

    public void OnClickTile(GameObject tile)
    {
        tile.SetActive(false);
        numTilesClicked += 1;
        tileCounter.text = numTilesClicked + "/6";
    }
}
