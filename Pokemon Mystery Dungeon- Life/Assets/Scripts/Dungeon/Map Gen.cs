using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MapGen 
{

    private string dungeon_name;
    private TilePaint tilePaint;


    private int[] column_Boundaries = new int[20];
    private int[] row_Boundaries = new int[20];

    private DungeonGrid dungeonGrid;
    private DungeonGridCell[] cells;
    

    private int size_Check;

    public MapGen() {
        switch (PlayerPrefs.GetInt("dungeonId"))
        {
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
        switch (dungeon_name) {
            case "Mossy Hollow":
                this.size_Check = 1;
                break;
            default:
                this.size_Check = 0;
                break;
                
        }
    }
    
    public void createDungeon() {
        dungeonGrid = new DungeonGrid();
        int x;
        int y;
        //the generator tries 10 tmes to create a valid dungeon then goes to a default preset
        for (int f = 0; f < 10; f++ ) {
            int floor_structure = UnityEngine.Random.Range(0, 16);
            int room_Density = UnityEngine.Random.Range(0, 3);
            switch (floor_structure) {
                default:
                    dungeonGrid.setCellColumns(6);
                    dungeonGrid.setCellRows(4);
                    dungeonGrid.calcTotalCells();
                    //extra parmeters for creating the cells in the grid.
                    // i references the x position (0,1,2,3,4 etc)
                    int i = 0;
                    // j references the y position (0,1,2,3,4 etc)
                    int j = 0;
                    //together hey form position statements such as (01,02,11,12,21,22)
                    column_Boundaries[0] = 10;
                    column_Boundaries[1] = 19;
                    column_Boundaries[2] = 28;
                    column_Boundaries[3] = 37;
                    column_Boundaries[4] = 46;
                    column_Boundaries[5] = 55;
                    row_Boundaries[0] = 8;
                    row_Boundaries[1] = 16;
                    row_Boundaries[2] = 24;
                    row_Boundaries[3] = 32;
                    cells = new DungeonGridCell[dungeonGrid.getTotalCells()];
                    for (x = 0; x < dungeonGrid.getTotalCells(); x++) {
                        cells[x] = new DungeonGridCell(dungeonGrid.getGridHeight()/dungeonGrid.getCellRows(), dungeonGrid.getGridWidth()/dungeonGrid.getCellColumns(), i + j, dungeonGrid);
                        
                        if (i == dungeonGrid.getCellRows()) {
                            i = 0;
                            j += 10;
                        } else {
                            i++;
                        }
                    }
                    if (size_Check == 1) {
                        for (x = Mathf.FloorToInt(dungeonGrid.getCellColumns() / 2); x < dungeonGrid.getCellColumns(); x++) {
                            cells[x].SetValid(false);
                        }
                    }
                    break;
            }
        }

        // x starts at 0,0 for this placement, which is -28 , 16
        x = -(dungeonGrid.getGridWidth() / 2);
        y = dungeonGrid.getGridHeight() / 2;

        for (int i = 0; i < dungeonGrid.getTotalCells(); i++) {
            tilePaint.placeNewTile(new Vector3Int(x, y, 0), dungeonGrid.tile_names[i], dungeonGrid.tile_ids[i]);
            switch (y) {
                case -15:
                    y = 16;
                    x++;
                    break;

                default:
                    y--;
                    break;
            }
            
          
        }
     }

     

}
