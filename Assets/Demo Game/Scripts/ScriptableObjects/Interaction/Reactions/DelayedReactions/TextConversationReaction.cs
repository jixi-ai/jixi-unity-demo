using System.Collections;
using System.Collections.Generic;
using JixiAI;
using UnityEngine;
using UnityEngine.AI;

public class TextConversationReaction : Reaction
{
    public PlayerMovement playerMovement;
    public Color textColor = Color.white; 
    public float delay;

    private JixiAIConfig jixiAIConfig;
    private InputFieldManager inputFieldManager;
    private TextManager textManager;
    
    protected override void SpecificInit()
    {
        jixiAIConfig = FindObjectOfType<JixiAIConfig>();
        inputFieldManager = FindObjectOfType<InputFieldManager>();
        textManager = FindObjectOfType<TextManager> ();
        playerMovement.onPlayerMove.AddListener(Reset);
    }

    private void AskNPC(string input)
    {
        textManager.DisplayMessage("...", textColor, delay);
        var playerInputJson = JsonUtility.ToJson(new PlayerInput(input));
        Jixi.Instance.Call(jixiAIConfig.GetActionUrl("Fishman"), playerInputJson, (DialogueResponse response) =>
        {
            textManager.DisplayMessage(response.dialogue, textColor, delay);
        });    
    }

    private void Reset()
    {
        inputFieldManager.HideInputField();
        inputFieldManager.onSubmit.RemoveListener(AskNPC);
    }
    
    protected override void ImmediateReaction()
    {
        inputFieldManager.ShowInput();
        inputFieldManager.onSubmit.AddListener(AskNPC);
    }
}
