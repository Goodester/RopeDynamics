using UnityEngine;
using UnityEngine.UI;
using Wave;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void Start()
    {
        
        slider.onValueChanged.AddListener(delegate{ValueChangeCheck();});
    }
	
    private void ValueChangeCheck()
    {
        WaveBody.Damping = 1 + slider.value / 100;
    }
}
