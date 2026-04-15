using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;

public class Exit : MonoBehaviour
{
    [SerializeField] GameObject winScreen, credits;
    bool inputRecieved;
    public InputAction continueAction;

    void Start()
    {
        winScreen.SetActive(false);
        credits.SetActive(false);
        continueAction.Enable();
        continueAction.performed += OnContinue;
    }
    void FinishGame()
    {
        StartCoroutine(FinishGameSequence());
    }

    public void OnContinue(InputAction.CallbackContext c)
    {
        inputRecieved = true;
    }

    private IEnumerator FinishGameSequence()
    {
        winScreen.SetActive(true);
        inputRecieved = false;
        while (!inputRecieved)
        {
            yield return null;
        }
        winScreen.SetActive(false);
        credits.SetActive(true);
        inputRecieved = false;
        while (!inputRecieved)
        {
            yield return null;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("StartScreen");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FinishGame();
        }
    }
}
