using UnityEngine;
using UnityEngine.InputSystem;

public class DishitaClick : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public float interactDistance = 3f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < interactDistance)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                dialogueManager.StartDialogue();
            }
        }
    }
}