using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tetrimo : MonoBehaviour
{
    public Color Colour;
    public int CurrentIndex;
    public int[][,] BlockPositions;
    // Start is called before the first frame update
    void Start()
    {

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

    public void ApplyColour()
    {
        Colour = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        ApplyColour(Colour);
    }

    public void Rotate()
    {
        // Check for index wrap
        CurrentIndex = (CurrentIndex + 1 < BlockPositions.Length) ? CurrentIndex + 1 : 0;

        // Move each block by manipulating it's transform coordinates wrt it's parent.
        // The world scale is set to unit length
        int counter = 0;
        Transform[] ts = this.GetComponentsInChildren<Transform>().Where(x => x.name == TetrimoBuilder.BaseBlockGOName).ToArray();

        int[,] layout = BlockPositions[CurrentIndex];
        for(int i=layout.GetLowerBound(0); i<=layout.GetUpperBound(0);i++)
            for(int j=layout.GetLowerBound(1); j<=layout.GetUpperBound(1);j++)
                if (layout[i,j] == 1)
                {
                    ts[counter].position = new Vector3(i,j,0);
                    counter++;
                }
    }

    public bool CheckForTetrimoCollision()
    {
        throw new System.Exception("Not Yet Implemented");
    }
}
