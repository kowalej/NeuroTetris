using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tetrimo : MonoBehaviour
{
    public Color Colour;
    public Vector2[] BlockPositions;
    // Start is called before the first frame update
    void Start()
    {
        ApplyColour(Colour);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyColour(Color color)
    {
        foreach (SpriteRenderer sr in this.GetComponentsInChildren<SpriteRenderer>().Where(x => x.name != "shadow"))
        {
            sr.color = color;
        }
    }

    public void Rotate()
    {
        
    }
}
