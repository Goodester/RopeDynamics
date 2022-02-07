using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer _lr;
    [SerializeField] private Transform[] points;

    private void Start()
    {
        _lr = GetComponent<LineRenderer>();
        _lr.positionCount = points.Length;
    }

    private void Update()
    {
        for (var i = 0; i < points.Length; i++)
        {
            Vector3 dummyPosition = points[i].position;
            dummyPosition.z = 1;
            _lr.SetPosition(i, dummyPosition);
        }
    }
}
