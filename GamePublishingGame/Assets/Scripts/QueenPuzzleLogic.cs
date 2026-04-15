using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class QueenPuzzleLogic : MonoBehaviour
{
    [SerializeField] GameObject crown, correctSpot;
    bool win = false;
    RectTransform correctRect, crownRect;
    public void OnClickDone()
    {
        crownRect = crown.GetComponent<RectTransform>();
        correctRect = correctSpot.GetComponent<RectTransform>();
        float crownX = crownRect.position.x;
        float crownY = crownRect.position.y;
        float correctX = correctRect.position.x;
        float correctY = correctRect.position.y;

        if ((correctX - correctRect.rect.width) <= crownX && crownX <= (correctX + correctRect.rect.width))
        {
            if ((correctY - correctRect.rect.height) <= crownY && crownY <= (correctY + correctRect.rect.height))
            {
                win = true;
            }
        }
        if (win)
        {
            FindAnyObjectByType<Queenie>().PuzzleWin();
        }
    }
}
