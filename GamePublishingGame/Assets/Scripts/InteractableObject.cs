using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] InputAction interactionAction;
    [SerializeField] GameObject player;
    bool isAttached, inRange;
    Rigidbody rigidBody;
    AudioSource pickUpItem, placeItem;

    void Start()
    {
        interactionAction.Enable();
        interactionAction.performed += PlayerInteract;
        isAttached = false;
        inRange = false;
        rigidBody = GetComponentInParent<Rigidbody>();
        AudioSource[] audioSources = player.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.clip.name == "pickUpItem")
            {
                pickUpItem = audioSource;
            }
            else
            {
                placeItem = audioSource;
            }
        }
    }

    void PlayerInteract(InputAction.CallbackContext c)
    {
        if (inRange)
        {
            if (!isAttached && this.gameObject.tag != "Daughter" )
            {
                this.transform.parent.parent = player.transform;
                isAttached = true;
                pickUpItem.Play();
            }
            else if (isAttached && this.gameObject.tag != "Daughter")
            {
                this.transform.parent.parent = null;
                isAttached = false;
                placeItem.Play();
            }
            //when e is clicked, the object will connect with the player
            //the block will then move with the player
            //when e is clicked again, the object will disconnect and stay where it is
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }

        if (other.CompareTag("Player") && this.gameObject.tag == "Daughter")
        {
            this.gameObject.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
