using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MazeCell
{
    private int cellSize;
    private int x;
    private int y;
    private int type;


    public MazeCell(int x, int y, int cellSize, int type = 0) {
        this.cellSize = cellSize;
        this.x = x;
        this.y = y;
        this.type = type;

        Vector3 bottomLeft = new Vector3(x, y);
        Vector3 topLeft = new Vector3(x, y + 1);
        Vector3 topRight = new Vector3(x + 1, y + 1);
        Vector3 bottomRight = new Vector3(x + 1, y);

        switch (type) {
            case 1:
                // Horizontal Hallway
                Debug.DrawLine(bottomLeft, bottomRight, Color.white, 100f);
                Debug.DrawLine(topLeft, topRight, Color.white, 100f);
                break;
            case 2:
                // Vertical Hallway
                Debug.DrawLine(bottomLeft, topLeft, Color.white, 100f);
                Debug.DrawLine(bottomRight, topRight, Color.white, 100f);
                break;
            case 3:
                // Bottom Left Corner
                Debug.DrawLine(bottomLeft, bottomRight, Color.white, 100f);
                Debug.DrawLine(bottomLeft, topLeft, Color.white, 100f);
                break;
            case 4:
                // Bottom Right Corner
                Debug.DrawLine(bottomLeft, bottomRight, Color.white, 100f);
                Debug.DrawLine(bottomRight, topRight, Color.white, 100f);
                break;
            case 5:
                // Top Left Corner
                Debug.DrawLine(bottomLeft, topLeft, Color.white, 100f);
                Debug.DrawLine(topLeft, topRight, Color.white, 100f);
                break;
            case 6:
                // Top Right Corner
                Debug.DrawLine(topLeft, topRight, Color.white, 100f);
                Debug.DrawLine(bottomRight, topRight, Color.white, 100f);
                break;
            case 7:
                // Box without a top
                Debug.DrawLine(bottomLeft, bottomRight, Color.white, 100f);
                Debug.DrawLine(bottomLeft, topLeft, Color.white, 100f);
                Debug.DrawLine(bottomRight, topRight, Color.white, 100f);
                break;
            case 8:
                // Box without right side
                Debug.DrawLine(bottomLeft, bottomRight, Color.white, 100f);
                Debug.DrawLine(topLeft, topRight, Color.white, 100f);
                Debug.DrawLine(bottomLeft, topLeft, Color.white, 100f);
                break;
            case 9:
                // Box without bottom
                Debug.DrawLine(topLeft, topRight, Color.white, 100f);
                Debug.DrawLine(bottomLeft, topLeft, Color.white, 100f);
                Debug.DrawLine(bottomRight, topRight, Color.white, 100f);
                break;
            case 10:
                // Box without left side
                Debug.DrawLine(topLeft, topRight, Color.white, 100f);
                Debug.DrawLine(bottomRight, topRight, Color.white, 100f);
                Debug.DrawLine(bottomLeft, bottomRight, Color.white, 100f);
                break;
            case 11:
                // Top Line
                Debug.DrawLine(topLeft, topRight, Color.white, 100f);
                break;
            case 12:
                // Right Line
                Debug.DrawLine(bottomRight, topRight, Color.white, 100f);
                break;
            case 13:
                //Bottom Line
                Debug.DrawLine(bottomLeft, bottomRight, Color.white, 100f);
                break;
            case 14:
                // Left Line
                Debug.DrawLine(bottomLeft, topLeft, Color.white, 100f);
                break;
            default:
                // Box
                Debug.DrawLine(bottomLeft, bottomRight, Color.white, 100f);
                Debug.DrawLine(topLeft, topRight, Color.white, 100f);
                Debug.DrawLine(bottomLeft, topLeft, Color.white, 100f);
                Debug.DrawLine(bottomRight, topRight, Color.white, 100f);
                break; 
        }
        
        
    }
}
