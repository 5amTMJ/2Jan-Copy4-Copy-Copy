using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static AntennaAssessmentHandler;

public class EndAssessment : MonoBehaviour
{
    public Button exitAssessmentButton; // Assign in Inspector
    public string summarySceneName = "SummaryScene";

    private void Start()
    {
        if (exitAssessmentButton == null)
        {
            Debug.LogError("Exit Assessment Button is not assigned in the Inspector!");
            return;
        }

        exitAssessmentButton.onClick.AddListener(ExitAssessment);
    }

    public void ExitAssessment()
    {

        AntennaError();
        RightCornerboardError();
        LeftCornerboardError();

        // Load the summary scene
        SceneManager.LoadScene(summarySceneName);
    }

    private void AntennaError()
    {
        if (PersistentDataStore.errorStatuses.TryGetValue("Antenna Error", out var antennaErrorData))
        {
            Debug.Log($"Antenna Error Status: {antennaErrorData.status}");
        }
        else
        {
            Debug.LogError("Antenna Error key not found in PersistentDataStore!");
        }
    }

    private void RightCornerboardError()
    {
        if (PersistentDataStore.errorStatuses.TryGetValue("Right Cornerboard Error", out var rightCornerboardErrorData))
        {
            Debug.Log($"Right Cornerboard Error Status: {rightCornerboardErrorData.status}");
        }
        else
        {
            Debug.LogError("Right Cornerboard Error key not found in PersistentDataStore!");
        }
    }

    private void LeftCornerboardError()
    {
        if (PersistentDataStore.errorStatuses.TryGetValue("Left Cornerboard Error", out var leftCornerboardErrorData))
        {
            Debug.Log($"Left Cornerboard Error Status: {leftCornerboardErrorData.status}");
        }
        else
        {
            Debug.LogError("Left Cornerboard Error key not found in PersistentDataStore!");
        }
    }
}

