using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TextConversationReaction))]
public class TextConversationReactionEditor : ReactionEditor
{
    private SerializedProperty playerMovement;          // Represents the reference to the PlayerMovement script
    private SerializedProperty textColorProperty;       // Represents the color field which is the color of the message to be displayed.
    private SerializedProperty delayProperty;           // Represents the float field which is the delay before the messaage is displayed

    private const string propPlayerMovement = "playerMovement";
                                                        // The name of the field which is the player movement script
    private const string propTextColorName = "textColor";
                                                        // The name of the field which is the color of the message to be written to the screen.
    private const string propDelayName = "delay";
                                                        // The name of the field which is the delay before the message is written to the screen.


    protected override void Init ()
    {
        // Cache all the SerializedProperties.
        playerMovement = serializedObject.FindProperty(propPlayerMovement);
        textColorProperty = serializedObject.FindProperty (propTextColorName);
        delayProperty = serializedObject.FindProperty (propDelayName);
    }


    protected override void DrawReaction ()
    {
        // Display default GUI for the text color and the delay.
        EditorGUILayout.PropertyField (playerMovement);
        EditorGUILayout.PropertyField (textColorProperty);
        EditorGUILayout.PropertyField (delayProperty);
    }


    protected override string GetFoldoutLabel ()
    {
        return "Text Conversation Reaction";
    }
}