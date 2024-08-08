using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialouge : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    [SerializeField] private AudioSource talkingAudio;
    [SerializeField] private AudioSource nextLineAudio;
    private NPC_Controller npcController;
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] public TextMeshProUGUI dialogueText;
    [SerializeField] public string[] dialogue;
    private int index;
    [SerializeField] public float displaySpeed;
    private bool playerIsClose;
    void Start()
    {
        animator = GetComponent<Animator>();
        npcController = GetComponent<NPC_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            animator.SetBool("isWalking", false);
            npcController.checkMoving = false;
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                zeroText();
                talkingAudio.Play();
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        else if (playerIsClose == false)
        {
            animator.SetBool("isWalking", true);
            npcController.checkMoving = true;
            dialoguePanel.SetActive(false);
        }
    }
    public void NextLine()
    {
        nextLineAudio.Play();
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }
    IEnumerator Typing ()
    {
        foreach (char letter in dialogue[index])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(displaySpeed);
        }
    }
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
