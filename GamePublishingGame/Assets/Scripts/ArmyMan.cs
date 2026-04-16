using UnityEngine;
using UnityEngine.InputSystem;

public class ArmyMan : MonoBehaviour
{
    [SerializeField] InputAction interactionAction;
    bool inRange, talked;
    [SerializeField] GameObject puzzleCanvas, block;
     void Start()
    {
        interactionAction.Enable();
        interactionAction.performed += PlayerInteract;
        inRange = false;
        puzzleCanvas.SetActive(false);
        block.SetActive(false);
    }

    void PlayerInteract(InputAction.CallbackContext c)
    {
        if (inRange && !talked)
        {
            FindAnyObjectByType<DialogBox>().PlayDialogue(48, 51);
            FindAnyObjectByType<GameManager>().goalText.text = "Beat him in war";
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
        FindAnyObjectByType<DialogBox>().PlayDialogue(52, 53);
        block.SetActive(true);
        FindAnyObjectByType<GameManager>().goalText.text = "Explore";
        FindAnyObjectByType<PlayerMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
