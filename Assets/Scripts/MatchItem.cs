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

    private void Start()
    {
        _matchGame = FindObjectOfType<MatchGame>();

        EventTrigger.Entry eventEntry = new EventTrigger.Entry();
        eventEntry.eventID = EventTriggerType.PointerClick;
        
        eventEntry.callback.AddListener(x => _matchGame.CheckSelected(toggle));
        eventTrigger.triggers.Add(eventEntry);

        StartCoroutine(HideRoutine());
        
    }

    IEnumerator HideRoutine()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        toggle.isOn = false;
    }

    public FRUITS GetFruit()
    {
        return _fruitType;
    }

    public void SetFruit(int fruitId, Sprite image)
    {
        _fruitType = (FRUITS)fruitId;
        _fruitImage.sprite = image;
    }

}
