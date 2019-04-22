using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TetrimoTypes
{
    I, T, L, J, S, Z, O, NUM_TETRIMOS
}

public class Tetrimo : MonoBehaviour
{
    #region Tetrimo Layout "Grids"
    private static readonly int[][,] TLayouts = {
        new int[,] {
            {0,1,0},
            {1,1,1},
            {0,0,0}
        },
        new int[,] {
            {0,1,0},
            {0,1,1},
            {0,1,0}
        },
        new int[,] {
            {0,0,0},
            {1,1,1},
            {0,1,0}
        },
        new int[,] {
            {0,1,0},
            {1,1,0},
            {0,1,0}
        },
    };
    private static readonly int[][,] LLayouts = {
        new int[,] {
            {0,1,0},
            {0,1,0},
            {0,1,1}
        },
        new int[,] {
            {0,0,0},
            {1,1,1},
            {1,0,0}
        },
        new int[,] {
            {1,1,0},
            {0,1,0},
            {0,1,0}
        },
        new int[,] {
            {0,0,1},
            {1,1,1},
            {0,0,0}
        },
    };
    private static readonly int[][,] JLayouts = {
        new int[,] {
            {0,1,0},
            {0,1,0},
            {1,1,0}
        },
        new int[,] {
            {1,0,0},
            {1,1,1},
            {0,0,0}
        },
        new int[,] {
            {0,1,1},
            {0,1,0},
            {0,1,0}
        },
        new int[,] {
            {0,0,0},
            {1,1,1},
            {0,0,1}
        },
    };
    private static readonly int[][,] ILayouts = {
        new int[,] {
            {0,1,0,0},
            {0,1,0,0},
            {0,1,0,0},
            {0,1,0,0}
        },
        new int[,] {
            {0,0,0,0},
            {1,1,1,1},
            {0,0,0,0},
            {0,0,0,0}
        }
    };
    private static readonly int[][,] SLayouts = {
        new int[,] {
            {0,1,1},
            {1,1,0},
            {0,0,0}
        },
        new int[,] {
            {0,1,0},
            {0,1,1},
            {0,0,1}
        }
    };
    private static readonly int[][,] ZLayouts = {
        new int[,] {
            {1,1,0},
            {0,1,1},
            {0,0,0}
        },
        new int[,] {
            {0,0,1},
            {0,1,1},
            {0,1,0}
        }
    };
    private static readonly int[][,] OLayouts = {
        new int[,] {
            {1,1},
            {1,1}
        }
    };
    #endregion

    public static readonly Dictionary<TetrimoTypes, int[][,]> TetrimoLayoutDictionary = new Dictionary<TetrimoTypes, int[][,]>(){
        {TetrimoTypes.I, ILayouts},
        {TetrimoTypes.T, TLayouts},
        {TetrimoTypes.L, LLayouts},
        {TetrimoTypes.J, JLayouts},
        {TetrimoTypes.S, SLayouts},
        {TetrimoTypes.Z, ZLayouts},
        {TetrimoTypes.O, OLayouts}
    };
    public static readonly Dictionary<TetrimoTypes, Color> TetrimoColourDictionary = new Dictionary<TetrimoTypes, Color>(){
        {TetrimoTypes.I, Color.blue},
        {TetrimoTypes.T, Color.green},
        {TetrimoTypes.L, Color.red},
        {TetrimoTypes.J, Color.cyan},
        {TetrimoTypes.S, Color.magenta},
        {TetrimoTypes.Z, Color.white},
        {TetrimoTypes.O, Color.black}
    };
    public static GameObject TetrimoBaseBlock { get; set; }
    public static readonly string TetrimoGOName = "Tetrimo";
    public static readonly string BaseBlockGOName = "Block";

    public int CurrentIndex { get; set; }
    public int[][,] BlockPositions { get; set; }

    public TetrimoTypes TetrimoType { get; private set; }
    public Color Colour { get; private set; }

    public void InitiateTetrimo(TetrimoTypes tetrimoType)
    {
        TetrimoType = tetrimoType;

        InitialDraw();
        ApplyColour();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitialDraw()
    {
        var tetrimoLayout = TetrimoLayoutDictionary[TetrimoType].First(); // Default position.
        for (int i = tetrimoLayout.GetLowerBound(0); i <= tetrimoLayout.GetUpperBound(0); i++)
            for (int j = tetrimoLayout.GetLowerBound(1); j <= tetrimoLayout.GetUpperBound(1); j++)
                if (tetrimoLayout[i, j] == 1)
                    drawBaseBlock(i, j, transform);
    }

    private void drawBaseBlock(int x, int y, Transform parentTransform)
    {
        GameObject baseBlock = Instantiate(TetrimoBaseBlock, new Vector3(x, y, 0), Quaternion.identity, parentTransform);
        baseBlock.name = BaseBlockGOName;
    }

    private void ApplyColour()
    {
        Color colour = TetrimoColourDictionary[TetrimoType];
        // Paint all foregrounds (not shadows).
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>().Where(x => x.name != "shadow"))
        {
            sr.color = colour;
        }
    }

    public void Rotate()
    {
        // Check for index wrap
        CurrentIndex = (CurrentIndex + 1 < BlockPositions.Length) ? CurrentIndex + 1 : 0;

        // Move each block by manipulating it's transform coordinates wrt it's parent.
        // The world scale is set to unit length
        int counter = 0;
        Transform[] ts = this.GetComponentsInChildren<Transform>().Where(x => x.name == BaseBlockGOName).ToArray();

        int[,] layout = BlockPositions[CurrentIndex];
        for (int i = layout.GetLowerBound(0); i <= layout.GetUpperBound(0); i++)
            for (int j = layout.GetLowerBound(1); j <= layout.GetUpperBound(1); j++)
                if (layout[i, j] == 1)
                {
                    ts[counter].position = new Vector3(i, j, 0);
                    counter++;
                }
    }

    public bool CheckForTetrimoCollision()
    {
        throw new System.Exception("Not Yet Implemented");
    }
}
