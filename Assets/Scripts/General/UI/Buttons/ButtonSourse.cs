using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class ButtonSourse : MonoBehaviour
{
    [SerializeField] protected AudioClip _audioClip;
    [SerializeField] protected AudioSource _audioSource;

    private void Awake()
    {
        if(_audioSource == null)_audioSource = GetComponent<AudioSource>();
    }

    public void ClickSource()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}
