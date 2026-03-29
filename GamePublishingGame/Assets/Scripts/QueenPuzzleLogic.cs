using UnityEngine;

public class QueenPuzzleLogic : MonoBehaviour
{
    public void OnClick()
    {
        //check if crown is in correct spot if so, win
        FindAnyObjectByType<Queenie>().PuzzleWin();
    }
}
