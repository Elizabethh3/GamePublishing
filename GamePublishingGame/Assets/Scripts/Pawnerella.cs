using UnityEngine;
using UnityEngine.InputSystem;

public class Pawnerella : MonoBehaviour
{
   
    [SerializeField] InputAction interactionAction;
    [SerializeField] GameObject puzzleCanvas;
    [SerializeField] Camera puzzleCam, ogCam;
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
            FindAnyObjectByType<DialogBox>().PlayDialogue(10,19);
            FindAnyObjectByType<GameManager>().goalText.text = "Figure out the puzzle";
            talked = true;
        }
        else if (inRange && talked)
        {   //Go to puzzle view - change cam
            puzzleCanvas.SetActive(true);
            ogCam.enabled = false;
            puzzleCam.enabled = true;
            FindAnyObjectByType<PlayerMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
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
