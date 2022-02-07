using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Utils;

namespace Wave
{
    public class WaveSource : WaveReflector
    {
        [SerializeField] private WaveBody neighbour;
        [SerializeField] public GameObject pipeWrench;

        private float _lastYPos;
        private float _displacement;
        private GameObject _waveEnd;
    
        private void Awake()
        {
            transform.parent = pipeWrench.transform;
            _waveEnd = GameObject.Find("EndCircle");
            Globals.EquilibriumLine = new Line2D(transform.position, _waveEnd.transform.position);
        }

        private void Start()
        {
            StartCoroutine(Clock());
        }

        private IEnumerator Clock()
        {
            while (true)
            {
                UpdateEquilibriumLine();
                StartWaveOnPosChange();
                
                yield return new WaitForSeconds(Globals.DelayBetweenWavePoints / 1000f);
            }
        }
        
        private void StartWaveOnPosChange()
        {
            float currYPos = transform.position.y;
            _displacement = currYPos - _lastYPos;
            if (math.abs(_displacement) > 0)
            {
                neighbour.Displace(_displacement * (1 / WaveBody.Damping), this);
            }
            _lastYPos = currYPos;
        }

        private void UpdateEquilibriumLine()
        {
            Globals.EquilibriumLine.Point1 = _waveEnd.transform.InverseTransformPoint(
                transform.TransformPoint(transform.position));
        }
    
        public override void Displace(float amount, WavePoint cause)
        {
            Reflect(amount * (1 / WaveBody.Damping), cause);
        }
    }
}
