using Unity.Mathematics;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public int RayCount;

    public float Radius;

    public GameObject Prefab;

    [SerializeField]
    private Vector2[] _directions;

    private GameObject[] _sides;

    private void Start()
    {
        float step = 360f / RayCount;
        _directions = new Vector2[RayCount];
        _sides = new GameObject[RayCount];

        for (int i = 0; i < RayCount; i++)
        {
            _directions[i] = Quaternion.AngleAxis(i * step, Vector3.forward) * Vector2.up;
            _sides[i] = Instantiate(Prefab);
            _sides[i].transform.SetParent(transform);
        }
    }
    private void Update()
    {
        for (int i = 0; i < RayCount; i++)
        {
            var hit = Physics2D.Raycast(transform.position, _directions[i], Radius, 1 << 6);
            if (hit.collider != null)
            {
                _sides[i].transform.position = hit.point;
            }
            else
            {
                _sides[i].transform.position = (Vector2)transform.position + _directions[i] * Radius;
            }
        }
    }
}
