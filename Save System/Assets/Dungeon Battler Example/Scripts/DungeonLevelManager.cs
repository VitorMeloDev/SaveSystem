using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonLevelManager : MonoBehaviour
{
    public static DungeonLevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    public string nextLevel;

    private bool isEnding;

    public void LeaveLevel()
    {
        if (isEnding == false)
        {
            isEnding = true;
            StartCoroutine(LeaveLevelCo());
        }
    }

    IEnumerator LeaveLevelCo()
    {
        DungeonUIController.instance.StartFadeToBlack();

        if(nextLevel != SaveSystem.instance.sceneNotToSave)
        {
            UpdateSaveSystem();
            SaveSystem.instance.Save();
        }
    
        yield return new WaitForSeconds(.5f);

        if (nextLevel != "")
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void UpdateSaveSystem()
    {
        DungeonPlayerStats stats = DungeonPlayerStats.instance;

        SaveSystem.instance.activeSave.strenght = stats.strength;
        SaveSystem.instance.activeSave.defense = stats.defence;
        SaveSystem.instance.activeSave.level = stats.level;
        SaveSystem.instance.activeSave.currentExp = stats.currentXP;
        SaveSystem.instance.activeSave.expToLevel = stats.xpToLevel;
        SaveSystem.instance.activeSave.maxHP = stats.maxHP;

        SaveSystem.instance.activeSave.currentHP = DungeonPlayer.instance.currentHealth;
        SaveSystem.instance.activeSave.currentLevel = nextLevel;
    }
}
