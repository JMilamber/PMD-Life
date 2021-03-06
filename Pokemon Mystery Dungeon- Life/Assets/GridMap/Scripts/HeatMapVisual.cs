﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HeatMapVisual : MonoBehaviour
{

    private Grid2 grid;
    private Mesh mesh;
    private Boolean updateMesh;

    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }
    public void SetGrid(Grid2 grid) {
        this.grid = grid;
        updateHeatMapVisual();

        grid.OnGridValueChanged += Grid_OnGridValueChanged;
    } 

    private void Grid_OnGridValueChanged(object sender, Grid2.OnGridValueChangedEventArgs e) {
        //updateHeatMapVisual();
        updateMesh = true;
    }

    private void LateUpdate() {
        if (updateMesh) {
            updateMesh = false;
            updateHeatMapVisual();
        }
    }

    private void updateHeatMapVisual() {
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);
    
        for (int x = 0; x < grid.GetWidth(); x++) {
            for (int y = 0; y < grid.GetHeight(); y++) {
                int index = x * grid.GetHeight() + y;
                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize();


                int gridValue = grid.GetValue(x, y);
                float gridValueNormalized = (float)gridValue / Grid2.HEAT_MAP_MAX_VALUE;

                Vector2 gridValueUV = new Vector2(gridValueNormalized, 0f);
                MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y) + quadSize *.5f, 0f, quadSize, gridValueUV, gridValueUV);
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
}
