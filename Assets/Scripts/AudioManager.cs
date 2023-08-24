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

    /* Summary: Plays the math correct sound
     * 
     */
    public void PlayMathCorrect()
    {
        _soundEffectSource.PlayOneShot(_mathCheckSoundGood);
    }
    /* Summary: Plays the math wrong sound
     * 
     */
    public void PlayMathWrong()
    {
        _soundEffectSource.PlayOneShot(_mathCheckSoundBad);
    }
    /* Summary: Plays the bubble correct sound
     * 
     */
    public void PlayBubbleRight()
    {
        _soundEffectSource.PlayOneShot(_bubblePopped);
    }
    /* Summary: Plays the bubble wrong sound
     * 
     */
    public void PlayBubbleWrong()
    {
        _soundEffectSource.PlayOneShot(_bubbleWrong);
    }
    /* Summary: Plays the match flip sound
     * 
     */
    public void PlayMatchItemFlipped()
    {
        _soundEffectSource.PlayOneShot(_matchItemFlipped);
    }
    /* Summary: Plays the match wrong sound
     * 
     */
    public void PlayMatchItemWrong()
    {
        _soundEffectSource.PlayOneShot(_matchItemWrong);
    }
    /* Summary: Plays the match correct sound
     * 
     */
    public void PlayMatchItemRight()
    {
        _soundEffectSource.PlayOneShot(_matchItemRight);
    }
    /* Summary: Plays the button clicked sound
     * 
     */
    public void PlayMenuSound()
    {
        _soundEffectSource.PlayOneShot(_menuButtonSounds);
    }
}
