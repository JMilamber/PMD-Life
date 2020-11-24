using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TilePaint : MonoBehaviour
{
    public GameObject groundObject;
    public GameObject wallObject;
    public Tilemap groundMap;
    public Tilemap wallMap;
    public Grid grid;
    public TileBase[] tiles;

    private Vector3Int old_place;
    private Vector3Int place = new Vector3Int(0, 0, 0);

    private TileBase tile;

    private const int default_place = 1;

    private TileBase default_tile;

    private TileBase[] walls_hold;
    private TileBase[] wall_alt_hold;
    private TileBase[] ground_hold;
    private TileBase[] ground_alt_hold;
    private TileBase[] water_hold;
    private TileBase[] water_sparkles_hold;

    private TileBase[] walls_final;
    private TileBase[] walls_alt_final;
    private TileBase[] ground_final;
    private TileBase[] ground_alt_final;
    private TileBase[] water_final;
    private TileBase[] water_sparkles_final;


    private List<TileBase[]> walls = new List<TileBase[]>();
    private List<TileBase[]> ground = new List<TileBase[]>();
    private List<TileBase[]> water = new List<TileBase[]>();


    private string dungeon_name = "";
    private Boolean tiles_loaded = false;

    private MapGen dungeon;

    private int test_Id = 1;


    // Start is called before the first frame update
    void Start()
    {

        walls_hold = new TileBase[75];
        wall_alt_hold = new TileBase[18];
        ground_hold = new TileBase[75];
        ground_alt_hold = new TileBase[18];
        water_hold = new TileBase[75];
        water_sparkles_hold = new TileBase[75];
        tiles = new TileBase[950];

        walls_final = new TileBase[75];
        walls_alt_final = new TileBase[2];
        ground_final = new TileBase[75];
        ground_alt_final = new TileBase[2];
        water_final = new TileBase[75];
        water_sparkles_final = new TileBase[75];

        walls.Add(walls_hold);
        walls.Add(wall_alt_hold);
        ground.Add(ground_hold);
        ground.Add(ground_alt_hold);
        water.Add(water_hold);
        water.Add(water_sparkles_hold);

        int tile_Sheet_Width;
        int tile_Sheet_Height = 30;
        int tile_Areas;

        switch(PlayerPrefs.GetInt("dungeonId")) {
            case 0:
                dungeon_name = "Ragged Mountain";
                break;
            case 1:
                dungeon_name = "Mossy Hollow";
                break;
            default:
                dungeon_name = "Mossy Hollow";
                break;
        }

        dungeon = new MapGen();

        string dungeon_tile_name;

        switch(dungeon_name) {
            case "Mossy Hollow":
                dungeon_tile_name = "Mossy_Hollow_Tiles_";
                break;
            default:
                dungeon_tile_name = "Mossy_Hollow_Tiles_";
                break;
        }

        //counts which tile from entire list
        int f = 0;

        //counts tiles added to tiles[] array
        int d = 0;
        //Debug.Log(dungeon_tile_name);

        int l = 0;
        // int to count number of wall tiles added
        int walls_add = 0;

        // int to count number of wall alt tiles added
        int wall_alt_add = 0;

        // int to count ground tiles added
        int ground_add = 0;

        //int to count ground alt tiles added
        int ground_alt_add = 0;

        // int to count water tiles added
        int water_add = 0;

        //int to count water sparkle tiles added
        int water_sparkles_add = 0;

        // loads, sorts, and filters all resource tiles for the dungeon
        foreach (TileBase x in tiles) {
            tiles[f] = null;
            f++;
        }
        f = 0;
        if (tiles_loaded == false && dungeon_name.Length > 1) {
            

            //loading and sorting
            foreach (TileBase x in Resources.LoadAll("Tiles/" + dungeon_name)) { 
                if (f > 227) {
                    //Debug.Log(f);
                    tiles[d] = Resources.Load<TileBase>("Tiles/" + dungeon_name + "/" + dungeon_tile_name + f);
                    d++;
                }
                f++;
            }

            default_tile = tiles[1];
            tile_Sheet_Width = f / tile_Sheet_Height;
            //Debug.Log(tile_Sheet_Width.ToString());
            tile_Areas = (tile_Sheet_Width - 11) / 3;
            //Debug.Log(tile_Areas.ToString());


            // f will now be used to count each tile section (Legend, wall, wall alt.1, Ground, etc)
            f = 0;

            // d will now be used to count rows
            d = 0;


           

            switch (tile_Areas)
            {
                default:
                    foreach (TileBase x in tiles)
                    {
                        if (x == null) {
                            break;
                        }
                        // increments f every 3 tiles, which allows me to identify what type of tile it is.
                        if ((d == 0 || d % 3 == 0) && d < 27)
                        {
                            f++;
                        }
                        // Debug.Log("f" + f.ToString());
                        // need to tell this to change based on how many tile areas there are. 
                        switch (f)
                        {
                            // if f is one then it is on the legend for the tilesheet which we dont need to save
                            case 2:
                                walls_hold[walls_add] = x;
                                walls_add++;
                                break;

                            case 3:
                                if (wall_alt_add < 18) {
                                    wall_alt_hold[wall_alt_add] = x;
                                    wall_alt_add++;
                                }
                                
                                break;
                            case 4:
                                if (wall_alt_add < 18)
                                {
                                    wall_alt_hold[wall_alt_add] = x;
                                    wall_alt_add++;
                                }
                                break;
                            case 5:
                                ground_hold[ground_add] = x;
                                ground_add++;
                                break;
                            case 6:
                                if (ground_alt_add < 18) {
                                    ground_alt_hold[ground_alt_add] = x;
                                    ground_alt_add++;
                                }
                                break;
                            case 7:
                                if (ground_alt_add < 18)
                                {
                                    ground_alt_hold[ground_alt_add] = x;
                                    ground_alt_add++;
                                }
                                break;
                            case 8:
                                water_hold[water_add] = x;
                                water_add++;
                                break;
                            case 9:
                                water_sparkles_hold[water_sparkles_add] = x;
                                water_sparkles_add++;
                                break;
                            default:
                                break;
                        }

                        //Debug.Log("d" + d.ToString());
                        
                        d++;
                        switch (d)
                        {
                            case 27:
                                f = 0;
                                break;
                            case 38:
                                d = 0;
                                break;
                            default:
                                break;
                        }
                        
                        l++;

                    }
                    //Debug.Log("total tiles =" + l.ToString());
                    break;
            }

            tiles = null;
            walls_add = 0;
            wall_alt_add = 0;
            ground_add = 0;
            ground_alt_add = 0;
            water_add = 0;
            water_sparkles_add = 0;

            // f is now used to count the tiles in each tilebase[]
            f = 1;

            //d is now used to count each tilebase[]
            d = 1;
            // filtering and more sorting
            foreach(TileBase[] x in walls) {
                switch (d)
                {
                    case 1:
                        foreach (TileBase y in x)
                        {
                            switch (f)
                            {
                                case 15:
                                    f++;
                                    break;
                                case 17:
                                    f++;
                                    break;
                                case 19:
                                    f++;
                                    break;
                                case 21:
                                    f++;
                                    break;
                                case 25:
                                    f++;
                                    break;
                                case 27:
                                    f++;
                                    break;
                                case 28:
                                    f++;
                                    break;
                                case 30:
                                    f++;
                                    break;
                                case 32:
                                    f++;
                                    break;
                                case 34:
                                    f++;
                                    break;
                                case 36:
                                    f++;
                                    break;
                                case 37:
                                    f++;
                                    break;
                                case 39:
                                    f++;
                                    break;
                                case 41:
                                    f++;
                                    break;
                                case 43:
                                    f++;
                                    break;
                                case 45:
                                    f++;
                                    break;
                                case 48:
                                    f++;
                                    break;
                                case 51:
                                    f++;
                                    break;
                                case 54:
                                    f++;
                                    break;
                                case 57:
                                    f++;
                                    break;
                                case 60:
                                    f++;
                                    break;
                                case 63:
                                    f++;
                                    break;
                                case 66:
                                    f++;
                                    break;
                                case 69:
                                    f++;
                                    break;
                                case 72:
                                    f++;
                                    break;
                                default:
                                    walls_final[walls_add] = y;
                                    walls_add++;
                                    f++;
                                    break;
                            }
                        }
                        f = 1;
                        d++;
                        break;
                    case 2:
                        foreach (TileBase y in x) {
                            switch (f) {
                                case 8:
                                    walls_alt_final[wall_alt_add] = y;
                                    wall_alt_add++;
                                    f++;
                                    break;
                                case 11:
                                    walls_alt_final[wall_alt_add] = y;
                                    wall_alt_add++;
                                    f++;
                                    break;
                                default:
                                    f++;
                                    break;
                            }
                        }
                        break;
                    default:
                        d = 0;
                        break;
                }
                
            }
            d = 1;
            f = 1;
            foreach (TileBase[] x in ground)
            {
                switch (d)
                {
                    case 1:
                        foreach (TileBase y in x)
                        {
                            switch (f)
                            {
                                case 15:
                                    f++;
                                    break;
                                case 17:
                                    f++;
                                    break;
                                case 19:
                                    f++;
                                    break;
                                case 21:
                                    f++;
                                    break;
                                case 25:
                                    f++;
                                    break;
                                case 27:
                                    f++;
                                    break;
                                case 28:
                                    f++;
                                    break;
                                case 30:
                                    f++;
                                    break;
                                case 32:
                                    f++;
                                    break;
                                case 34:
                                    f++;
                                    break;
                                case 36:
                                    f++;
                                    break;
                                case 37:
                                    f++;
                                    break;
                                case 39:
                                    f++;
                                    break;
                                case 41:
                                    f++;
                                    break;
                                case 43:
                                    f++;
                                    break;
                                case 45:
                                    f++;
                                    break;
                                case 48:
                                    f++;
                                    break;
                                case 51:
                                    f++;
                                    break;
                                case 54:
                                    f++;
                                    break;
                                case 57:
                                    f++;
                                    break;
                                case 60:
                                    f++;
                                    break;
                                case 63:
                                    f++;
                                    break;
                                case 66:
                                    f++;
                                    break;
                                case 69:
                                    f++;
                                    break;
                                case 72:
                                    f++;
                                    break;
                                default:
                                    ground_final[ground_add] = y;
                                    ground_add++;
                                    f++;
                                    break;
                            }
                        }
                        f = 1;
                        d++;
                        break;
                    case 2:
                        foreach (TileBase y in x)
                        {
                            switch (f)
                            {
                                case 8:
                                    ground_alt_final[ground_alt_add] = y;
                                    ground_alt_add++;
                                    f++;
                                    break;
                                case 11:
                                    ground_alt_final[ground_alt_add] = y;
                                    ground_alt_add++;
                                    f++;
                                    break;
                                default:
                                    f++;
                                    break;
                            }
                        }
                        break;
                    default:
                        d = 0;
                        break;
                }

            }
            f = 1;
            d = 1;
            foreach (TileBase[] x in water)
            {
                switch (d) {
                    case 1:
                        foreach (TileBase y in x)
                        {
                            switch (f)
                            {
                                case 15:
                                    f++;
                                    break;
                                case 17:
                                    f++;
                                    break;
                                case 19:
                                    f++;
                                    break;
                                case 21:
                                    f++;
                                    break;
                                case 25:
                                    f++;
                                    break;
                                case 27:
                                    f++;
                                    break;
                                case 28:
                                    f++;
                                    break;
                                case 30:
                                    f++;
                                    break;
                                case 32:
                                    f++;
                                    break;
                                case 34:
                                    f++;
                                    break;
                                case 36:
                                    f++;
                                    break;
                                case 37:
                                    f++;
                                    break;
                                case 39:
                                    f++;
                                    break;
                                case 41:
                                    f++;
                                    break;
                                case 43:
                                    f++;
                                    break;
                                case 45:
                                    f++;
                                    break;
                                case 48:
                                    f++;
                                    break;
                                case 51:
                                    f++;
                                    break;
                                case 54:
                                    f++;
                                    break;
                                case 57:
                                    f++;
                                    break;
                                case 60:
                                    f++;
                                    break;
                                case 63:
                                    f++;
                                    break;
                                case 66:
                                    f++;
                                    break;
                                case 69:
                                    f++;
                                    break;
                                case 72:
                                    f++;
                                    break;
                                default:
                                    water_final[water_add] = y;
                                    water_add++;
                                    f++;
                                    break;
                            }
                        }
                        d++;
                        f = 1;
                        break;
                    case 2:
                        foreach (TileBase y in x)
                        {
                            switch (f)
                            {
                                case 15:
                                    f++;
                                    break;
                                case 17:
                                    f++;
                                    break;
                                case 19:
                                    f++;
                                    break;
                                case 21:
                                    f++;
                                    break;
                                case 25:
                                    f++;
                                    break;
                                case 27:
                                    f++;
                                    break;
                                case 28:
                                    f++;
                                    break;
                                case 30:
                                    f++;
                                    break;
                                case 32:
                                    f++;
                                    break;
                                case 34:
                                    f++;
                                    break;
                                case 36:
                                    f++;
                                    break;
                                case 37:
                                    f++;
                                    break;
                                case 39:
                                    f++;
                                    break;
                                case 41:
                                    f++;
                                    break;
                                case 43:
                                    f++;
                                    break;
                                case 45:
                                    f++;
                                    break;
                                case 48:
                                    f++;
                                    break;
                                case 51:
                                    f++;
                                    break;
                                case 54:
                                    f++;
                                    break;
                                case 57:
                                    f++;
                                    break;
                                case 60:
                                    f++;
                                    break;
                                case 63:
                                    f++;
                                    break;
                                case 66:
                                    f++;
                                    break;
                                case 69:
                                    f++;
                                    break;
                                case 72:
                                    f++;
                                    break;
                                default:
                                    water_sparkles_final[water_sparkles_add] = y;
                                    water_sparkles_add++;
                                    f++;
                                    break;
                            }
                        }
                        f = 1;
                        d = 0;
                        break;
                    default:
                        break;       
                }
            }
            tiles_loaded = true;
        }
        walls_hold = null;
        wall_alt_hold = null;
        ground_hold = null;
        ground_alt_hold = null;
        water_hold = null;
        water_sparkles_hold = null;
       
        //dungeon.createDungeon();
        //Debug.Log(tiles[3].ToString());
        Debug.Log("placing tiles");

        if (SceneManager.GetActiveScene().name == "Test Dungeon") {
            testTilePlace();
        }

        wallObject.AddComponent<TilemapCollider2D>();
        wallObject.AddComponent<CompositeCollider2D>();
        wallObject.GetComponent<TilemapCollider2D>().usedByComposite = true;
        wallObject.GetComponent<CompositeCollider2D>().geometryType = CompositeCollider2D.GeometryType.Polygons;

    } 

    public void placeNewWallTile(Vector3Int new_Place, int tile_number) {
        place = new_Place;
        tile = walls_final[tile_number];
        wallMap.SetTile(place, tile);
        old_place = place;
    }
    public void placeNewWallAltTile(Vector3Int new_Place, int tile_number)
    {
        place = new_Place;
        tile = walls_alt_final[tile_number];
        wallMap.SetTile(place, tile);
        old_place = place;
    }
    public void placeNewGroundTile(Vector3Int new_Place, int tile_number)
    {
        place = new_Place;
        tile = ground_final[tile_number];
        groundMap.SetTile(place, tile);
        old_place = place;
    }
    public void placeNewGroundAltTile(Vector3Int new_Place, int tile_number)
    {
        place = new_Place;
        tile = ground_alt_final[tile_number];
        groundMap.SetTile(place, tile);
        old_place = place;
    }
    public void placeNewWaterTile(Vector3Int new_Place, int tile_number)
    {
        place = new_Place;
        tile = water_final[tile_number];
        wallMap.SetTile(place, tile);
        old_place = place;
    }
    public void placeNewWaterSparklesTile(Vector3Int new_Place, int tile_number)
    {
        place = new_Place;
        tile = water_sparkles_final[tile_number];
        wallMap.SetTile(place, tile);
        old_place = place;
    }

    public void placeDefaultTile(Vector3Int new_Place) {
        place = new_Place;
        tile = default_tile;
        groundMap.SetTile(place, tile);
        old_place = place;
    }

    public void placeNewTile(Vector3Int new_place, string tile_Type, int tile_number) {
        if (tile_number > 174) {
            int difference = tile_number - 174;
            tile_number = tile_number - difference;
        }
        if (tile_number == 0) {

        }
        switch (tile_Type) {
            case "wall":
                placeNewWallTile(new_place, tile_number);
                break;
            case "wallAlt":
                switch(tile_number % 2) {
                    case 1:
                        placeNewWallAltTile(new_place, 1);
                        break;
                    default:
                        placeNewWallAltTile(new_place, 0);
                        break;
                }
                break;
            case "ground":
                placeNewGroundTile(new_place, tile_number);
                break;
            case "groundAlt":
                switch (tile_number % 2)
                {
                    case 1:
                        placeNewGroundAltTile(new_place, 1);
                        break;
                    default:
                        placeNewGroundAltTile(new_place, 0);
                        break;
                }
                break;
            case "water":
                placeNewWaterTile(new_place, tile_number);
                break;
            case "waterSparkles":
                placeNewWaterSparklesTile(new_place, tile_number);
                break;
            default:
                placeDefaultTile(new_place);
                break;
        }
    }
    
    public void setDungeonName(string new_dungeon_name)
    {
        dungeon_name = new_dungeon_name;
    }

    public string getDungeonName() {
        return dungeon_name;
    }

    public void testTilePlace() {
        old_place = place;
        string[] names = new string[6] { "wall", "wallAlt", "ground", "groundAlt", "water", "waterSparkles" };
        int x = -1;
        int z = 0;
        int tile_Number = 0;
        int y_max = 0;
        foreach(string name in names) {
            switch(name) {
                case "wallAlt":
                    y_max = -2;
                    break;
                case "groundAlt":
                    y_max = -2;
                    break;
                default:
                    y_max = -22;
                    break;
            }
            for (int y = 1; y > y_max; y--) {
                placeNewTile(new Vector3Int(x, y, z), name, tile_Number * 3);
                placeNewTile(new Vector3Int(x + 1, y , z), name, tile_Number * 3 + 1);
                placeNewTile(new Vector3Int(x + 2, y, z), name, tile_Number * 3 + 2);
                tile_Number++;
            }
            tile_Number = 0;
            x += 3;
        }
                 
    }

}
