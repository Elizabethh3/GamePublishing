using UnityEngine;
using UnityEngine.InputSystem;

public class Queenie : MonoBehaviour
{
    [SerializeField] InputAction interactionAction;
    bool inRange, talked;
    [SerializeField] GameObject puzzleCanvas, block, correctPlace;
    void Start()
    {
        interactionAction.Enable();
        interactionAction.performed += PlayerInteract;
        inRange = false;
        puzzleCanvas.SetActive(false);
    }

    void PlayerInteract(InputAction.CallbackContext c)
    {
        if (inRange && !talked)
        {
            FindAnyObjectByType<DialogBox>().PlayDialogue(38, 41);
            FindAnyObjectByType<GameManager>().goalText.text = "Help Queenie find her spot";
            talked = true;
        }
        else if (inRange && talked)
        {
            //bring up puzzle
            puzzleCanvas.SetActive(true);
            FindAnyObjectByType<PlayerMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void PuzzleWin()
    {
        puzzleCanvas.SetActive(false);
        FindAnyObjectByType<DialogBox>().PlayDialogue(42, 42);
        block.SetActive(true);
        FindAnyObjectByType<GameManager>().goalText.text = "Explore";
        FindAnyObjectByType<PlayerMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.transform.position = correctPlace.transform.position;
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
    
