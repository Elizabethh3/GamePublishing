using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI speakerName;
    public Image portriat;

    [Header("Data")]
    public DialogDatabaseSO dialogDatabase;
    private Dictionary<int, DialogLineSO> dialogDictionary;
    public float typingSpeed = 0.02f;

    [Header("Input")]
    public InputAction continueDialog;
    private bool inputRecieved; 

    public UnityEvent OnMessageComplete;

    private void Awake()
    {
        continueDialog.Enable();

        continueDialog.performed += ContinueDialog;
    }

    private void Start()
    {
        dialogDatabase.Initialize();
        dialogDictionary = dialogDatabase.dialogDictionary;
    }

    public void ContinueDialog(InputAction.CallbackContext c)
    {
        inputRecieved = true;
    }

    private IEnumerator DisplayMessage(int id)
    {
        dialogText.text = "";

        string currentMessage = dialogDictionary[id].dialogLine;

        for(int i = 0; i < currentMessage.Length; i++)
        {
            dialogText.text += currentMessage[i];
            dialogText.ForceMeshUpdate();
            yield return new WaitForSeconds(typingSpeed);
        }

        inputRecieved = false;
        yield return new WaitUntil(() => inputRecieved);
        OnMessageComplete?.Invoke();
    }

    public void DeactivateDialogueBox()
    {
        GetComponent<Image>().enabled = false;
        dialogText.enabled = false;
        portriat.enabled = false;
        speakerName.enabled = false;
    }

    public void ActivateDialogueBox()
    {
        GetComponent<Image>().enabled = true;
        dialogText.enabled = true;
        portriat.enabled = true;
        speakerName.enabled = true;
    }
    

    public void PlayDialogue(int firstOne, int lastOne)
    {
        StartCoroutine(PlayDialogueRoutine(firstOne, lastOne));
    }

    private IEnumerator PlayDialogueRoutine(int firstOne, int lastOne)
    {
        ActivateDialogueBox();

        for (int i = firstOne; i <= lastOne; i++)
        {
            portriat.sprite = dialogDictionary[i].speakerPortrait;
            speakerName.text = dialogDictionary[i].speakerName;

            yield return StartCoroutine(DisplayMessage(i));
        }
        DeactivateDialogueBox();
    }
}
