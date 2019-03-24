using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.EventSystems;

public enum InputControl {
    NONE, // Default.
    LEFT,
    RIGHT,
    DOWN,
    DROP,
    ROTATE
}

public class ActionHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public InputControl CurrentControl {get; set;}
    private bool _isDragging = false;
    private Vector2 _startDragPosition;
    private Vector2 _endDragPosition;
    private Vector2 _dragDelta;
    private const int _dragWindowSize = 10;
    private int _dragFrameCounter = _dragWindowSize;

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
        }
        // Move right.
        else if (Input.GetKeyDown(KeyCode.RightArrow) || IsDraggingRight())
        {
            CurrentControl = InputControl.RIGHT;
        }
        // Push piece down quickly (not supported on mobile).
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CurrentControl = InputControl.DOWN;
        }
        // Quick drop piece (space or swipe down)
        else if (Input.GetKeyDown(KeyCode.DownArrow) || IsDraggingDown()){
            CurrentControl = InputControl.DROP;
        }
        // Rotate (up or tap).
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.touchCount > 0){
            CurrentControl = InputControl.ROTATE;
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
        // At the start of the drag, or when we have hit our "window" size, we track a new drag start position.
        if(!_isDragging || _dragFrameCounter == _dragWindowSize) {
            _startDragPosition = eventData.position;
            _isDragging = eventData.dragging;
        }
        _endDragPosition = eventData.position;
        _dragDelta = _endDragPosition - _startDragPosition;
    }

    public void OnDragEnding(PointerEventData eventData) {
        _isDragging = false;
        _dragFrameCounter = 0;
    }

    private bool IsDraggingLeft() {
        if (!_isDragging) return false;

        bool draggingLeft = false;

        return draggingLeft;
    }

    private bool IsDraggingRight()
    {
        if (!_isDragging) return false;

        bool draggingRight = false;

        return draggingRight;
    }

     private bool IsDraggingDown()
    {
        if (!_isDragging) return false;

        bool draggingRight = false;

        return draggingRight;
    }
}
