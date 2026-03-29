using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boatson : MonoBehaviour
{
    [SerializeField] InputAction interactionAction;
    bool inRange, talked, checkMovement, triggered;
    GameManager gameManager;
    DialogBox dialogBox;
    [SerializeField] GameObject peg, resetScreen;
    Renderer[] renderers;

    void Start()
    {
        interactionAction.Enable();
        interactionAction.performed += PlayerInteract;
        gameManager = FindAnyObjectByType<GameManager>();
        dialogBox = FindAnyObjectByType<DialogBox>();
        StartCoroutine(Wait());
        talked = false;
        checkMovement = false;
        triggered = false;
        renderers = GetComponentsInChildren<Renderer>();
    }
    void PlayerInteract(InputAction.CallbackContext c)
    {
        if (inRange && !talked)
        {
            dialogBox.PlayDialogue(20,23);
            if (gameManager.goalText.text != "" && gameManager.goalText.text != "\nSave Boatson")
            {
                gameManager.goalText.text += "\nSave Boatson";
            }
            else
            {
                gameManager.goalText.text = "Save Boatson";
            }
            talked = true;
        }
    }
    void Update()
    {
        if (!triggered && checkMovement && peg.transform.hasChanged)
        {
            triggered = true;
            resetScreen.SetActive(true);
            dialogBox.PlayDialogue(24,26);
            gameManager.goalText.text = "Explore";
            foreach (Renderer r in renderers)
            {
                r.enabled = false;
            }
            StartCoroutine(TurnOffResetScreen());
            //spawn scrabble tile
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        checkMovement = true;
        peg.transform.hasChanged = false;
    }

    IEnumerator TurnOffResetScreen()
{
    yield return new WaitForSeconds(4);
    resetScreen.SetActive(false);
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
