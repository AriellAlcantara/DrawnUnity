using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Material material;
    private Mesh cubeMesh;
    private Matrix4x4 cubeMatrix;
    private Vector3 position = Vector3.zero;
    private Quaternion rotation = Quaternion.identity;
    private Vector3 scale = Vector3.one;
    public float moveSpeed = 2f;
    public float rotateSpeed = 50f;

    void Start()
    {
        CreateCubeMesh();
        cubeMatrix = Matrix4x4.TRS(position, rotation, scale);
    }

    void Update()
    {
        HandleInput();
        cubeMatrix = Matrix4x4.TRS(position, rotation, scale);
        Graphics.DrawMesh(cubeMesh, cubeMatrix, material, 0);
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rotation = Quaternion.Euler(-rotateSpeed * Time.deltaTime, 0, 0) * rotation;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rotation = Quaternion.Euler(rotateSpeed * Time.deltaTime, 0, 0) * rotation;
        }
    }

    void CreateCubeMesh()
    {
        cubeMesh = new Mesh();
        Vector3[] vertices = new Vector3[8]
        {
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f)
        };

        int[] triangles = new int[]
        {
            0, 2, 1, 0, 3, 2, 
            1, 6, 5, 1, 2, 6, 
            5, 7, 4, 5, 6, 7, 
            4, 3, 0, 4, 7, 3, 
            4, 1, 5, 4, 0, 1, 
            3, 6, 2, 3, 7, 6  
        };

        cubeMesh.vertices = vertices;
        cubeMesh.triangles = triangles;
        cubeMesh.RecalculateNormals();
    }
}
