using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MastermindPuzzleLogic : MonoBehaviour
{
    enum Color
    {
       Blue,
       Red, 
       Orange,
       Yellow,
       Green, 
       Purple 
    }
    List<Color> colors = new List<Color>
    {
        Color.Blue, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Purple
    };
    List<Color> solution = new List<Color>();
    System.Random rand = new System.Random();
    int numAttempts, arrayIndex;
    [SerializeField] GameObject bluePrefab, redPrefab, orangePrefab, yellowPrefab, greenPrefab, purplePrefab, correct, wrongPlace;
    [SerializeField] GameObject[] attempt1, attempt2, attempt3, attempt4, attempt5, attempt6, attempt7, attempt8;
    [SerializeField] GameObject[] correct1, correct2, correct3, correct4, correct5, correct6, correct7, correct8;
    Color[] colorAttempt1, colorAttempt2, colorAttempt3, colorAttempt4, colorAttempt5, colorAttempt6, colorAttempt7, colorAttempt8;
    int numCorrect;


    void Start()
    {
        numAttempts = 1;
        numCorrect = 0;
        arrayIndex = 0;
        colorAttempt1 = new Color[6];
        colorAttempt2 = new Color[6];
        colorAttempt3 = new Color[6];
        colorAttempt4 = new Color[6];
        colorAttempt5 = new Color[6];
        colorAttempt6 = new Color[6];
        colorAttempt7 = new Color[6];
        colorAttempt8 = new Color[6];
        RandomizeSolution();
    }

    void RandomizeSolution()
    {
        solution.Clear();
        for (int i = 0; i <= 5; i++)
        {
            int num = rand.Next(0, 6);
            solution.Add(colors[num]);
        }
        Debug.Log(string.Join(", ", solution));
    }
    public void OnClickColor(string color)
    {
        Debug.Log($"{color} is clicked");
        switch (color)
        {
            case "blue":
                switch (numAttempts)
                {
                    case 1:
                        Instantiate(bluePrefab, attempt1[arrayIndex].transform);
                        colorAttempt1[arrayIndex] = Color.Blue;
                        arrayIndex += 1;
                        break;
                    case 2:
                        Instantiate(bluePrefab, attempt2[arrayIndex].transform);
                        colorAttempt2[arrayIndex] = Color.Blue;
                        arrayIndex += 1;
                        break;
                    case 3:
                        Instantiate(bluePrefab, attempt3[arrayIndex].transform);
                        colorAttempt3[arrayIndex] = Color.Blue;
                        arrayIndex += 1;
                        break;
                    case 4:
                        Instantiate(bluePrefab, attempt4[arrayIndex].transform);
                        colorAttempt4[arrayIndex] = Color.Blue;
                        arrayIndex += 1;
                        break;
                    case 5:
                        Instantiate(bluePrefab, attempt5[arrayIndex].transform);
                        colorAttempt5[arrayIndex] = Color.Blue;
                        arrayIndex += 1;
                        break;
                    case 6:
                        Instantiate(bluePrefab, attempt6[arrayIndex].transform);
                        colorAttempt6[arrayIndex] = Color.Blue;
                        arrayIndex += 1;
                        break;
                    case 7:
                        Instantiate(bluePrefab, attempt7[arrayIndex].transform);
                        colorAttempt7[arrayIndex] = Color.Blue;
                        arrayIndex += 1;
                        break;
                    case 8:
                        Instantiate(bluePrefab, attempt8[arrayIndex].transform);
                        colorAttempt8[arrayIndex] = Color.Blue;
                        arrayIndex += 1;
                        break;
                }
                break;
            case "red":
                switch (numAttempts)
                {
                    case 1:
                        Instantiate(redPrefab, attempt1[arrayIndex].transform);
                        colorAttempt1[arrayIndex] = Color.Red;
                        arrayIndex += 1;
                        break;
                    case 2:
                        Instantiate(redPrefab, attempt2[arrayIndex].transform);
                        colorAttempt2[arrayIndex] = Color.Red;
                        arrayIndex += 1;
                        break;
                    case 3:
                        Instantiate(redPrefab, attempt3[arrayIndex].transform);
                        colorAttempt3[arrayIndex] = Color.Red;
                        arrayIndex += 1;
                        break;
                    case 4:
                        Instantiate(redPrefab, attempt4[arrayIndex].transform);
                        colorAttempt4[arrayIndex] = Color.Red;
                        arrayIndex += 1;
                        break;
                    case 5:
                        Instantiate(redPrefab, attempt5[arrayIndex].transform);
                        colorAttempt5[arrayIndex] = Color.Red;
                        arrayIndex += 1;
                        break;
                    case 6:
                        Instantiate(redPrefab, attempt6[arrayIndex].transform);
                        colorAttempt6[arrayIndex] = Color.Red;
                        arrayIndex += 1;
                        break;
                    case 7:
                        Instantiate(redPrefab, attempt7[arrayIndex].transform);
                        colorAttempt7[arrayIndex] = Color.Red;
                        arrayIndex += 1;
                        break;
                    case 8:
                        Instantiate(redPrefab, attempt8[arrayIndex].transform);
                        colorAttempt8[arrayIndex] = Color.Red;
                        arrayIndex += 1;
                        break;
                }
                break;
            case "orange":
                switch (numAttempts)
                {
                    case 1:
                        Instantiate(orangePrefab, attempt1[arrayIndex].transform);
                        colorAttempt1[arrayIndex] = Color.Orange;
                        arrayIndex += 1;
                        break;
                    case 2:
                        Instantiate(orangePrefab, attempt2[arrayIndex].transform);
                        colorAttempt2[arrayIndex] = Color.Orange;
                        arrayIndex += 1;
                        break;
                    case 3:
                        Instantiate(orangePrefab, attempt3[arrayIndex].transform);
                        colorAttempt3[arrayIndex] = Color.Orange;
                        arrayIndex += 1;
                        break;
                    case 4:
                        Instantiate(orangePrefab, attempt4[arrayIndex].transform);
                        colorAttempt4[arrayIndex] = Color.Orange;
                        arrayIndex += 1;
                        break;
                    case 5:
                        Instantiate(orangePrefab, attempt5[arrayIndex].transform);
                        colorAttempt5[arrayIndex] = Color.Orange;
                        arrayIndex += 1;
                        break;
                    case 6:
                        Instantiate(orangePrefab, attempt6[arrayIndex].transform);
                        colorAttempt6[arrayIndex] = Color.Orange;
                        arrayIndex += 1;
                        break;
                    case 7:
                        Instantiate(orangePrefab, attempt7[arrayIndex].transform);
                        colorAttempt7[arrayIndex] = Color.Orange;
                        arrayIndex += 1;
                        break;
                    case 8:
                        Instantiate(orangePrefab, attempt8[arrayIndex].transform);
                        colorAttempt8[arrayIndex] = Color.Orange;
                        arrayIndex += 1;
                        break;
                }
                break;
            case "yellow":
                switch (numAttempts)
                {
                    case 1:
                        Instantiate(yellowPrefab, attempt1[arrayIndex].transform);
                        colorAttempt1[arrayIndex] = Color.Yellow;
                        arrayIndex += 1;
                        break;
                    case 2:
                        Instantiate(yellowPrefab, attempt2[arrayIndex].transform);
                        colorAttempt2[arrayIndex] = Color.Yellow;
                        arrayIndex += 1;
                        break;
                    case 3:
                        Instantiate(yellowPrefab, attempt3[arrayIndex].transform);
                        colorAttempt3[arrayIndex] = Color.Yellow;
                        arrayIndex += 1;
                        break;
                    case 4:
                        Instantiate(yellowPrefab, attempt4[arrayIndex].transform);
                        colorAttempt4[arrayIndex] = Color.Yellow;
                        arrayIndex += 1;
                        break;
                    case 5:
                        Instantiate(yellowPrefab, attempt5[arrayIndex].transform);
                        colorAttempt5[arrayIndex] = Color.Yellow;
                        arrayIndex += 1;
                        break;
                    case 6:
                        Instantiate(yellowPrefab, attempt6[arrayIndex].transform);
                        colorAttempt6[arrayIndex] = Color.Yellow;
                        arrayIndex += 1;
                        break;
                    case 7:
                        Instantiate(yellowPrefab, attempt7[arrayIndex].transform);
                        colorAttempt7[arrayIndex] = Color.Yellow;
                        arrayIndex += 1;
                        break;
                    case 8:
                        Instantiate(yellowPrefab, attempt8[arrayIndex].transform);
                        colorAttempt8[arrayIndex] = Color.Yellow;
                        arrayIndex += 1;
                        break;
                }
                break;
            case "green":
                switch (numAttempts)
                {
                    case 1:
                        Instantiate(greenPrefab, attempt1[arrayIndex].transform);
                        colorAttempt1[arrayIndex] = Color.Green;
                        arrayIndex += 1;
                        break;
                    case 2:
                        Instantiate(greenPrefab, attempt2[arrayIndex].transform);
                        colorAttempt2[arrayIndex] = Color.Green;
                        arrayIndex += 1;
                        break;
                    case 3:
                        Instantiate(greenPrefab, attempt3[arrayIndex].transform);
                        colorAttempt3[arrayIndex] = Color.Green;
                        arrayIndex += 1;
                        break;
                    case 4:
                        Instantiate(greenPrefab, attempt4[arrayIndex].transform);
                        colorAttempt4[arrayIndex] = Color.Green;
                        arrayIndex += 1;
                        break;
                    case 5:
                        Instantiate(greenPrefab, attempt5[arrayIndex].transform);
                        colorAttempt5[arrayIndex] = Color.Green;
                        arrayIndex += 1;
                        break;
                    case 6:
                        Instantiate(greenPrefab, attempt6[arrayIndex].transform);
                        colorAttempt6[arrayIndex] = Color.Green;
                        arrayIndex += 1;
                        break;
                    case 7:
                        Instantiate(greenPrefab, attempt7[arrayIndex].transform);
                        colorAttempt7[arrayIndex] = Color.Green;
                        arrayIndex += 1;
                        break;
                    case 8:
                        Instantiate(greenPrefab, attempt8[arrayIndex].transform);
                        colorAttempt8[arrayIndex] = Color.Green;
                        arrayIndex += 1;
                        break;
                }
                break;
            case "purple":
                switch (numAttempts)
                {
                    case 1:
                        Instantiate(purplePrefab, attempt1[arrayIndex].transform);
                        colorAttempt1[arrayIndex] = Color.Purple;
                        arrayIndex += 1;
                        break;
                    case 2:
                        Instantiate(purplePrefab, attempt2[arrayIndex].transform);
                        colorAttempt2[arrayIndex] = Color.Purple;
                        arrayIndex += 1;
                        break;
                    case 3:
                        Instantiate(purplePrefab, attempt3[arrayIndex].transform);
                        colorAttempt3[arrayIndex] = Color.Purple;
                        arrayIndex += 1;
                        break;
                    case 4:
                        Instantiate(purplePrefab, attempt4[arrayIndex].transform);
                        colorAttempt4[arrayIndex] = Color.Purple;
                        arrayIndex += 1;
                        break;
                    case 5:
                        Instantiate(purplePrefab, attempt5[arrayIndex].transform);
                        colorAttempt5[arrayIndex] = Color.Purple;
                        arrayIndex += 1;
                        break;
                    case 6:
                        Instantiate(purplePrefab, attempt6[arrayIndex].transform);
                        colorAttempt6[arrayIndex] = Color.Purple;
                        arrayIndex += 1;
                        break;
                    case 7:
                        Instantiate(purplePrefab, attempt7[arrayIndex].transform);
                        colorAttempt7[arrayIndex] = Color.Purple;
                        arrayIndex += 1;
                        break;
                    case 8:
                        Instantiate(purplePrefab, attempt8[arrayIndex].transform);
                        colorAttempt8[arrayIndex] = Color.Purple;
                        arrayIndex += 1;
                        break;
                }
                break;
        }
        if (arrayIndex == 6)
        {
            CheckPlacement();
            if (numCorrect == 6)
            {
                Win();
            }
            numAttempts += 1;
            arrayIndex = 0;
            if (numAttempts > 8)
            {
                RandomizeSolution();
                numAttempts = 1;
                //clear board
            }
        }
    }

    void CheckPlacement()
    {
        numCorrect = 0;
        bool[] solutionUsed = new bool[6];
        bool[] guessUsed = new bool[6];
        switch (numAttempts)
        {
            case 1:
                for (int i = 0; i < solution.Count; i++)
                {
                    if (solution[i] == colorAttempt1[i])
                    {
                        Instantiate(correct, correct1[i].transform);
                        numCorrect += 1;
                        solutionUsed[i] = true;
                        guessUsed[i] = true;
                    }
                }
                for (int i = 0; i < solution.Count; i++)
                {
                    if (!guessUsed[i])
                    {
                        for (int j = 0; j < solution.Count; j++)
                        {
                            if (!solutionUsed[j])
                            {
                                if (colorAttempt1[i] == solution[j])
                                {
                                    Instantiate(wrongPlace, correct1[i].transform);
                                    solutionUsed[j] = true;
                                    guessUsed[i] = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                break;
            case 2:
                for (int i = 0; i < solution.Count; i++)
                {
                    if (solution[i] == colorAttempt2[i])
                    {
                        Instantiate(correct, correct2[i].transform);
                        numCorrect += 1;
                        solutionUsed[i] = true;
                        guessUsed[i] = true;
                    }
                }
                for (int i = 0; i < solution.Count; i++)
                {
                    if (!guessUsed[i])
                    {
                        for (int j = 0; j < solution.Count; j++)
                        {
                            if (!solutionUsed[j])
                            {
                                if (colorAttempt2[i] == solution[j])
                                {
                                    Instantiate(wrongPlace, correct2[i].transform);
                                    solutionUsed[j] = true;
                                    guessUsed[i] = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                break;
            case 3:
                for (int i = 0; i < solution.Count; i++)
                {
                    if (solution[i] == colorAttempt3[i])
                    {
                        Instantiate(correct, correct3[i].transform);
                        numCorrect += 1;
                        solutionUsed[i] = true;
                        guessUsed[i] = true;
                    }
                }
                for (int i = 0; i < solution.Count; i++)
                {
                    if (!guessUsed[i])
                    {
                        for (int j = 0; j < solution.Count; j++)
                        {
                            if (!solutionUsed[j])
                            {
                                if (colorAttempt3[i] == solution[j])
                                {
                                    Instantiate(wrongPlace, correct3[i].transform);
                                    solutionUsed[j] = true;
                                    guessUsed[i] = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                break;
            case 4:
                for (int i = 0; i < solution.Count; i++)
                {
                    if (solution[i] == colorAttempt4[i])
                    {
                        Instantiate(correct, correct4[i].transform);
                        numCorrect += 1;
                        solutionUsed[i] = true;
                        guessUsed[i] = true;
                    }
                }
                for (int i = 0; i < solution.Count; i++)
                {
                    if (!guessUsed[i])
                    {
                        for (int j = 0; j < solution.Count; j++)
                        {
                            if (!solutionUsed[j])
                            {
                                if (colorAttempt4[i] == solution[j])
                                {
                                    Instantiate(wrongPlace, correct4[i].transform);
                                    solutionUsed[j] = true;
                                    guessUsed[i] = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                break;
            case 5:
                for (int i = 0; i < solution.Count; i++)
                {
                    if (solution[i] == colorAttempt5[i])
                    {
                        Instantiate(correct, correct5[i].transform);
                        numCorrect += 1;
                        solutionUsed[i] = true;
                        guessUsed[i] = true;
                    }
                }
                for (int i = 0; i < solution.Count; i++)
                {
                    if (!guessUsed[i])
                    {
                        for (int j = 0; j < solution.Count; j++)
                        {
                            if (!solutionUsed[j])
                            {
                                if (colorAttempt5[i] == solution[j])
                                {
                                    Instantiate(wrongPlace, correct5[i].transform);
                                    solutionUsed[j] = true;
                                    guessUsed[i] = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                break;
            case 6:
                for (int i = 0; i < solution.Count; i++)
                {
                    if (solution[i] == colorAttempt6[i])
                    {
                        Instantiate(correct, correct6[i].transform);
                        numCorrect += 1;
                        solutionUsed[i] = true;
                        guessUsed[i] = true;
                    }
                }
                for (int i = 0; i < solution.Count; i++)
                {
                    if (!guessUsed[i])
                    {
                        for (int j = 0; j < solution.Count; j++)
                        {
                            if (!solutionUsed[j])
                            {
                                if (colorAttempt6[i] == solution[j])
                                {
                                    Instantiate(wrongPlace, correct6[i].transform);
                                    solutionUsed[j] = true;
                                    guessUsed[i] = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                break;
            case 7:
                for (int i = 0; i < solution.Count; i++)
                {
                    if (solution[i] == colorAttempt7[i])
                    {
                        Instantiate(correct, correct7[i].transform);
                        numCorrect += 1;
                        solutionUsed[i] = true;
                        guessUsed[i] = true;
                    }
                }
                for (int i = 0; i < solution.Count; i++)
                {
                    if (!guessUsed[i])
                    {
                        for (int j = 0; j < solution.Count; j++)
                        {
                            if (!solutionUsed[j])
                            {
                                if (colorAttempt7[i] == solution[j])
                                {
                                    Instantiate(wrongPlace, correct7[i].transform);
                                    solutionUsed[j] = true;
                                    guessUsed[i] = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                break;
            case 8:
                for (int i = 0; i < solution.Count; i++)
                {
                    if (solution[i] == colorAttempt8[i])
                    {
                        Instantiate(correct, correct8[i].transform);
                        numCorrect += 1;
                        solutionUsed[i] = true;
                        guessUsed[i] = true;
                    }
                }
                for (int i = 0; i < solution.Count; i++)
                {
                    if (!guessUsed[i])
                    {
                        for (int j = 0; j < solution.Count; j++)
                        {
                            if (!solutionUsed[j])
                            {
                                if (colorAttempt8[i] == solution[j])
                                {
                                    Instantiate(wrongPlace, correct8[i].transform);
                                    solutionUsed[j] = true;
                                    guessUsed[i] = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                break;
        }
    }

    void Win()
    { 
        //return to normal game
        Debug.Log("WIN");
        FindAnyObjectByType<Pawnerella>().PuzzleWin();
    }
}

    //randomize solution
    //keep track of attempts
    //have each click on a color place the color in the proper list
    //place circles underneath the attempt once the list is full to 
    //show if the color is in the right spots
    //If they fail to get in the amount of attempts reset?
    //When they succeed -> return to normal cam and have Pawnerella talk again
    //spawn block
    //change cursor back to locked
