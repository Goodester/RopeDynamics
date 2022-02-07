using UnityEngine;
using Utils;

public class Globals : MonoBehaviour
{
    private void Awake()
    {
        float pipeWrenchY = GameObject.Find("PipeWrench").transform.position.y;
        PipeWrenchMaxY = pipeWrenchY + MaxAmplitude;
        PipeWrenchMinY = pipeWrenchY - MaxAmplitude;
    }

    public static int DelayBetweenWavePoints => 75; // ms
    public static float MaxAmplitude = 5;
    public static float PipeWrenchMaxY;
    public static float PipeWrenchMinY;
    
    public static Line2D EquilibriumLine;
}
