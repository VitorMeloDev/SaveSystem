using UnityEngine;

public class SaveSystemLoader : MonoBehaviour
{
    public SaveSystem systemToLoad;

    private void Awake() 
    {
        if(SaveSystem.instance == null)
        {
            Instantiate(systemToLoad).SetupInstance();
        }    
    }
}
