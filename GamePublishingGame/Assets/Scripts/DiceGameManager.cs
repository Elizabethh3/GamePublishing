using System;
using Unity.VisualScripting;
using UnityEngine;

public class DiceGameManager : MonoBehaviour
{

    [SerializeField] int playerDiceRoll;
    [SerializeField] int armyDiceRoll;

    [SerializeField] int playerPoints = 0;
    [SerializeField] int armyPoints = 0;

    [SerializeField] GameObject diceGame;

    [SerializeField] GameObject playerDice1;
    [SerializeField] GameObject playerDice2;
    [SerializeField] GameObject playerDice3;
    [SerializeField] GameObject playerDice4;
    [SerializeField] GameObject playerDice5;
    [SerializeField] GameObject playerDice6;

    [SerializeField] GameObject armyDice1;
    [SerializeField] GameObject armyDice2;
    [SerializeField] GameObject armyDice3;
    [SerializeField] GameObject armyDice4;
    [SerializeField] GameObject armyDice5;
    [SerializeField] GameObject armyDice6;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPoints == 3)
        {
            diceGame.SetActive(false);
            playerPoints = 0;
            armyPoints = 0;
            FindAnyObjectByType<ArmyMan>().PuzzleWin();
        }

        if (armyPoints == 3)
        {
            diceGame.SetActive(false);
            playerPoints = 0;
            armyPoints = 0;
            FindAnyObjectByType<GameManager>().goalText.text = "Try to beat him again";
            FindAnyObjectByType<PlayerMovement>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void RollDice()
    {
        playerDiceRoll = UnityEngine.Random.Range(1, 7);
        armyDiceRoll = UnityEngine.Random.Range(1, 7);

        if (playerDiceRoll > armyDiceRoll) playerPoints += 1;
        if (armyDiceRoll > playerDiceRoll) armyPoints += 1;
    }
}
