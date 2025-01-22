using System.IO;
using Unity.Android.Gradle;
using UnityEngine;

public class ShowContinue : MonoBehaviour
{
    void Start()
    {
        string dataPath = Application.persistentDataPath;

        if(!File.Exists(dataPath + "/" + SaveSystem.instance.saveName + ".save"))
        gameObject.SetActive(false);
    }
}
