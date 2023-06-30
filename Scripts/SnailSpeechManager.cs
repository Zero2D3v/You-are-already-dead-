using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//script responsible for Snail NPC fact text on start menu
public class SnailSpeechManager : MonoBehaviour
{
    public TextWriter textWriter;
    private TextMeshProUGUI messageText;

    private void Awake()
    {
        messageText = GameObject.Find("NPK fact").GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        textWriter.AddWriter(messageText, "Did you know... all plants need NITROGEN, PHOSPHORUS AND POTASSIUM to grow big? ...............           YUM!", 0.05f, true);
    }
}
