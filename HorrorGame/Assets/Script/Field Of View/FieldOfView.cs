using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{ 
    private void Start()
    {
        Mesh myMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = myMesh;

        float myFov = 90f;
        Vector3 myOrigin = Vector3.zero;
        int myRayCount = 2;
        float myAngle = 0f;
        float myAngleIncrease = myFov / myRayCount;
        float viewDistance = 50f;

        Vector3[] myVertices = new Vector3[myRayCount + 1 + 1];
        Vector2[] myUv = new Vector2[myVertices.Length];
        int[] myTriangles = new int[myRayCount * 3];

        myVertices[0] = myOrigin;

        for (int i = 0; i <= myRayCount; i++)
        {

        }

        myTriangles[0] = 0;
        myTriangles[1] = 1;
        myTriangles[2] = 2;

        myMesh.vertices = myVertices;
        myMesh.uv = myUv;
        myMesh.triangles = myTriangles;
    }
}
