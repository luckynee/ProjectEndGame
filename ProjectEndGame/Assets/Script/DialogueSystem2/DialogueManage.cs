using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManage : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    [SerializeField]
    private float textSpeed;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }

    public void OpenDialogue(Message[] messages, Actor[] actors)
	{
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();
	}

    void DisplayMessage()
	{
        Message messageToDisplay = currentMessages[activeMessage];
        StopAllCoroutines();
        StartCoroutine(TypeSentence(messageToDisplay.message));
        //messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
	}

    public void NextMessage()
	{
        activeMessage++;
        if (activeMessage < currentMessages.Length)
		{
            DisplayMessage();
		} else
		{
            Debug.Log("Conversation ended!");
            isActive = false;
		}
	}

    IEnumerator TypeSentence (string message)
    {
        messageText.text = "";
        foreach (char letter in message.ToCharArray())
        {
            messageText.text += letter;
            yield return new WaitForSeconds(textSpeed); 
        }
    }
}
