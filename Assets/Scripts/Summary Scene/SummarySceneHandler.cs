using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SummarySceneHandler : MonoBehaviour
{
    public TextMeshProUGUI antennaErrorText; // Assign in Inspector
    public TextMeshProUGUI rightCornerboardErrorText; // Assign in Inspector
    public TextMeshProUGUI leftCornerboardErrorText; // Assign in Inspector

    private void Start()
    {
        DisplayAntennaText();
        DisplayRightCornerboardText();
        DisplayLeftCornerboardText();
    }

    private void DisplayErrorStatus(string errorKey, TextMeshProUGUI textMesh)
    {
        if (PersistentDataStore.errorStatuses.TryGetValue(errorKey, out var errorStatusData))
        {
            string message = $"{errorKey}: {errorStatusData.status}";
            Color color = GetStatusColor(errorStatusData.status);
            SetText(textMesh, message, color);
        }
        else
        {
            SetText(textMesh, $"{errorKey}: Status Unknown", Color.black);
        }
    }

    private Color GetStatusColor(ErrorStatus status)
    {
        switch (status)
        {
            case ErrorStatus.Corrected: return Color.green;
            case ErrorStatus.NotCorrected: return Color.red;
            case ErrorStatus.NotTested: return Color.gray;
            default: return Color.black;
        }
    }

    private void DisplayAntennaText()
    {
        DisplayErrorStatus("Antenna Error", antennaErrorText);
    }

    private void DisplayRightCornerboardText()
    {
        DisplayErrorStatus("Right Cornerboard Error", rightCornerboardErrorText);
    }

    private void DisplayLeftCornerboardText()
    {
        DisplayErrorStatus("Left Cornerboard Error", leftCornerboardErrorText);
    }

    private void SetText(string message, Color color)
    {
        antennaErrorText.text = message;
        antennaErrorText.color = color;
    }

    private void SetText(TextMeshProUGUI textComponent, string message, Color color)
    {
        textComponent.text = message;
        textComponent.color = color;
    }
}