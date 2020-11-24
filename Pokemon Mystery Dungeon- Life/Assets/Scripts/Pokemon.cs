using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon 
{
    private int pokemon_number = 0;
    private string pokemon_name = "";
    private Vector2 position = new Vector2(0, 0);
    private GameObject pokemon_Object;

    public Pokemon (string name) {
        this.pokemon_name = name;
        this.pokemon_Object = new GameObject(pokemon_name);
    }
    
    public Pokemon (GameObject obj) {
        this.pokemon_Object = obj;
    }

    public void set_Pokemon_Number(int p_number) {
        this.pokemon_number = p_number;
    }

    public void set_Pokemon_Name(string p_name) {
        this.pokemon_name = p_name;
    }

    public void set_Position(Vector2 new_Position) {
        this.position = new_Position;
    }

    public int get_Pokemon_Number()
    {
        return this.pokemon_number;
    }

    public string get_Pokemon_Name()
    {
        return this.pokemon_name;
    }

    public Vector2 get_position()
    {
        return this.position;
    }
    
}
