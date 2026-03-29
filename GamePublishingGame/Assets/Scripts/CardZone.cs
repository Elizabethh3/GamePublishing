using System.Collections.Generic;
using UnityEngine;

public class CardZone : MonoBehaviour
{
    [SerializeField] List<GameObject> cards = new List<GameObject>();
    int numCardsNeeded = 7;
    public bool allCollected = false;
    void CheckIfCollected()
    {
        if (cards.Count >= numCardsNeeded)
        {
            allCollected = true;
        }
        else
        {
            allCollected = false;
        }
        Debug.Log("Cards in zone: " + cards.Count);
    }
    
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject);
        if (other.CompareTag("Card"))
        {
            if (!cards.Contains(other.gameObject))
            {
                cards.Add(other.gameObject);
                CheckIfCollected();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Card"))
        {
            cards.Remove(other.gameObject);
            CheckIfCollected();
        }
    }
}
