using System.Collections.Generic;
using UnityEngine;

public class SnakePuzzle : MonoBehaviour
{
    [SerializeField] List<GameObject> letters, correctSpots;
    int numCorrect;
    bool win;
    List<RectTransform> correctRects, letterRects;
    void Start()
    {
        correctRects = new List<RectTransform>();
        letterRects = new List<RectTransform>();
    }
    public void OnClickDone()
    {
        numCorrect = 0;
        win = true;
        letterRects.Clear();
        correctRects.Clear();
        
        foreach (GameObject l in letters)
        {
            letterRects.Add(l.GetComponent<RectTransform>());
        }
        foreach (GameObject c in correctSpots)
        {
            correctRects.Add(c.GetComponent<RectTransform>());
        }

        //check what letter is inside each spot, is the letter correct? if so add 1

        if (numCorrect == letters.Count)
        {
            win = true;
        }

        if (win)
        {
            FindAnyObjectByType<Snake>().PuzzleWin();
        }
    }
}
