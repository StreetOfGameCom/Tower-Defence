using UnityEngine;
using UnityEngine.UI;

public class AudioButton : ButtonSourse
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private Sprite _offIcon;
    [SerializeField] private Sprite _onIcon;
    [SerializeField] private Image _buttonIcon;
    private bool _onAudio = true;

    private void Awake()
    {
        if(PlayerPrefs.HasKey(KeyManager.GetActiveKeyAudio()))
        {
            _onAudio = PlayerPrefs.GetInt(KeyManager.GetActiveKeyAudio()) == 0 ? false : true;
        }
        _musicSource.mute = !_onAudio;
        if (_musicSource.mute) _buttonIcon.sprite = _offIcon;
        else _buttonIcon.sprite = _onIcon;
        
    }

    public void SwitchAudio()
    {
        ClickSource();
        _musicSource.mute = !_musicSource.mute;
        if (_musicSource.mute) _buttonIcon.sprite = _offIcon;
        else _buttonIcon.sprite = _onIcon;
        PlayerPrefs.SetInt(KeyManager.GetActiveKeyAudio(), _musicSource.mute ? 0 : 1);
        PlayerPrefs.Save();
    }

}
