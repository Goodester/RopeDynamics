using System.Collections;
using UnityEngine;
using Utils;

namespace Wave
{
    public class WaveBody : WavePoint
    {
        [SerializeField] private WavePoint leftNeighbour;
        [SerializeField] private WavePoint rightNeighbour;
        
        private float _displacement;
        public static float Damping
        {
            get;
            set;
        } = 1f;
        public static float RestoringSpeed => 0.01f;
        private Line2D _equilibriumLine;

        private void Start()
        {
            _equilibriumLine = Globals.EquilibriumLine;
            StartCoroutine(RestoreToEquilibrium());
        }

        private void Update()
        {
            Vector3 dummyPos = transform.position;
            dummyPos.y += _displacement;
            transform.position = dummyPos;
            _displacement = 0;
        }

        private IEnumerator RestoreToEquilibrium()
        {
            while (true)
            {
                if (Damping != 1f)
                {
                    Vector2 pos = transform.position;
                    float displacementFromEquilibrium = pos.y -
                                                        _equilibriumLine.CalculateY(pos.x);
                    _displacement += RestoringSpeed * (-displacementFromEquilibrium);
                }

                yield return new WaitForSeconds(Globals.DelayBetweenWavePoints / 1000f);
            }
        }

        public override void Displace(float amount, WavePoint cause)
        {
            _displacement += amount;

            WavePoint neighbourToBeDisplaced = cause == leftNeighbour ? rightNeighbour : leftNeighbour;
            StartCoroutine(UtilityMethods.AddDelayToDisplacementMethod
                (neighbourToBeDisplaced.Displace, amount * (1 / Damping), this));
        }
    }
}
