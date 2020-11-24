using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DungeonRoom : DungeonGrid {

    private DungeonGridCell cell_to_generate_in;
    private int room_width;
    private int room_height;
    private Vector3Int top_corner_position;
    private Vector2Int corner_top_left;
    private Vector2Int corner_top_right;
    private Vector2Int corner_bottom_right;
    private Vector2Int corner_bottom_left;



    public DungeonRoom(DungeonGridCell parent_cell) {
        this.cell_to_generate_in = parent_cell;
        int width_to_try = cell_to_generate_in.GetWidth() - 2;
        int height_to_try = cell_to_generate_in.GetHeight() - 2;

        if (width_to_try > 5) {
            this.room_width = Random.Range(5, width_to_try);
        } else {
            this.room_width = 5;
        }

        if (height_to_try > 4) {
            this.room_height = Random.Range(4, height_to_try);
        } else {
            this.room_height = 4;
        }

    }

    public DungeonRoom(DungeonGridCell parent_cell, int width, int height)
    {
        this.cell_to_generate_in = parent_cell;
        this.room_width = width;
        this.room_height = height;
    }

    public void GenerateRoom(int cellId) {
        Vector3Int position = cell_to_generate_in.GetPosition();
        int x1 = Random.Range(position.x + 2, position.x + cell_to_generate_in.GetWidth() - 2 - room_width);
        int x2 = x1 + room_width;
        int y1 = Random.Range(position.y - 2, position.y - cell_to_generate_in.GetHeight() + 2 + room_height);
        int y2 = y1 - room_height;
        this.corner_top_left = new Vector2Int(x1, y1);
        this.corner_top_right = new Vector2Int(x2, y1);
        this.corner_bottom_right = new Vector2Int(x2, y2);
        this.corner_bottom_left = new Vector2Int(x1, y2);

    }


    public int getRoomHeight() {
        return this.room_height;
    }
    public int getRoomWidth() {
        return this.room_width;
    }
}

