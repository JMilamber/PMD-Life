using System.Runtime.CompilerServices;
using UnityEngine;

public class DungeonGridCell : DungeonGrid
{

    
    private int width;
    private int height;
    private int xPos;
    private int yPos;
    private Vector3Int topLeftPosition;
    private bool valid;

    private string[] room_tile_names;
    private int[] room_tile_ids;

    private DungeonRoom room;
    private DungeonGrid dungeonGrid;

    public DungeonGridCell(int sHeight, int sWidth, int sPosition, DungeonGrid parent_grid) {
        //length and width refer to the rows and collumns respectively of actual tiles that make up each dimension.
        //i.e with @End's basic 4x2 (4 collumns and 2 rows) each collumn is 14 tiles and each row is 16 tiles. 
        //one cell would therfore be 14 tiles in width by 16 tiles in height.
        
        this.width = sWidth;
        this.height = sHeight;

        
        this.xPos = Mathf.FloorToInt(sPosition/10);
        this.yPos = sPosition - (xPos * 10);

        this.topLeftPosition = new Vector3Int(Mathf.FloorToInt(this.getGridWidth() / this.width) * xPos - 28, Mathf.FloorToInt(this.getGridHeight() / this.height) * yPos - 16, 0);

        //every cell starts off as a valid cell.
        this.valid = true;
        this.room_tile_names = new string[this.width * this.height];
        this.room_tile_ids = new int[this.width * this.height];
    }

    public void SetValid(bool true_or_false) {
        this.valid = true_or_false;
    }

    public bool GetValid() {
        return this.valid;
    }

    public int GetWidth() {
        return this.width;
    }

    public int GetHeight() {
        return this.height;
    }

    public int GetPositionID() {
        return (this.xPos * 10) + this.yPos;
    }

    public Vector3Int GetPosition() {
        return this.topLeftPosition;
    }

    public void addTilesToDungeonGrid() {
        int startingPos = (this.width * this.height) * (this.xPos + this.yPos);
        for (int i = 0; i < this.width * this.height; i++) {
            dungeonGrid.addTileToGrid(startingPos + i, room_tile_names[i], room_tile_ids[i]);
        }
    }

    public void spawnRoom(int cell_height, int cell_width) {
        this.room = new DungeonRoom(this);
        this.room.GenerateRoom(this.GetPositionID());
        for (int i = 0; i < this.width * this.height; i++)
        {
            this.room_tile_names[i] = "wall";
            this.room_tile_ids[i] = 4;
        }
        
        int height_diff = this.height - this.room.getRoomHeight();
        int width_diff = this.width - this.room.getRoomWidth();
        int x = 1;
        int y = 1;
        // keeps track of how many room tile have been placed in each column. 
        int f = 1;
        
        for (int i = 0; i < this.width * this.height; i++) {
            if (x == width_diff / 2 - 1 || x == width - (width_diff / 2 - 1)) {
                if (y >= height_diff/ 2 -1 && y < height - (height_diff / 2 -1)) {
                    if (f == 0)
                    {
                        this.room_tile_names[i] = "wall";
                        this.room_tile_ids[i] = 0;

                    }
                }
                f++;
            }
            if (y == this.height) {
                y = 0;
                f = 0;
                x++;
                
            }
            else {
                y++;
            }
        }
    }
}
