using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum FIELDTYPE
{
    lightning, bomb, spell
}
public class DropZone : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private FIELDTYPE _type;
    [SerializeField]
    private MatchGame _matchGame;
    [SerializeField]
    private List<ShapeNumberButton> _buttons;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.transform.TryGetComponent<ShapeNumberButton>(out ShapeNumberButton shapeNumberButton))
        {
            Debug.Log(_type.Equals(shapeNumberButton.GetFIELDTYPE()));
            if (_type.Equals(shapeNumberButton.GetFIELDTYPE()))
            {
                Debug.Log("Drop zone: set image to transform: eventData.pointerDrag.transform.position: " + eventData.pointerDrag.transform.position + " ; transform.position : " + transform.position);
                //eventData.pointerDrag.transform.position = transform.position;
                //score a point, remove above line, change shape, color, and number, reset pos
                _matchGame.AddScore();
                DisplayButtons();
                //shapeNumberButton.RandomizeStats();
            }
            else
            {
                shapeNumberButton.ResetPos();
            }
        }
    }

    public void DisplayButtons()
    {
        foreach(ShapeNumberButton snb in _buttons)
        {
            Debug.Log(snb.name + " color : "+snb.GetColor());
            Debug.Log(snb.name + " number : " + snb.GetNumber());
            Debug.Log(snb.name + " shape : " + snb.GetShape().name);
        }
    }
}
