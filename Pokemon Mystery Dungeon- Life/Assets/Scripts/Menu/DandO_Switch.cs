using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DandO_Switch : MonoBehaviour
{

    private int dungeon_Index = 0;
    private int over_World_Area_Index = 0;

    public void setDungeonID(int scene) {
        dungeon_Index = scene;
    }

    public void PlayDungeon() {
        PlayerPrefs.SetInt("dungeonId", dungeon_Index);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Dungeon");
    }

    public void startGame() {
        PlayerPrefs.SetInt("overworldId", over_World_Area_Index);
        PlayerPrefs.SetString("playerPokemon", "bulbasaur");
        PlayerPrefs.Save();
        SceneManager.LoadScene("OverWorld");
    }

    public void PlayOverWorld()
    {
        PlayerPrefs.SetInt("overworldId", over_World_Area_Index);
        try 
        {
            string pokemon_name = PlayerPrefs.GetString("playerPokemon");
        }
        catch (System.Exception)
        {
            PlayerPrefs.SetString("playerPokemon", "bulbasaur");
            PlayerPrefs.Save();
            throw;
        }
        SceneManager.LoadScene("OverWorld");
    }

    public void PlayTestDungeon() {
        SceneManager.LoadScene("Test Dungeon");
        PlayerPrefs.SetInt("dungeonId", -1);
        PlayerPrefs.Save();
    }
}
