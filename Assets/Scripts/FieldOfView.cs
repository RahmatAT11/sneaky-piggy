using UnityEngine;
using Controllers.Player;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Mesh _mesh;
    private Vector3 _origin;
    [SerializeField] private float startingAngle;
    [SerializeField] private float fieldOfView;
    [SerializeField] private float viewDistance;
    [SerializeField] private int rayCount;

    private PlayerController _detectedPlayer;
    public PlayerController DetectedPlayer
    {
        get
        {
            return _detectedPlayer;
        }
    }
    private void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
    }

    private void LateUpdate()
    {
        int rayCount = this.rayCount;
        float angle = startingAngle;
        float angleIncrease = fieldOfView / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = _origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            
            RaycastHit2D raycastHit2D = 
                Physics2D.Raycast(_origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            Collider2D hitCollider = raycastHit2D.collider;
            if (hitCollider == null)
            {
                // No hit
                vertex = _origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                // hit
                vertex = raycastHit2D.point;
                _detectedPlayer = 
                    hitCollider.gameObject.CompareTag("Player") ? hitCollider.GetComponent<PlayerController>() : null;
                Debug.Log($"Is player null? {_detectedPlayer == null}");
            }
            
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        _mesh.vertices = vertices;
        _mesh.uv = uv;
        _mesh.triangles = triangles;
    }

    public void SetOrigin(Vector3 origin)
    {
        _origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) + fieldOfView / 2f;
    }

    public void SetFov(float fov)
    {
        fieldOfView = fov;
    }

    public void SetViewDistance(float viewDis)
    {
        this.viewDistance = viewDis;
    }
    
    private Vector3 GetVectorFromAngle(float angle)
    {
        // note : angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }

        return n;
    }
}
