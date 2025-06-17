using TMPro;
using UnityEngine;

public class TextVizualizer : VizualizeValue
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _description;
    [SerializeField] private float _value;

    public override void Vizualize(float value)
    {
        _text.text = _description + value.ToString();
    }
}
