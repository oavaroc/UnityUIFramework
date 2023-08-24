using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MatchItem : MonoBehaviour
{
    public enum FRUITS
    {
        APPLE,
        LEMON,
        RASPBERRY,
        GRAPE,
        ORANGE,
        PRUNE,
        COCONUT,
        PINEAPPLE,
        WHITEBALL,
        STRAWBERRY,
        GREENAPPLE,
        BANANA,
        GREENGRAPE,
        POMEGRANITE,
        BLACKBERRY,
        MELON,
        BLUEBERRY,
        REDBALLS,
        BLUEBALLS,
        LIME,
        WATERMELON,
        PEAR,
        CHERRY,
        MANDARIN,
        REDFRUIT,
        BLACKBALLS,
        MANGO,
        REDGRAPES,
        ORANGE2,
        KIWI
    }

    [SerializeField]
    private FRUITS _fruitType;
    [SerializeField]
    private Image _fruitImage;
    [SerializeField]
    private EventTrigger eventTrigger;
    [SerializeField]
    private Toggle toggle;
    private MatchGame _matchGame;

    private EventTrigger.Entry eventEntry = new EventTrigger.Entry();

    /* Summary: Sets the match item pointer click event to call the current match game check selected method, and pass in the toggle
     * 
     */
    private void Start()
    {
        _matchGame = FindObjectOfType<MatchGame>();

        eventEntry.eventID = EventTriggerType.PointerClick;
        
        eventEntry.callback.AddListener(x => _matchGame.CheckSelected(toggle));
        eventTrigger.triggers.Add(eventEntry);

        StartCoroutine(HideRoutine());
        
    }

    /* Summary: Hides the match game toggle buttons over a few seconds by turning them off
     * 
     */
    IEnumerator HideRoutine()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        toggle.isOn = false;
    }

    /* Summary: Removes the on click trigger
     * 
     */
    public void RemoveOnClick()
    {
        eventTrigger.triggers.Remove(eventEntry);
    }

    /* Summary: Returns the fruit of this match item for comparison
     * 
     * returns:
     * FRUITS : the fruit type of this button
     */
    public FRUITS GetFruit()
    {
        return _fruitType;
    }

    /* Summary: Sets up the match item with the type of fruit and the fruit sprite
     * 
     * Parameters: 
     * fruitId : the if of the fruit, to be converted to the FRUITS enum
     * image : the sprite of the fruit to display
     */
    public void SetFruit(int fruitId, Sprite image)
    {
        _fruitType = (FRUITS)fruitId;
        _fruitImage.sprite = image;
    }

}
