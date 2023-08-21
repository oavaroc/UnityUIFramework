using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShapeNumberButton : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _number;
    private Vector3 _startPos;
    [SerializeField]
    private FIELDTYPE _type;
    [SerializeField]
    private List<Sprite> _shapes;
    [SerializeField]
    private List<Color> _availableColors;
    private int _buttonNumber;

    private void Start()
    {
        InitializeColors();
        _startPos = transform.position;
        _image.color = Random.ColorHSV();
        _buttonNumber = Random.Range(1, 51);
        _number.text = _buttonNumber.ToString();
    }

    private void InitializeColors()
    {
        _availableColors.Add(Color.black);
        _availableColors.Add(Color.blue);
        _availableColors.Add(Color.cyan);
        _availableColors.Add(Color.gray);
        _availableColors.Add(Color.green);
        _availableColors.Add(Color.magenta);
        _availableColors.Add(Color.red);
        _availableColors.Add(Color.white);
        _availableColors.Add(Color.yellow);
    }

    public bool GetImageColor(Color color)
    {
        return _image.color.Compare(color);
    }
    public bool GetTextColor(Color color)
    {
        return _number.color.Compare(color);
    }

    public bool CompareShape()
    {
        return false;
    }

    public bool CompareNumber(int number)
    {
        return int.Parse(_number.text) == number;
    }




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
        }
            ResetPos();
        //_image.color = new Color(1, 1, 1, 1);
        _image.raycastTarget = true;

    }

    public void RandomizeStats()
    {
        _image.sprite = _shapes[Random.Range(0, _shapes.Count)];
        _image.color = _availableColors[Random.Range(0, _availableColors.Count)];
        _buttonNumber = Random.Range(1, 100);
        _number.text = _buttonNumber.ToString();
    }


    public void ResetPos()
    {
        transform.position = _startPos;
    }

    public FIELDTYPE GetFIELDTYPE()
    {
        return _type;
    }

    public Color GetColor()
    {
        return _image.color;
    }
    public Sprite GetShape()
    {
        return _image.sprite;
    }
    public int GetNumber()
    {
        return _buttonNumber;
    }
}
