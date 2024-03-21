using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue_mision : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
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

    private void Start(){
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = narratorVoice;
    }

    void Update()
    {
        if (isPlayerInRange && (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.F)))
        {
            if (!didDialogueStart)
            {
                GameManager.instance.ocultarInventario();
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
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
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
            GameManager.instance.mostrarInventario(); //aqui se añade linea de codigo para bloquear el dialogo. paralelépipedo
            //SkullPideMonedas.instance.desactivarDialogo();
            SkullPideMonedas.instance.ya = false;
        }
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
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
