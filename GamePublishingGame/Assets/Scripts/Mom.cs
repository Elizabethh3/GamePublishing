using UnityEngine;
using UnityEngine.InputSystem;

public class Mom : MonoBehaviour
{
    [SerializeField] InputAction interactionAction;
    [SerializeField] GameObject block;
    bool inRange;
    public bool childrenCollected; //ask June how to know this
    void Start()
    {
        interactionAction.Enable();
        interactionAction.performed += PlayerInteract;
        inRange = false;
        childrenCollected = false;
        block.SetActive(false);
    }
    void PlayerInteract(InputAction.CallbackContext c)
    {
        if (inRange & !childrenCollected)
        {
            FindAnyObjectByType<DialogBox>().PlayDialogue(43, 45);
            FindAnyObjectByType<GameManager>().goalText.text = "Find the 4 children!";
        }
        else if (inRange && childrenCollected)
        {
            FindAnyObjectByType<DialogBox>().PlayDialogue(46, 47);
            FindAnyObjectByType<GameManager>().goalText.text = "Explore";
            block.SetActive(true);
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
