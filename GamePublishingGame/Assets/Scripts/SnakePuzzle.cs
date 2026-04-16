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
        win = false;
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
        for (int i = 0; i < correctRects.Count; i++)
        {
            RectTransform correctRect = correctRects[i].GetComponent<RectTransform>();
            float correctX = correctRect.position.x;
            float correctY = correctRect.position.y;
            if (i == 2)
            {
                //check for first d
                RectTransform letterRect = letters[i].GetComponent<RectTransform>();
                float letterX = letterRect.position.x;
                float letterY = letterRect.position.y;
                if ((correctX - correctRect.rect.width) <= letterX && letterX <= (correctX + correctRect.rect.width))
                {
                    if ((correctY - correctRect.rect.height) <= letterY && letterY <= (correctY + correctRect.rect.height))
                    {
                        numCorrect += 1;
                    }
                }
                //check for second d
                letterRect = letters[i + 1].GetComponent<RectTransform>();
                letterX = letterRect.position.x;
                letterY = letterRect.position.y;
                if ((correctX - correctRect.rect.width) <= letterX && letterX <= (correctX + correctRect.rect.width))
                {
                    if ((correctY - correctRect.rect.height) <= letterY && letterY <= (correctY + correctRect.rect.height))
                    {
                        numCorrect += 1;
                    }
                }
            }
            else if (i == 3)
            {
                //check for first d
                RectTransform letterRect = letters[i - 1].GetComponent<RectTransform>();
                float letterX = letterRect.position.x;
                float letterY = letterRect.position.y;
                if ((correctX - correctRect.rect.width) <= letterX && letterX <= (correctX + correctRect.rect.width))
                {
                    if ((correctY - correctRect.rect.height) <= letterY && letterY <= (correctY + correctRect.rect.height))
                    {
                        numCorrect += 1;
                    }
                }
                //check for second d
                letterRect = letters[i].GetComponent<RectTransform>();
                letterX = letterRect.position.x;
                letterY = letterRect.position.y;
                if ((correctX - correctRect.rect.width) <= letterX && letterX <= (correctX + correctRect.rect.width))
                {
                    if ((correctY - correctRect.rect.height) <= letterY && letterY <= (correctY + correctRect.rect.height))
                    {
                        numCorrect += 1;
                    }
                }
            }
            else
            {
                RectTransform letterRect = letters[i].GetComponent<RectTransform>();
                float letterX = letterRect.position.x;
                float letterY = letterRect.position.y;

                if ((correctX - correctRect.rect.width) <= letterX && letterX <= (correctX + correctRect.rect.width))
                {
                    if ((correctY - correctRect.rect.height) <= letterY && letterY <= (correctY + correctRect.rect.height))
                    {
                        numCorrect += 1;
                    }
                }
            }
            //check for the correlating letter to see if its inside?
        }
        Debug.Log(numCorrect);

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
