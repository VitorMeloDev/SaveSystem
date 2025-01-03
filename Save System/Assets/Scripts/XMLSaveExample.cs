using System.IO;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class XMLSaveExample : MonoBehaviour
{
    public string testString;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Salvar dados
        if(Input.GetKeyDown(KeyCode.S))
        {
           Save();
        }
        
        // Carregar dados
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

        // Deletar dados
        if(Input.GetKeyDown(KeyCode.C))
        {
            ClearSave();
        }

        // abrir diretorio
        if(Input.GetKeyDown(KeyCode.O))
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }
    }

    void Save()
    {
        Debug.Log("Saving data...");

        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(string));
        var stream = new FileStream(dataPath + "/testSave.save", FileMode.Create);
        serializer.Serialize(stream, testString);
        stream.Close();
    }

    void Load()
    {
        Debug.Log("Loading data...");

        string dataPath = Application.persistentDataPath;

        if(File.Exists(dataPath + "/testSave.save"))
        {
            var serializer = new XmlSerializer(typeof(string));
            var stream = new FileStream(dataPath + "/testSave.save", FileMode.Open);
            testString = serializer.Deserialize(stream) as string;
            stream.Close();
        }
    }

    void ClearSave()
    {
        Debug.Log("Deleted save file");

        File.Delete(Application.persistentDataPath + "/testSave.save");
    }
}
