using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wizard : MonoBehaviour
{
    [SerializeField] InputAction interactionAction;
    bool inRange;
    bool talked, inZone;
    [SerializeField] GameObject cardZone, puzzleCanvas, block, house;
    [SerializeField] List<GameObject> cards;

    void Start()
    {
        interactionAction.Enable();
        interactionAction.performed += PlayerInteract;
        inRange = false;
        talked = false;
        inZone = false;
        block.SetActive(false);
        puzzleCanvas.SetActive(false);
        house.SetActive(false);
    }

    void PlayerInteract(InputAction.CallbackContext c)
    {
        if (inRange && !talked)
        {
            //first set of dialogue
            FindAnyObjectByType<DialogBox>().PlayDialogue(27, 31);
            FindAnyObjectByType<GameManager>().goalText.text = "Gather all the cards";
            talked = true;
        }
        else if (inRange && talked && !cardZone.GetComponent<CardZone>().allCollected)
        {
            //talked when its not done
            FindAnyObjectByType<DialogBox>().PlayDialogue(37, 37);
        }
        else if (inRange && talked && cardZone.GetComponent<CardZone>().allCollected && !inZone)
        {
            //has all cards collected
            FindAnyObjectByType<DialogBox>().PlayDialogue(32, 33);
            FindAnyObjectByType<GameManager>().goalText.text = "Rebuild the wizard's house";
            inZone = true;
        }
        else if (inRange && talked && cardZone.GetComponent<CardZone>().allCollected && inZone)
        {
            //bring up puzzle canvas
            puzzleCanvas.SetActive(true);
            FindAnyObjectByType<PlayerMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void PuzzleWin()
    {
        puzzleCanvas.SetActive(false);
        FindAnyObjectByType<DialogBox>().PlayDialogue(34, 36);
        block.SetActive(true);
        FindAnyObjectByType<GameManager>().goalText.text = "Explore";
        house.SetActive(true);
        FindAnyObjectByType<PlayerMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        foreach (GameObject c in cards)
        {
            c.SetActive(false);
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
