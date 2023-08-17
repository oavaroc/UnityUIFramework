using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShapeNumberButton : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _number;


    private void Start()
    {
        _image.color = Random.ColorHSV();
        _number.text = Random.Range(1,51).ToString();
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
}
