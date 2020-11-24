using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGrid 
{
    private int grid_width;
    private int grid_height;
    private int total_tiles;
    private int tile_rows;
    private int tile_columns;
    private int total_cells;
    private int cell_rows;
    private int cell_columns;
   

    public string[] tile_names;
    public int[] tile_ids;
    
    

   public DungeonGrid() {
        this.grid_width = 56;
        this.grid_height = 32;
        this.total_tiles = this.grid_height * this.grid_width;
        this.tile_names = new string[total_tiles];
        this.tile_ids = new int[total_tiles];
        this.tile_rows = this.grid_height;
        this.tile_columns = this.grid_width;
        
    }

    public int getGridWidth() {
        return grid_width;
    }

    public int getGridHeight() {
        return grid_height;
    }

    public void setCellRows(int rows) {
        cell_rows = rows;
    }

    public int getCellRows() {
        return cell_rows;
    }

    public void setCellColumns(int columns)
    {
        cell_columns = columns;
    }

    public int getCellColumns()
    {
        return cell_columns;
    }

    public void calcTotalCells() {
        total_cells = cell_rows * cell_columns;
    }

    public int getTotalCells() {
        return total_cells;
    }

    public void addTileToGrid(int id, string tile_name, int tile_id) {
        tile_names[id] = tile_name;
        tile_ids[id] = tile_id;
    }
    
}
