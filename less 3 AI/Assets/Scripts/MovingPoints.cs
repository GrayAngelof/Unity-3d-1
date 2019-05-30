using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Tests
{
    public class MovingPoints : MonoBehaviour
    {
        [SerializeField] private Transform _agent;
        [SerializeField] private Transform _point;
        private Queue<Transform> _points = new Queue<Transform>();
        private readonly Color _color = Color.red;
        private readonly int lengthOfLineRenderer = 100;
        private LineRenderer _lineRenderer;
        private Camera _camera;

        private Vector3 _mousePosition;
        private NavMeshPath _path;
        private float _elapsed = 0;

        private Vector3 _zero;
        private void Start()
        {
            _camera = FindObjectOfType<Camera>();
            _lineRenderer = new GameObject("LineRenderer").AddComponent<LineRenderer>();
            _lineRenderer.startWidth = 0.5F;
            _lineRenderer.endWidth = 0.5F;
            _lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
            _lineRenderer.startColor = _color;
            _lineRenderer.endColor = _color;
            _lineRenderer.positionCount = lengthOfLineRenderer;
            _lineRenderer.SetPosition(0, _agent.position);
            _mousePosition = Input.mousePosition;

            _path = new NavMeshPath();
            _elapsed = 0;
        }

        private void Update()
        {
            _mousePosition = Input.mousePosition;
            if (Physics.Raycast(_camera.ScreenPointToRay(_mousePosition), out var hit))
            {
                //if (Input.GetMouseButtonDown(0))
                //{
                //    DrawPoint(hit.point);
                //}
            }
            _elapsed += Time.deltaTime;
            if (_elapsed > 1)
            {
                for (int i = 0; i < _path.corners.Length; i++)
                {
                    _path.corners[i] = Vector3.zero;
                }

                _elapsed = 0;
                NavMesh.CalculatePath(_agent.position, hit.point, NavMesh.AllAreas, _path);
            }

            for (var i = 0; i < _path.corners.Length - 1; i++)
            {
                //_lineRenderer.SetPosition(1, hit.point);
                _lineRenderer.SetPosition(i, _path.corners[i + 1]);
            }
        }

        private void DrawPoint(Vector3 position)
        {
            var tempPoint = Instantiate(_point, position, Quaternion.identity);
            _points.Enqueue(tempPoint);
            _lineRenderer.SetPosition(0, tempPoint.position);
        }
    }
}