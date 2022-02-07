using UnityEngine;

namespace Wave
{
    public class WaveEnd : WaveReflector
    {
        [SerializeField] private WaveBody neighbour;

        public override void Displace(float amount, WavePoint cause)
        {
            Reflect(amount  * (1 / WaveBody.Damping), cause);
        }
    }
}
