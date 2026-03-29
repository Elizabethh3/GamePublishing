using UnityEngine;
using UnityEngine.InputSystem;

public class Pawnerella : MonoBehaviour
{
   
    [SerializeField] InputAction interactionAction;
    [SerializeField] GameObject puzzleCanvas, block;
    [SerializeField] Camera puzzleCam, ogCam;
    bool inRange;
    bool talked, finishedPuzzle;
    

    void Start()
    {
        interactionAction.Enable();
        interactionAction.performed += PlayerInteract;
        inRange = false;
        talked = false;
        finishedPuzzle = false;
        puzzleCanvas.SetActive(false);
    }

    void PlayerInteract(InputAction.CallbackContext c)
    {
        if (inRange && !talked && !finishedPuzzle)
        {
            FindAnyObjectByType<DialogBox>().PlayDialogue(10,14);
            FindAnyObjectByType<GameManager>().goalText.text = "Figure out the puzzle";
            talked = true;
            //make talked = true after dialogue is finished
        }
        else if (inRange && talked && !finishedPuzzle)
        {   //Go to puzzle view - change cam
            puzzleCanvas.SetActive(true);
            ogCam.enabled = false;
            puzzleCam.enabled = true;
            FindAnyObjectByType<PlayerMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            finishedPuzzle = true;
        }
    }
    public void PuzzleWin()
    {
        puzzleCanvas.SetActive(false);
        ogCam.enabled = true;
        puzzleCam.enabled = false;
        FindAnyObjectByType<PlayerMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindAnyObjectByType<DialogBox>().PlayDialogue(15,19);
        block.SetActive(true);
        FindAnyObjectByType<GameManager>().goalText.text = "Explore";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
