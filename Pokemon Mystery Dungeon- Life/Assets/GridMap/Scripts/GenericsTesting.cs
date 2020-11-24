using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GenericsTesting : MonoBehaviour
{

    [SerializeField] private HeatMapVisual heatMapVisual;
    [SerializeField] private HeatMapBoolVisual heatMapBoolVisual;

    private GridGeneric<HeatMapGridObject> bGrid;
    private Grid grid;

    // Start is called before the first frame update
    private void Start()
    {
        //grid = new Grid(20, 10, 8f, Vector3.zero);
        bGrid = new GridGeneric<HeatMapGridObject>(20, 10, 8f, Vector3.zero, (GridGeneric<HeatMapGridObject> g, int x, int y) => new HeatMapGridObject(g, x, y));
 
        //heatMapVisual.SetGrid(grid);
        //heatMapBoolVisual.SetGrid(bGrid);

        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            //grid.AddValue(position, 60, 2, 4);
            HeatMapGridObject heatMapGridObject = bGrid.GetGridObject(position);
            if (heatMapGridObject != null) {
                heatMapGridObject.AddValue(5);
            }

        }

    }
}

public class HeatMapGridObject {

    private const int MIN = 0;
    private const int MAX = 100;

    private GridGeneric<HeatMapGridObject> grid;
    private int x;
    private int y;
    private int value;

    public HeatMapGridObject(GridGeneric<HeatMapGridObject> grid, int x, int y) {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue(int addValue) {
        value += addValue;
        Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x, y);
    }

    public float GetValueNormalized() {
        return (float)value / MAX;
    }

    public override string ToString() {
        return value.ToString();
    }
}
