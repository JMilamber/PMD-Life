using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class HeatMapTesting : MonoBehaviour {

    [SerializeField] private HeatMapVisual heatMapVisual;

    private Grid2 grid;

    // Start is called before the first frame update
    private void Start() {
        grid = new Grid2(100, 100, 4f, Vector3.zero);

        heatMapVisual.SetGrid(grid);

    }

    // Update is called once per frame
    private void Update() { 
        if (Input.GetMouseButtonDown(0)) {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            grid.AddValue(position, 60, 5, 20);
        }

    }
}
