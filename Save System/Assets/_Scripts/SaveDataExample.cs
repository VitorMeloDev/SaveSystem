using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[System.Serializable]
public class SaveDataExample
{   
    public string text;
    public float number;
    public int wholeNumber;

    public List<Vector3> places;

    public enum InfoType {so, much, info};
    public InfoType typeOfInfo;

    public SubSave moreData;
}

[System.Serializable]
public class SubSave
{
    public string text;
    public bool isItTrue;
}
