using System.Collections;
using UnityEngine;

public class Capitalism : MonoBehaviour
{
    bool triggered = false;
    bool checkMovement = false;

    
    void Start()
    {
        StartCoroutine(Wait());
    }
    void Update()
    {
        if (checkMovement && !triggered && transform.hasChanged)
        {
            triggered = true;
            transform.hasChanged = false;
            StartCoroutine(WaitAgain());
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        checkMovement = true;
        transform.hasChanged = false;
    }
    private IEnumerator WaitAgain()
    {
        yield return new WaitForSeconds(2);
        FindAnyObjectByType<DialogBox>().PlayDialogue(4,9);
        FindAnyObjectByType<GameManager>().goalText.text = "Open the door";
    }
}
