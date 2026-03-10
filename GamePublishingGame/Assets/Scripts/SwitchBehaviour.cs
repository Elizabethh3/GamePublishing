using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool triggered = false;

    void Update()
    {
        if (triggered)
        {
            door.SetActive(false);
            if (door.name == "Door1")
            {
                FindAnyObjectByType<GameManager>().goalText.text = "Explore";
            }
        }
        else if (!triggered)
        {
            door.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            triggered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            triggered = false;
        }
    }
}
