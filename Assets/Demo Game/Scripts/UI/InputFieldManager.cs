using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class InputFieldManager : MonoBehaviour
{
    public TMP_InputField inputField; // Reference to the TextMeshPro Input Field
    public UnityEvent<string> onSubmit; // Public UnityEvent

    void Start()
    {
        if (inputField != null)
        {
            // Add a listener to the onEndEdit event
            inputField.onEndEdit.AddListener(delegate { CheckForEnter(inputField); });
        }
        else
        {
            Debug.LogWarning("InputFieldEnter: No input field assigned!");
        }
    }

    public void ShowInput()
    {
        inputField.gameObject.SetActive(true);
    }

    public void HideInputField()
    {
        inputField.gameObject.SetActive(false);
    }
    
    // Method to check if the "Enter" key was pressed
    private void CheckForEnter(TMP_InputField input)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            onSubmit.Invoke(input.text); // Invoke the UnityEvent
            input.text = "";
        }
    }
}