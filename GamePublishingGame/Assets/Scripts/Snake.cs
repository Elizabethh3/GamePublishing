using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Snake : MonoBehaviour
{
    [SerializeField] InputAction interactionAction;
    [SerializeField] GameObject puzzleCanvas, snakeDoor, resetScreen;
    DialogBox dialogBox;
    bool inRange;
    bool talked;
    bool firstDialoguePlayed;
    public bool tilesCollected;
    
    void Start()
    {
        interactionAction.Enable();
        interactionAction.performed += PlayerInteract;
        inRange = false;
        talked = false;
        tilesCollected = false;
        firstDialoguePlayed = false;
        puzzleCanvas.SetActive(false);
        dialogBox = FindAnyObjectByType<DialogBox>();
    }
    void PlayerInteract(InputAction.CallbackContext c)
    {
        if (inRange && !talked && !firstDialoguePlayed)
        {
            dialogBox.PlayDialogue(60, 60);
            firstDialoguePlayed = true;
        }
        else if (inRange && !talked && !tilesCollected && firstDialoguePlayed)
        {
            dialogBox.PlayDialogue(61, 62);
        }
        else if (inRange && !talked && tilesCollected && firstDialoguePlayed)
        {
            dialogBox.PlayDialogue(63, 64);
            FindAnyObjectByType<GameManager>().goalText.text = "Unscramble the tiles";
            talked = true;
        }
        else if (inRange && talked)
        {
            puzzleCanvas.SetActive(true);
            FindAnyObjectByType<PlayerMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void PuzzleWin()
    {
        puzzleCanvas.SetActive(false);
        FindAnyObjectByType<PlayerMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindAnyObjectByType<DialogBox>().PlayDialogue(65, 65);
        FindAnyObjectByType<GameManager>().goalText.text = "Try to find the exit";
        snakeDoor.SetActive(false);
        resetScreen.SetActive(true);
        StartCoroutine(TurnOffResetScreen());
        
        //have snake disappear in similar way to boatson's
    }

    IEnumerator TurnOffResetScreen()
    {
        yield return new WaitForSeconds(2);
        resetScreen.SetActive(false);
        gameObject.SetActive(false);
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
