using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class MazeTesting : MonoBehaviour
{
    // Start is called before the first frame update
    private Grid2 grid;
    private MazeCell mazeCell;

    private void Start()
    {

        mazeCell = new MazeCell(-1, -1, 1, 0);

        MazeCell horizontalHall1 = new MazeCell(2, 1, 1, 1);
        MazeCell horizontalHall2 = new MazeCell(3, 1, 1, 1);
        MazeCell horizontalHall3 = new MazeCell(4, 1, 1, 1);
        MazeCell horizontalHall4 = new MazeCell(5, 1, 1, 1);

        MazeCell verticalHall1 = new MazeCell(1, 2, 1, 2);
        MazeCell verticalHall2 = new MazeCell(1, 3, 1, 2);
        MazeCell verticalHall3 = new MazeCell(1, 4, 1, 2);
        MazeCell verticalHall4 = new MazeCell(1, 5, 1, 2);

        MazeCell horizontalHall11 = new MazeCell(2, 6, 1, 1);
        MazeCell horizontalHall12 = new MazeCell(3, 6, 1, 1);
        MazeCell horizontalHall13 = new MazeCell(4, 6, 1, 1);
        MazeCell horizontalHall14 = new MazeCell(5, 6, 1, 1);

        MazeCell verticalHall11 = new MazeCell(6, 2, 1, 2);
        MazeCell verticalHall12 = new MazeCell(6, 3, 1, 2);
        MazeCell verticalHall13 = new MazeCell(6, 4, 1, 2);
        MazeCell verticalHall14 = new MazeCell(6, 5, 1, 2);

        MazeCell bottomLeftCorner = new MazeCell(1, 1, 1, 3);
        MazeCell bottomRightCorner = new MazeCell(6, 1, 1, 4);
        MazeCell topLeftCorner = new MazeCell(1, 6, 1, 5);
        MazeCell topRightCorner = new MazeCell(6, 6, 1, 6);



    }
    
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 25);
        }

        if (Input.GetMouseButtonDown(1)) {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
        

    }
}
