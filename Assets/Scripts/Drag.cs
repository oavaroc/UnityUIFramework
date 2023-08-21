using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField]
    private Image _image;
    private Vector3 _startPos;
    [SerializeField]
    private FIELDTYPE _type;

    //private Color _startColor;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //_startColor = _image.color;
        //_image.color = new Color(1, 1, 1, 0.5f);
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag on drag: transform.position = eventData.position ; transform.position : " + transform.position + " ; eventData.position : " + eventData.position);

        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!eventData.pointerCurrentRaycast.gameObject.TryGetComponent<DropZone>(out DropZone dz))
        {
            Debug.Log("Drag on OnEndDrag: ResetPos : " + transform.position + " ; _startPos : " + _startPos);
            ResetPos();
        }
        //_image.color = new Color(1, 1, 1, 1);
        _image.raycastTarget = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    public void ResetPos()
    {
        transform.position = _startPos;
    }

    public FIELDTYPE GetFIELDTYPE()
    {
        return _type;
    }
}
