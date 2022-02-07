using UnityEngine;

namespace Wave
{
    public abstract class WavePoint : MonoBehaviour
    {
        public abstract void Displace(float amount, WavePoint cause);
    }
}
