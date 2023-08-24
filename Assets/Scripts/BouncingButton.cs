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

    /* Summary: gets the rigidbody of the bouncing button when initialized
     * 
     */
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = GetRandomDirection() * _speed;
    }
    /* Summary: Returns a random direction for the ball to go
     * 
     * returns:
     * Vector2 : random direction in a normalized vector2
     */
    private Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    /* Summary: keeps the speed up so it does not move slower over time, keeps track of the last velocity for when bouncing
     * 
     */
    private void Update()
    {
        if(_rb.velocity.magnitude < _speed)
        {
            _rb.velocity = Random.insideUnitCircle.normalized * _speed;
        }
        _lastVel = _rb.velocity;
    }


    /* Summary: Sets the on bubble clicked event when bubble is created
     * 
     */
    private void Awake()
    {
        if (onBubbleClicked == null)
        {
            onBubbleClicked = new BubbleClickedEvent();
        }
        // Invoke the onBubbleCreated event when a bubble is instantiated
        onBubbleCreated.Invoke(this);
    }

    /* Summary: invokes on clicked when button is clicked
     * 
     */
    public void OnClick()
    {
        onBubbleClicked.Invoke(_bubbleValue);
    }

    /* Summary: Handles collision with other objects and the reflections
     * 
     * parameters:
     * collision : collision information
     * 
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_rb != null)
        {
            var speed2 = _lastVel.magnitude;
            var dir = Vector2.Reflect(_lastVel.normalized, collision.GetContact(0).normal);
            _rb.velocity = dir * _speed ;

        }
    }

    /* Summary: Sets the number for this button
     * 
     * parameters:
     * number : the number for the button
     * 
     */
    public void SetNumber(int number)
    {
        _bubbleValue = number;
        _number.text = _bubbleValue.ToString();
    }

}