using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class BouncingButton : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f; // Speed of movement

    private Rigidbody2D _rb;
    private Vector3 _lastVel;

    [SerializeField]
    private TextMeshProUGUI _number;
    private int _bubbleValue; // Value on the bubble
    public BubbleClickedEvent onBubbleClicked;

    // Define the event for bubble creation
    public static UnityEvent<BouncingButton> onBubbleCreated = new UnityEvent<BouncingButton>();

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = GetRandomDirection() * _speed;
    }
    private void Update()
    {
        if(_rb.velocity.magnitude < _speed)
        {
            _rb.velocity = Random.insideUnitCircle.normalized * _speed;
        }
        _lastVel = _rb.velocity;
    }


    private void Awake()
    {
        if (onBubbleClicked == null)
        {
            onBubbleClicked = new BubbleClickedEvent();
        }
        // Invoke the onBubbleCreated event when a bubble is instantiated
        onBubbleCreated.Invoke(this);
    }

    public void OnClick()
    {
        onBubbleClicked.Invoke(_bubbleValue);
    }
    private Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_rb != null)
        {
            var speed2 = _lastVel.magnitude;
            var dir = Vector2.Reflect(_lastVel.normalized, collision.GetContact(0).normal);
            _rb.velocity = dir * _speed ;

        }
    }

    public void SetNumber(int number)
    {
        _bubbleValue = number;
        _number.text = _bubbleValue.ToString();
    }

}