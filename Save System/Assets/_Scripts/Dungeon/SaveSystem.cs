using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using JetBrains.Annotations;
public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    private void Awake()
    {
        SetupInstance();
    }

    public void SetupInstance()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public SaveData activeSave;
    public string sceneNotToSave;
    public string saveName;
    public bool dontSave;

    public void Save()
    {
#if UNITY_EDITOR
        if(!dontSave)
        {
#endif
            Debug.Log("Saving Data");

            string dataPath = Application.persistentDataPath;

            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + saveName + ".save", FileMode.Create);
            serializer.Serialize(stream, activeSave);
            stream.Close();
#if UNITY_EDITOR
        }
#endif
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if(File.Exists(dataPath + "/" + saveName + ".save"))
        {
            Debug.Log("Loading Data");

            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + saveName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();
        }
        else
        {
            Debug.LogWarning("Couldn't find data to load!");
        }
    }

    public void DestroySaveSystem()
    {
        instance = null;
        Destroy(gameObject);
    }
}
