using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistentDataStore
{
    public static Dictionary<string, ErrorStatusData> errorStatuses = new Dictionary<string, ErrorStatusData>();
}

public class ErrorStatusData
{
    public ErrorStatus status;
}

public enum ErrorStatus
{
    Corrected,
    NotCorrected,
    NotTested
}
