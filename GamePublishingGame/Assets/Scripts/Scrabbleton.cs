using UnityEngine;
using UnityEngine.InputSystem;

public class Scrabbleton : MonoBehaviour
{
    [SerializeField] InputAction interactionAction;
    [SerializeField] GameObject puzzleCanvas;
    bool inRange;
    bool talked;
    
    void Start()
    {
        interactionAction.Enable();
        interactionAction.performed += PlayerInteract;
        inRange = false;
        talked = false;
        puzzleCanvas.SetActive(false);
    }
    void PlayerInteract(InputAction.CallbackContext c)
    {
        if (inRange && !talked)
        {
            FindAnyObjectByType<DialogBox>().PlayDialogue(54, 57);
            FindAnyObjectByType<GameManager>().goalText.text = "Find all of the tiles";
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
        FindAnyObjectByType<DialogBox>().PlayDialogue(58, 59);
        FindAnyObjectByType<GameManager>().goalText.text = "Find the Snake";
        FindAnyObjectByType<Snake>().tilesCollected = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
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
