using UnityEngine;

public class PlayerPrefsExample : MonoBehaviour
{ 
    // PlayerPrefs apenas armazena esses tipos de variaveis
    public int anInt;
    public float aFloat;
    public string aString;

    void Update()
    {
        // Salvar dados
        if(Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetInt("testInt", anInt);
            PlayerPrefs.SetFloat("testFloat", aFloat);
            PlayerPrefs.SetString("testString", aString);
        }
        
        // Carregar dados
        if(Input.GetKeyDown(KeyCode.L))
        {
            if(PlayerPrefs.HasKey("testInt"))
            {
                anInt = PlayerPrefs.GetInt("testInt");
                aFloat = PlayerPrefs.GetFloat("testFloat");
                aString = PlayerPrefs.GetString("testString");
            }
            else
            {
                Debug.LogError("Não encontramos a chave testInt");
            }
        }

        // Deletar dados
        if(Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
