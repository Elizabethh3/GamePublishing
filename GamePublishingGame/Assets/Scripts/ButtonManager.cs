using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject confirmationScreen;
    [SerializeField] GameObject optionsScreen;
    [SerializeField] GameObject pauseScreen, titleScreen;
    [SerializeField] AudioSource buttonClick;
    SceneLoader sceneLoader;
    void Start()
    {
        sceneLoader = FindAnyObjectByType<SceneLoader>();
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
        sceneLoader.LoadScene(1);
        titleScreen.SetActive(false);
        //SceneManager.LoadScene("GameScene");
        //load save and continue game from last checkpoint
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickYes()
    {
        sceneLoader.LoadScene(1);
        titleScreen.SetActive(false);
        confirmationScreen.SetActive(false);
        //SceneManager.LoadScene("GameScene");
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

    public void OnClickAudio()
    {
        buttonClick.Play();
    }


}
