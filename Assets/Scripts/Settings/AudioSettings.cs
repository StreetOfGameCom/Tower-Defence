using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider _mainSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private AudioSetter _audioSetter;

    private float _mainVolume = 1f;
    private float _musicVolume = 1f;
    private float _effectsVolume = 1f;


    private void Awake()
    {
        if(PlayerPrefs.HasKey(KeyManager.GetMainAudioKey())) _mainVolume = PlayerPrefs.GetFloat(KeyManager.GetMainAudioKey());
        if (PlayerPrefs.HasKey(KeyManager.GetMusicAudioKey())) _musicVolume = PlayerPrefs.GetFloat(KeyManager.GetMusicAudioKey());
        if (PlayerPrefs.HasKey(KeyManager.GetEffectsAudioKey())) _effectsVolume = PlayerPrefs.GetFloat(KeyManager.GetEffectsAudioKey());
        _mainSlider.value = _mainVolume;
        _musicSlider.value = _musicVolume;
        _effectsSlider.value = _effectsVolume;
    }

    public void SetMainAudio()
    {
        _mainVolume = _mainSlider.value;
        PlayerPrefs.SetFloat(KeyManager.GetMainAudioKey(), _mainVolume);
        PlayerPrefs.Save();
        _audioSetter.SetVolume();
    }

    public void SetMusicAudio()
    {
        _musicVolume = _musicSlider.value;
        PlayerPrefs.SetFloat(KeyManager.GetMusicAudioKey(), _musicVolume);
        PlayerPrefs.Save();
        _audioSetter.SetVolume();
    }
    public void SetEffectsAudio()
    {
        _effectsVolume = _effectsSlider.value;
        PlayerPrefs.SetFloat(KeyManager.GetEffectsAudioKey(), _effectsVolume);
        PlayerPrefs.Save();
        _audioSetter.SetVolume();
    }

}
