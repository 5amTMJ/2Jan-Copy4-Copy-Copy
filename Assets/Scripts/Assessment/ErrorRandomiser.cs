using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ErrorRandomiser : MonoBehaviour
{

    [Header("Antenna Check")]
    public GameObject antennaDeployed;
    public GameObject antennaUndeployed;

    [Header("Exposed Cable")]
    public GameObject exposedCableArea;

    [Header("Right Cornerboard Check")]
    public GameObject rightCornerboardDeployed;
    public GameObject rightCornerboardUndeployed;

    [Header("Left Cornerboard Check")]
    public GameObject leftCornerboardDeployed;
    public GameObject leftCornerboardUndeployed;

    [Header("Right Ladder Check")]
    public GameObject rightLadderUsable;
    public GameObject rightLadderCracked;

    [Header("Left Ladder Check")]
    public GameObject leftLadderUsable;
    public GameObject leftladderCracked;

    [Header("Fire Extinguisher Check")]
    public GameObject expiredFireExtinguisher;
    public GameObject validFireExtinguisher;

    [Header("Grounding Rod Check")]
    public GameObject invalidGroundingRod;
    public GameObject validGroundingRod;

    [Header("FOD Check")]
    public GameObject firstAidKit;
    public GameObject aluminiumCan;
    public GameObject wrench;
    public GameObject brokenBottle;
    public GameObject bucket;
    public GameObject lunchBox;
    public GameObject paperBox;
    public GameObject newspaper;
    public GameObject axe;
    public GameObject hammer;

    private void Start()
    {
        InitializeErrors();
    }

    

    private void InitializeErrors()
    {
        InitializeAntenna();
        InitializeExposedCable();
        InitializeRightCornerboard();
        InitializeLeftCornerboard();
        InitializeRightLadder();
        InitializeLeftLadder();
        InitializeFireExtinguisher();
        InitializeGroundingRod();
        InitializeFODs();
    }

    private void InitializeAntenna()
    {
        bool isErrorActive = Random.value > 0.5f;
        antennaUndeployed.SetActive(isErrorActive);
        antennaDeployed.SetActive(!isErrorActive);

        // Set initial error status
        if (!PersistentDataStore.errorStatuses.ContainsKey("Antenna Error"))
        {
            PersistentDataStore.errorStatuses["Antenna Error"] = new ErrorStatusData();
        }

        if (isErrorActive)
        {
            PersistentDataStore.errorStatuses["Antenna Error"].status = ErrorStatus.NotCorrected;
        }
        else
        {
            PersistentDataStore.errorStatuses["Antenna Error"].status = ErrorStatus.NotTested;
        }
    }


    private void InitializeExposedCable()
    {
        bool isErrorActive = Random.value > 0.5f;
        exposedCableArea.SetActive(isErrorActive);
    }

    private void InitializeRightCornerboard()
    {
        bool isErrorActive = Random.value > 0.5f;
        rightCornerboardUndeployed.SetActive(isErrorActive);
        rightCornerboardDeployed.SetActive(!isErrorActive);

        if (!PersistentDataStore.errorStatuses.ContainsKey("Right Cornerboard Error"))
        {
            PersistentDataStore.errorStatuses["Right Cornerboard Error"] = new ErrorStatusData();
        }

        PersistentDataStore.errorStatuses["Right Cornerboard Error"].status = isErrorActive
            ? ErrorStatus.NotCorrected
            : ErrorStatus.NotTested;
    }

    private void InitializeLeftCornerboard()
    {
        bool isErrorActive = Random.value > 0.5f;
        leftCornerboardUndeployed.SetActive(isErrorActive);
        leftCornerboardDeployed.SetActive(!isErrorActive);

        if (!PersistentDataStore.errorStatuses.ContainsKey("Left Cornerboard Error"))
        {
            PersistentDataStore.errorStatuses["Left Cornerboard Error"] = new ErrorStatusData();
        }

        PersistentDataStore.errorStatuses["Left Cornerboard Error"].status = isErrorActive
            ? ErrorStatus.NotCorrected
            : ErrorStatus.NotTested;
    }

    private void InitializeRightLadder()
    {
        bool isErrorActive = Random.value > 0.5f;
        rightLadderCracked.SetActive(isErrorActive);
        rightLadderUsable.SetActive(!isErrorActive);
    }

    private void InitializeLeftLadder()
    {
        bool isErrorActive = Random.value > 0.5f;
        leftladderCracked.SetActive(isErrorActive);
        leftLadderUsable.SetActive(!isErrorActive);
    }

    private void InitializeFireExtinguisher()
    {
        bool isErrorActive = Random.value > 0.5f;
        expiredFireExtinguisher.SetActive(isErrorActive);
        validFireExtinguisher.SetActive(!isErrorActive);
    }

    private void InitializeGroundingRod()
    {
        bool isErrorActive = Random.value > 0.5f;
        invalidGroundingRod.SetActive(isErrorActive);
        validGroundingRod.SetActive(!isErrorActive);
    }

    private void InitializeFODs()
    {
        List<GameObject> fodObjects = new List<GameObject>
        {
            firstAidKit, aluminiumCan, wrench, brokenBottle,
            bucket, lunchBox, paperBox, newspaper, axe, hammer
        };

        int activeFODCount = 0;

        foreach (var fod in fodObjects)
        {
            bool isActive = Random.value > 0.5f;
            fod.SetActive(isActive);
            if (isActive) activeFODCount++;
        }

        while (activeFODCount < 5)
        {
            foreach (var fod in fodObjects)
            {
                if (!fod.activeSelf && activeFODCount < 5)
                {
                    fod.SetActive(true);
                    activeFODCount++;
                }
            }
        }
    }
}
