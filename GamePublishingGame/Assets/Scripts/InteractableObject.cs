using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] InputAction interactionAction;
    [SerializeField] GameObject player;
    bool isAttached, inRange;
    Rigidbody rigidBody;
    [SerializeField] AudioSource pickUpAudio, putDownAudio;

    void Start()
    {
        interactionAction.Enable();
        interactionAction.performed += PlayerInteract;
        isAttached = false;
        inRange = false;
        rigidBody = GetComponentInParent<Rigidbody>();
        AudioSource[] sources = player.GetComponents<AudioSource>();
        foreach (AudioSource source in sources)
        {
            if (source.clip.name == "pickUpItem")
            {
                pickUpAudio = source;
            }
            else
            {
                putDownAudio = source;
            }
        }
    }

    void PlayerInteract(InputAction.CallbackContext c)
    {
        if (inRange)
        {
            if (!isAttached && gameObject.name != "Peg")
            {
                this.transform.parent.parent = player.transform;
                isAttached = true;
                pickUpAudio.Play();
            }
            else
            {
                this.transform.parent.parent = null;
                isAttached = false;
                putDownAudio.Play();
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
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
