using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSetter : MonoBehaviour
{
    [SerializeField] private List<AudioParametr> _audioPlayers;
    [SerializeField] private AudioMixer _mixerGroup;

    private const float _multiplier = 20f;

    private void Start()
    {
        SetVolume();
    }

    public void SetVolume()
    {
        foreach (AudioParametr player in _audioPlayers)
        {
            var parametr = player.Get();
            var saveValue = PlayerPrefs.GetFloat(parametr.Item2);            
            var volumeValue = MathF.Log10(saveValue) * _multiplier;
            _mixerGroup.SetFloat(parametr.Item1, volumeValue);
        }
    }

}
[Serializable]
public class AudioParametr
{
    [SerializeField] private string _audioKey;
    [SerializeField] private string _keyValue;
    public (string audioKey, string keyValue) Get()
    {
        return (_audioKey, _keyValue);
    }
}
