using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardPuzzleLogic : MonoBehaviour
{
    List<string> answer = new List<string>
    {
        "3H",
        "6S", 
        "5S",
        "2D",
        "2C",
        "8C",
        "9S"
    };
    int numCorrect;
    [SerializeField] TMP_InputField slot1, slot2, slot3, slot4, slot5, slot6, slot7;
    public void OnClickDone()
    {
        bool correct = CheckCorrect();
        if (correct)
        {
            FindAnyObjectByType<Wizard>().PuzzleWin();
        }
        else
        {
            Debug.Log("No");
        }
    }

    bool CheckCorrect() //add player feedback?
    {
        numCorrect = 0;
        bool correct = false;
        //checks if puzzle is correct
        string[] inputs =
        {
            slot1.text.Trim(),
            slot2.text.Trim(),
            slot3.text.Trim(),
            slot4.text.Trim(),
            slot5.text.Trim(),
            slot6.text.Trim(),
            slot7.text.Trim(),
        };
        
        for (int i = 0; i < answer.Count; i++)
        {
            if (answer[i] == inputs[i].ToUpper())
            {
                numCorrect += 1;
            }
        }
        if (numCorrect == 7)
        {
            correct = true;
        }
        return correct;
    }
}
