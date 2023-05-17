using System.Linq;
using UnityEngine;

public class Cave : MonoBehaviour
{
    [SerializeField]
    private MeshFilter _meshFilter;

    [SerializeField]
    private PolygonCollider2D _collider;

    private Mesh _mesh;
    private void Start()
    {
        _mesh = new Mesh();
        _mesh.name = "Cave";

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector2(-5,-5);
        vertices[1] = new Vector2(-5,5);
        vertices[2] = new Vector2(5,5);
        vertices[3] = new Vector2(5,-5);
        _mesh.vertices = vertices;

        int[] triangles = new int[6];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;
        _mesh.triangles = triangles;

        _meshFilter.mesh = _mesh;
        _collider.points = vertices.Select(v=>new Vector2(v.x,v.y)).ToArray();
    }
    private void Update()
    {
        
    }
}
