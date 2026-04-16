using System;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] GameObject daughter1;
    [SerializeField] GameObject daughter1Safe;

    [SerializeField] GameObject daughter2;
    [SerializeField] GameObject daughter2Safe;

    [SerializeField] GameObject daughter3;
    [SerializeField] GameObject daughter3Safe;

    [SerializeField] GameObject daughter4;
    [SerializeField] GameObject daughter4Safe;
    [SerializeField] Mom mom;


    // Update is called once per frame
    void Update()
    {
        if (daughter1.activeInHierarchy == false)
        {
            daughter1Safe.SetActive(true);
        }

        if (daughter2.activeInHierarchy == false)
        {
            daughter2Safe.SetActive(true);
        }

        if (daughter3.activeInHierarchy == false)
        {
            daughter3Safe.SetActive(true);
        }

        if (daughter4.activeInHierarchy == false)
        {
            daughter4Safe.SetActive(true);
        }

        if (daughter1Safe.activeInHierarchy == true && 
            daughter2Safe.activeInHierarchy == true && 
            daughter3Safe.activeInHierarchy == true && 
            daughter4Safe.activeInHierarchy == true)
            {
                mom.childrenCollected = true;
            }
    }
}
