using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{ 
    public Vector3 getVectorFromAngle(float anAngle)
    {
        float tempAngleRad = anAngle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(tempAngleRad), Mathf.Sin(tempAngleRad));
    }

    private void Start()
    {
        Mesh myMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = myMesh;

        float myFov = 90f;
        Vector3 myOrigin = Vector3.zero;
        int myRayCount = 2;
        float myAngle = 0f;
        float myAngleIncrease = myFov / myRayCount;
        float myViewDistance = 4f;

        Vector3[] myVertices = new Vector3[myRayCount + 1 + 1];
        Vector2[] myUv = new Vector2[myVertices.Length];
        int[] myTriangles = new int[myRayCount * 3];

        myVertices[0] = myOrigin;

        int tempVertexIndex = 1;
        int tempTriangelIndex = 0;
        for (int i = 0; i <= myRayCount; i++)
        {
            Vector3 tempVertex = myOrigin + getVectorFromAngle(myAngle) * myViewDistance;
            myVertices[tempVertexIndex] = tempVertex;

            if (i > 0)
            {
                myTriangles[tempTriangelIndex + 0] = 0;
                myTriangles[tempTriangelIndex + 1] = tempVertexIndex - 1;
                myTriangles[tempTriangelIndex + 2] = tempVertexIndex;

                tempTriangelIndex += 3;
            }

            tempVertexIndex++;
            myAngle -= myAngleIncrease;
        }

        myTriangles[0] = 0;
        myTriangles[1] = 1;
        myTriangles[2] = 2;

        myMesh.vertices = myVertices;
        myMesh.uv = myUv;
        myMesh.triangles = myTriangles;
    }
}