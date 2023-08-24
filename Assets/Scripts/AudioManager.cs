using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{

    [SerializeField]
    private AudioSource _backgroundSource;
    [SerializeField]
    private AudioSource _soundEffectSource;
    [SerializeField]
    private AudioClip _mathCheckSoundGood;
    [SerializeField]
    private AudioClip _mathCheckSoundBad;
    [SerializeField]
    private AudioClip _bubblePopped;
    [SerializeField]
    private AudioClip _bubbleWrong;
    [SerializeField]
    private AudioClip _matchItemFlipped;
    [SerializeField]
    private AudioClip _matchItemWrong;
    [SerializeField]
    private AudioClip _matchItemRight;
    [SerializeField]
    private AudioClip _menuButtonSounds;
    // Start is called before the first frame update
    
    public void PlayMathCorrect()
    {
        _soundEffectSource.PlayOneShot(_mathCheckSoundGood);
    }
    public void PlayMathWrong()
    {
        _soundEffectSource.PlayOneShot(_mathCheckSoundBad);
    }
    public void PlayBubbleRight()
    {
        _soundEffectSource.PlayOneShot(_bubblePopped);
    }
    public void PlayBubbleWrong()
    {
        _soundEffectSource.PlayOneShot(_bubbleWrong);
    }
    public void PlayMatchItemFlipped()
    {
        _soundEffectSource.PlayOneShot(_matchItemFlipped);
    }
    public void PlayMatchItemWrong()
    {
        _soundEffectSource.PlayOneShot(_matchItemWrong);
    }
    public void PlayMatchItemRight()
    {
        _soundEffectSource.PlayOneShot(_matchItemRight);
    }
    public void PlayMenuSound()
    {
        _soundEffectSource.PlayOneShot(_menuButtonSounds);
    }
}
