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
    [SerializeField] private LayerMask myLayerMask;
    private Mesh myMesh;

    private void Start()
    {
        myMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = myMesh;
    }

    private void Update()
    {
        float myFov = 90f;
        Vector3 myOrigin = Vector3.zero;
        int myRayCount = 3;
        float myAngle = 0f;
        float myAngleIncrease = myFov / myRayCount;
        float myViewDistance = 8f;

        Vector3[] myVertices = new Vector3[myRayCount + 1 + 1];
        Vector2[] myUv = new Vector2[myVertices.Length];
        int[] myTriangles = new int[myRayCount * 3];

        myVertices[0] = myOrigin;

        int tempVertexIndex = 1;
        int tempTriangelIndex = 0;
        for (int i = 0; i <= myRayCount; i++)
        {
            Vector3 tempVertex;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(myOrigin, getVectorFromAngle(myAngle), myViewDistance, myLayerMask);
            //Debug.Log(raycastHit2D.point);

            if (raycastHit2D.collider == null)
            {
                Debug.Log("didnt hit anything");
                tempVertex = myOrigin + getVectorFromAngle(myAngle) * myViewDistance;
            }
            else
            {
                Debug.Log("hit something");
                tempVertex = raycastHit2D.point;
            }
            Debug.Log(raycastHit2D.point);

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

        myMesh.vertices = myVertices;
        myMesh.uv = myUv;
        myMesh.triangles = myTriangles;
    }
}