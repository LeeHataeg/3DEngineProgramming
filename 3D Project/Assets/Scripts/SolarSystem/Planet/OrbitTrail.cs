using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitTrail : MonoBehaviour
{
    public int maxPositions = 1000;
    public float positionUpdateInterval = 0.1f;

    private LineRenderer lineRenderer;
    private List<Vector3> positions = new List<Vector3>();
    private float timeSinceLastUpdate = 0f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;

        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.useWorldSpace = true;

        // 첫 위치 등록
        positions.Add(transform.position);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= positionUpdateInterval)
        {
            Vector3 currentPos = transform.position;
            if (positions.Count >= maxPositions)
                positions.RemoveAt(0);

            positions.Add(currentPos);

            lineRenderer.positionCount = positions.Count;
            lineRenderer.SetPositions(positions.ToArray());

            timeSinceLastUpdate = 0f;
        }
    }
}
