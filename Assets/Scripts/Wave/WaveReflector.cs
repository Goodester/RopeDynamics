namespace Wave
{
    public abstract class WaveReflector : WavePoint
    {
        public void Reflect(float amount, WavePoint cause)
        {
            cause.Displace(-amount, this);
        }
    }
}
