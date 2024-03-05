using System.Collections;
using UnityEngine;
using TMPro;

public class ObligatoryDialogue : MonoBehaviour
{

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private float typingTime;
     
    [SerializeField] private AudioClip narratorVoice; 
    [SerializeField] private int charsToSound;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private AudioSource audioSource;
    private bool dialogueFinished = false;

    
    private void Start(){
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = narratorVoice;
    }

    void Update()
    {
        if(isPlayerInRange)
        {   
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {   StartCoroutine(PauseCoroutine());
        lineIndex++;
    if (lineIndex < dialogueLines.Length)
    {
        StartCoroutine(ShowLine());
    }
    else
    {
        StartCoroutine(PauseCoroutine());
        didDialogueStart = false;
        // Desactivar el trigger:
        dialoguePanel.SetActive(false);
        Time.timeScale = 1f;
        GetComponent<Collider2D>().enabled = false;
    }
    }
    private IEnumerator PauseCoroutine()
    {
        // Pausa de 3 segundos
        yield return new WaitForSeconds(3.0f);
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        int charIndex = 0;
        foreach(char ch in dialogueLines[lineIndex])
        {
            
            dialogueText.text += ch;
            if (charIndex % charsToSound == 0){
                audioSource.Play();
            }
            charIndex ++;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("Player") && !dialogueFinished)
    {
        isPlayerInRange = true;
        audioSource.Play();
    }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
