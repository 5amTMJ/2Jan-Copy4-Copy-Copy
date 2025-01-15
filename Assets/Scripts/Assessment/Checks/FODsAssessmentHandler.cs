using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FODsAssessmentHandler : MonoBehaviour
{
    public GameObject firstAidKit, aluminiumCan, wrench, brokenBottle, bucket, lunchBox, paperBox, newspaper, axe, hammer;

    private List<GameObject> activeFODs = new List<GameObject>();

    private void Start()
    {
        InitializeFODs();
    }

    private void InitializeFODs()
    {
        GameObject[] fodObjects = new GameObject[] {
            firstAidKit, aluminiumCan, wrench, brokenBottle, bucket,
            lunchBox, paperBox, newspaper, axe, hammer
        };

        foreach (GameObject fod in fodObjects)
        {
            bool isErrorActive = Random.value > 0.5f;
            fod.SetActive(isErrorActive);

            if (isErrorActive)
            {
                activeFODs.Add(fod);
            }
        }

        if (!PersistentDataStore.errorStatuses.ContainsKey("FOD Error"))
        {
            PersistentDataStore.errorStatuses["FOD Error"] = new ErrorStatusData();
        }

        PersistentDataStore.errorStatuses["FOD Error"].status = ErrorStatus.NotCorrected;
    }

    public void InteractWithFOD(GameObject fod)
    {
        if (!activeFODs.Contains(fod))
        {
            return; // Do nothing if the FOD is not in the active list
        }

        fod.SetActive(false); // Toggle visibility off
        activeFODs.Remove(fod); // Remove it from the active list

        CheckFODsCompletion();
    }

    private void CheckFODsCompletion()
    {
        if (activeFODs.Count == 0)
        {
            // All FODs have been corrected
            PersistentDataStore.errorStatuses["FOD Error"].status = ErrorStatus.Corrected;
        }
    }
}
