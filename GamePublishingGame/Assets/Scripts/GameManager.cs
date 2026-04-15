using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    bool paused;
    [SerializeField] InputAction pauseAction;
    public TextMeshProUGUI goalText;
    void Awake()
    {
        pauseAction.performed += PauseGame;
    }
    void Start()
    {
        pauseMenu.SetActive(false);
        paused = false;
        //FindAnyObjectByType<DialogBox>().PlayDialogue(0,3);
        //goalText.text = "Remove the block off his face";
    }

    void PauseGame(InputAction.CallbackContext c)
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            OnClickResume();
        }
    }
    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }

    public void OnClickResume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
