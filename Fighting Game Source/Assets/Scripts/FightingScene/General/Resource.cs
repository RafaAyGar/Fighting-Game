using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[System.Serializable]
public class Resource
{
    [SerializeField] float _value;
    private float _maxValue;
    Slider _UIBar;

    public Resource(Slider UIBar, float maxValue)
    {
        _UIBar = UIBar;
        _maxValue = maxValue;
        _value = maxValue;
    }
    public float maxValue { get => _maxValue;}
    public float value
    {
        get => _value;
        set
        {
            _value = value;
            float lerpedValue = (_value * 100) / (_maxValue * 100);
            _UIBar.value = lerpedValue;
        }
    }

    public void Gain(float amountToGain)
    {
        if (value + amountToGain > maxValue) value = maxValue;
        else value += amountToGain;
    }

    public void Consume(float amountToConsume)
    {
        if (value - amountToConsume < 0) value = 0;
        else value -= amountToConsume;
    }
}