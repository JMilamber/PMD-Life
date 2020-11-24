using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTesting : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start() {
        CreateTileMesh();
    }

    private void CreateTileMesh() {
        Mesh mesh = new Mesh();

        int width = 4;
        int height = 4;
        float tilesize = 10;

        Vector3[] vertices = new Vector3[4 * (width * height)];
        Vector2[] uv = new Vector2[4 * (width * height)];
        int[] triangles = new int[6 * (width * height)];

        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                int index = i * 4 + j;
                

                vertices[index * 4 + 0] = new Vector3(tilesize * i,       tilesize * j);
                vertices[index * 4 + 1] = new Vector3(tilesize * i,       tilesize * (j + 1));
                vertices[index * 4 + 2] = new Vector3(tilesize * (i + 1), tilesize * (j + 1));
                vertices[index * 4 + 3] = new Vector3(tilesize * (i + 1), tilesize * j);

                uv[index * 4 + 0] = new Vector2(0, 0);
                uv[index * 4 + 1] = new Vector2(0, 1);
                uv[index * 4 + 2] = new Vector2(1, 1);
                uv[index * 4 + 3] = new Vector2(1, 0);

                triangles[index * 6 + 0] = index * 4 + 0;
                triangles[index * 6 + 1] = index * 4 + 1;
                triangles[index * 6 + 2] = index * 4 + 2;

                triangles[index * 6 + 3] = index * 4 + 0;
                triangles[index * 6 + 4] = index * 4 + 2;
                triangles[index * 6 + 5] = index * 4 + 3;


                mesh.vertices = vertices;
                mesh.uv = uv;
                mesh.triangles = triangles;

                GetComponent<MeshFilter>().mesh = mesh;
            }
        }
        
    }
}
