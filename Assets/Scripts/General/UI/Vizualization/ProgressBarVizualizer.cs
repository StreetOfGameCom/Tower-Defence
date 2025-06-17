using UnityEngine;
using UnityEngine.UI;

public class ProgressBarVizualizer : VizualizeValue
{
    [SerializeField] private Slider _progressBar;
    [SerializeField] private float _maxValue;
    private float  _currentValue;
    
    public float CurrentValue
    {
        get => _currentValue;
    }

    public override void Vizualize(float value)
    {
        _currentValue = Mathf.Clamp(value, 0, _maxValue);
        _progressBar.value = _currentValue;
    }
}
