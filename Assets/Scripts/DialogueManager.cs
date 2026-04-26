using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;


public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;
    public GameObject startButton;
    public GameObject handsUI;
    public float typingSpeed = 0.04f;

    private string[] lines = {
        "Kid! You made it this far, but this is only the beginning. There are many things you'll need to learn, but for today, let me show you how to carry yourself in front of other students. Because after this, you're walking through those school doors as one of them.",
        "Alright, I've unlocked the first scene. Go ahead and hit it. Let's get you in!"
    };

    private int currentLine = 0;
    private bool isTyping = false;

    void Start()
    {
        dialogueUI.SetActive(false);
        startButton.SetActive(false);
    }

    public void StartDialogue()
    {
        dialogueUI.SetActive(true);
        handsUI.SetActive(false);
        currentLine = 0;
        StartCoroutine(TypeLine(lines[currentLine]));
    }

    void Update()
    {
        if (!dialogueUI.activeSelf) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = lines[currentLine];
                isTyping = false;
            }
            else
            {
                currentLine++;
                if (currentLine < lines.Length)
                {
                    StartCoroutine(TypeLine(lines[currentLine]));
                }
                else
                {
                    dialogueUI.SetActive(false);
                    handsUI.SetActive(true);
                }
            }
        }
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
        if (currentLine == lines.Length - 1)
            Debug.Log("Activating start button!");
        startButton.SetActive(true);
    }
}