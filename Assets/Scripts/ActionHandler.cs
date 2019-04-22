using System;
using UnityEngine;
using UnityEngine.EventSystems;

public enum InputControl
{
    NONE, // Default.
    LEFT,
    RIGHT,
    FORCE_DOWN,
    DROP,
    ROTATE
}

public class ActionHandler : MonoBehaviour, IDragHandler
{
    private const int X_DRAG_THRESHOLD = 10;
    private const int Y_DRAG_THRESHOLD = 10;

    public InputControl CurrentControl { get; set; }
    private bool _isDragging = false;
    private Vector2 _lastDragPosition;
    private Vector2 _currentDragPosition;
    private Vector2 _dragDelta;

    // Start is called before the first frame update.
    void Start()
    {

    }

    // Update is called once per frame.
    void Update()
    {
        // Move left.
        if (Input.GetKeyDown(KeyCode.LeftArrow) || IsDraggingLeft())
        {
            CurrentControl = InputControl.LEFT;
            Debug.Log("Left");
        }
        // Move right.
        else if (Input.GetKeyDown(KeyCode.RightArrow) || IsDraggingRight())
        {
            CurrentControl = InputControl.RIGHT;
            Debug.Log("Right");
        }
        // Push piece down quickly (not supported on mobile).
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CurrentControl = InputControl.FORCE_DOWN;
            Debug.Log("Force Down");
        }
        // Quick drop piece (space or swipe down)
        else if (Input.GetKeyDown(KeyCode.Space) || IsDraggingDown())
        {
            CurrentControl = InputControl.DROP;
            Debug.Log("Drop");
        }
        // Rotate (up or tap).
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.touchCount > 0)
        {
            CurrentControl = InputControl.ROTATE;
            Debug.Log("Rotate");
        }

        // Key cancellors.
        else if (Input.GetKeyUp(KeyCode.LeftArrow)
            || Input.GetKeyUp(KeyCode.RightArrow)
            || Input.GetKeyUp(KeyCode.DownArrow)
            || Input.GetKeyUp(KeyCode.Space)
            || !_isDragging)
        {
            CurrentControl = InputControl.NONE;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _isDragging = eventData.dragging;
        _lastDragPosition = eventData.position;
        _currentDragPosition = eventData.position;
        _dragDelta = _currentDragPosition - _lastDragPosition;
    }

    public void OnDragEnding(PointerEventData eventData)
    {
        _isDragging = false;
    }

    private bool IsDraggingLeft()
    {
        if (!_isDragging) return false;

        return
            _dragDelta.x > 0
            && Math.Abs(_dragDelta.x) > X_DRAG_THRESHOLD
            && _dragDelta.y < Y_DRAG_THRESHOLD;
    }

    private bool IsDraggingRight()
    {
        if (!_isDragging) return false;

        return
            _dragDelta.x > 0
            && Math.Abs(_dragDelta.x) > X_DRAG_THRESHOLD
            && _dragDelta.y < Y_DRAG_THRESHOLD;
    }

    private bool IsDraggingDown()
    {
        if (!_isDragging) return false;

        return
            _dragDelta.y > 0
            && Math.Abs(_dragDelta.y) > Y_DRAG_THRESHOLD
            && _dragDelta.x < X_DRAG_THRESHOLD;
    }
}
