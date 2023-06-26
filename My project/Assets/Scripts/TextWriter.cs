using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

//script that handles snail NPC text writing on start menu, sets remaining text to invisible so that the text position stays the same instead of constantly updating and moving
public class TextWriter : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip snelTalk;

    public GameObject playButton;

    private TextMeshProUGUI snailText;

    private string textToWrite;

    private int characterIndex;

    private float timePerCharacter;
    private float timer;

    private bool invisibleCharacters;

    public bool canPlay;
    

    private void Start()
    {
        playButton.GetComponent<Button>().interactable = false;
        canPlay = false;
        audioSource.PlayOneShot(snelTalk, 2f);
    }

    public void AddWriter(TextMeshProUGUI snailText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        this.snailText = snailText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
    }
    private void Update()
    {
        if (snailText)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                //display next character
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                snailText.text = text;

                if(characterIndex >= textToWrite.Length)
                {
                    //entire string displayed
                    canPlay = true;
                    playButton.GetComponent<Button>().interactable = true;
                    snailText = null;
                    return;

                }
            }
        }
    }
}
