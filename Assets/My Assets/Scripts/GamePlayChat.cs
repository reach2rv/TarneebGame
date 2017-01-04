using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayChat : MonoBehaviour
{
    public float disappearTime = 5f;
    private float countdownTimer;
    public Text chatOutput;
    private int textInChat = 7;
    private Queue<string> chatLog = new Queue<string>();

    void Awake()
    {
        this.gameObject.SetActive(false);
    }

    private void UpdateChatLog(string _sender, string _message)
    {
        chatLog.Enqueue("<b>" + _sender + "</b>\n<color=black>" + _message + "</color>" + "\n");
        if (chatLog.Count > textInChat)
        {
            chatLog.Dequeue();
        }
        chatOutput.text = string.Empty;
        foreach (string logEntry in chatLog.ToArray())
        {
            chatOutput.text += logEntry + "\n";
        }
    }

    void Update()
    {
        countdownTimer += Time.deltaTime;
        if (countdownTimer >= disappearTime)
        {
            countdownTimer = 0;
            this.gameObject.SetActive(false);
        }
    }

    public void CallChallengeChat(GameSparks.Api.Messages.ChallengeChatMessage _message)
    {
        this.gameObject.SetActive(true);
        var sender = _message.Who;
        var message = _message.Message;
        UpdateChatLog(sender, message);
    }

    public void SendChatText(string _message)
    {
        new GameSparks.Api.Requests.ChatOnChallengeRequest()
            .SetChallengeInstanceId("")
            .SetMessage(_message)
            .Send((response) =>
            {


            });
    }
}
