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

    [SerializeField] GameObject playerPoint1;
    [SerializeField] GameObject playerPoint2;
    [SerializeField] GameObject playerPoint3;


    [SerializeField] GameObject armyPoint1;
    [SerializeField] GameObject armyPoint2;
    [SerializeField] GameObject armyPoint3;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetPoints();
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
            ResetPoints();
            playerPoints = 0;
            armyPoints = 0;
            FindAnyObjectByType<GameManager>().goalText.text = "Try to beat him again";
            FindAnyObjectByType<PlayerMovement>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ResetPoints()
    {
        playerPoint1.SetActive(false);
        playerPoint2.SetActive(false);
        playerPoint3.SetActive(false);
        armyPoint1.SetActive(false);
        armyPoint2.SetActive(false);
        armyPoint3.SetActive(false);
    }

    public void RollDice()
    {
        playerDiceRoll = UnityEngine.Random.Range(1, 7);
        armyDiceRoll = UnityEngine.Random.Range(1, 7);

        if (playerDiceRoll > armyDiceRoll) playerPoints += 1;
        if (armyDiceRoll > playerDiceRoll) armyPoints += 1;

        #region this is awful dont look
        if (playerDiceRoll == 1)
        {
            playerDice1.SetActive(true);
            playerDice2.SetActive(false);
            playerDice3.SetActive(false);
            playerDice4.SetActive(false);
            playerDice5.SetActive(false);
            playerDice6.SetActive(false);
        }

        if (playerDiceRoll == 2)
        {
            playerDice1.SetActive(false);
            playerDice2.SetActive(true);
            playerDice3.SetActive(false);
            playerDice4.SetActive(false);
            playerDice5.SetActive(false);
            playerDice6.SetActive(false);
        }

        if (playerDiceRoll == 3)
        {
            playerDice1.SetActive(false);
            playerDice2.SetActive(false);
            playerDice3.SetActive(true);
            playerDice4.SetActive(false);
            playerDice5.SetActive(false);
            playerDice6.SetActive(false);
        }

        if (playerDiceRoll == 4)
        {
            playerDice1.SetActive(false);
            playerDice2.SetActive(false);
            playerDice3.SetActive(false);
            playerDice4.SetActive(true);
            playerDice5.SetActive(false);
            playerDice6.SetActive(false);
        }

        if (playerDiceRoll == 5)
        {
            playerDice1.SetActive(false);
            playerDice2.SetActive(false);
            playerDice3.SetActive(false);
            playerDice4.SetActive(false);
            playerDice5.SetActive(true);
            playerDice6.SetActive(false);
        }

        if (playerDiceRoll == 6)
        {
            playerDice1.SetActive(false);
            playerDice2.SetActive(false);
            playerDice3.SetActive(false);
            playerDice4.SetActive(false);
            playerDice5.SetActive(false);
            playerDice6.SetActive(true);
        }

        if (armyDiceRoll == 1)
        {
            armyDice1.SetActive(true);
            armyDice2.SetActive(false);
            armyDice3.SetActive(false);
            armyDice4.SetActive(false);
            armyDice5.SetActive(false);
            armyDice6.SetActive(false);
        }

        if (armyDiceRoll == 2)
        {
            armyDice1.SetActive(false);
            armyDice2.SetActive(true);
            armyDice3.SetActive(false);
            armyDice4.SetActive(false);
            armyDice5.SetActive(false);
            armyDice6.SetActive(false);
        }

        if (armyDiceRoll == 3)
        {
            armyDice1.SetActive(false);
            armyDice2.SetActive(false);
            armyDice3.SetActive(true);
            armyDice4.SetActive(false);
            armyDice5.SetActive(false);
            armyDice6.SetActive(false);
        }

        if (armyDiceRoll == 4)
        {
            armyDice1.SetActive(false);
            armyDice2.SetActive(false);
            armyDice3.SetActive(false);
            armyDice4.SetActive(true);
            armyDice5.SetActive(false);
            armyDice6.SetActive(false);
        }

        if (armyDiceRoll == 5)
        {
            armyDice1.SetActive(false);
            armyDice2.SetActive(false);
            armyDice3.SetActive(false);
            armyDice4.SetActive(false);
            armyDice5.SetActive(true);
            armyDice6.SetActive(false);
        }

        if (armyDiceRoll == 6)
        {
            armyDice1.SetActive(false);
            armyDice2.SetActive(false);
            armyDice3.SetActive(false);
            armyDice4.SetActive(false);
            armyDice5.SetActive(false);
            armyDice6.SetActive(true);
        }
        #endregion
    
        if (playerPoints == 1)
        {
            playerPoint1.SetActive(true);
        }

        if (playerPoints == 2)
        {
            playerPoint1.SetActive(true);
            playerPoint2.SetActive(true);
        }

        if (playerPoints == 3)
        {
            playerPoint1.SetActive(true);
            playerPoint2.SetActive(true);
            playerPoint3.SetActive(true);
        }

        if (armyPoints == 1)
        {
            armyPoint1.SetActive(true);
        }

        if (armyPoints == 2)
        {
            armyPoint1.SetActive(true);
            armyPoint2.SetActive(true);
        }

        if (armyPoints == 3)
        {
            armyPoint1.SetActive(true);
            armyPoint2.SetActive(true);
            armyPoint3.SetActive(true);
        }
    }
}
