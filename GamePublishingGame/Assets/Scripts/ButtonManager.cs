using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject confirmationScreen;
    [SerializeField] GameObject optionsScreen;
    [SerializeField] GameObject pauseScreen;
    void Start()
    {
        if (confirmationScreen != null)
        {
            confirmationScreen.SetActive(false);
        }
    }
    public void OnClickNew()
    {
        confirmationScreen.SetActive(true);
    }

    public void OnClickLoad()
    {
        SceneManager.LoadScene("GameScene");
        //load save and continue game from last checkpoint
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickYes()
    {
        SceneManager.LoadScene("GameScene");
        //delete save file, reset game completely
    }

    public void OnClickNo()
    {
        confirmationScreen.SetActive(false);
    }

    public void OnClickBack()
    {
        optionsScreen.SetActive(false);
    }

    public void OnClickOptions()
    {
        optionsScreen.SetActive(true);
    }
    public void OnClickReturn()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
