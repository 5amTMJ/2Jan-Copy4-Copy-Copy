using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For regular UI Text
using TMPro;
using System;

public class DisplayDateMinus15Months : MonoBehaviour
{
    // Reference to the UI Text or TextMeshPro component
    public TextMeshProUGUI uiText; // For Unity UI Text
    // public TextMeshProUGUI uiText; // Uncomment if using TextMeshPro

    void Start()
    {
        // Get the current date minus 15 months
        DateTime dateMinus15Months = DateTime.Now.AddMonths(-15);

        // Format the date (e.g., "02 Oct 2023")
        string formattedDate = dateMinus15Months.ToString("dd MMM yyyy");

        // Display the formatted date on the UI
        if (uiText != null)
        {
            uiText.text = formattedDate;
        }
        else
        {
            Debug.LogWarning("UI Text component is not assigned!");
        }
    }
}
