using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    float myFov = 80f;
    Vector3 myOrigin;
    int myRayCount = 50;
    float myAngle = 0f;
    float myAngleIncrease;
    float myViewDistance = 8f;
    Vector3 myDirection;

    Vector3[] myVertices;
    Vector2[] myUv;
    int[] myTriangles;

    [SerializeField] private LayerMask myLayerMask;

    private Mesh myMesh;

    public Vector3 getVectorFromAngle(float anAngle)
    {
        float tempAngleRad = anAngle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(tempAngleRad), Mathf.Sin(tempAngleRad));
    }
   

    //public void Start()
    //{
    //    myMesh = new Mesh();
    //    GetComponent<MeshFilter>().mesh = myMesh;
    //    myAngleIncrease = myFov / myRayCount;

    //    myVertices = new Vector3[myRayCount + 1 + 1];
    //    myUv = new Vector2[myVertices.Length];
    //    myTriangles = new int[myRayCount * 3];

    //    myOrigin = Vector3.zero;
    //}

    private void Start()
    {
        myMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = myMesh;
        myAngleIncrease = myFov / myRayCount;

        myVertices = new Vector3[myRayCount + 1 + 1];
        myUv = new Vector2[myVertices.Length];
        myTriangles = new int[myRayCount * 3];

        myOrigin = Vector3.zero;

        myVertices[0] = myOrigin;

        int tempVertexIndex = 1;
        int tempTriangelIndex = 0;
        for (int i = 0; i < myRayCount; i++)
        {
            Vector3 tempVertex;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, getVectorFromAngle(myAngle), myViewDistance, myLayerMask);
            //Debug.Log(raycastHit2D.point);
            Debug.Log(getVectorFromAngle(myAngle));
            if (raycastHit2D.collider == null)
            {
                tempVertex = myOrigin + getVectorFromAngle(myAngle) * myViewDistance;
            }
            else
            {
                tempVertex = raycastHit2D.point;
            }
            //Debug.Log(tempVertex);
            //Debug.Log(raycastHit2D.point);

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