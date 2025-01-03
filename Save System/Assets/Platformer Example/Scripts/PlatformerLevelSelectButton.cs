using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerLevelSelectButton : MonoBehaviour
{
    public string sceneToLoad;

    public bool isLocked;
    public GameObject lockedDisplay;
    public string levelToCheck;

    private void Start()
    {
        if(levelToCheck != "")
        {
            if(PlayerPrefs.HasKey(levelToCheck + "_complete"))
            {
                if(PlayerPrefs.GetString(levelToCheck + "_complete") == "true")
                {
                    isLocked = false;
                }
            }
        }
        
        lockedDisplay.SetActive(isLocked);
    }

    public void SelectLevel()
    {
        if (PlatformerLevelSelect.instance.levelLoading == false && isLocked == false)
        {
            PlatformerLevelSelect.instance.StartLevelLoad(sceneToLoad);
        }
    }
}
