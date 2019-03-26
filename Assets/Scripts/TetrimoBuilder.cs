using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TetrimoBuilder : MonoBehaviour
{
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
    public static readonly Dictionary<string,int[][,]> TetrimoLayoutDictionary = new Dictionary<string, int[][,]>(){
        {"I", ILayouts},
        {"T", TLayouts},
        {"L", LLayouts},
        {"J", JLayouts},
        {"S", SLayouts},
        {"Z", ZLayouts},
        {"O", OLayouts}
    };
    public static readonly string[] TetrimoNames = TetrimoLayoutDictionary.Keys.ToArray();
    public static readonly string TetrimoGOName = "Tetrimo";
    public static readonly string BaseBlockGOName = "Block";
    private GameObject _tetrimoBaseBlock;
    private Vector2 _tetrimoCreationPoint;

    public TetrimoBuilder(GameObject tetrimoBaseBlock,Vector2 tetrimoCreationPoint)
    {
        _tetrimoBaseBlock = tetrimoBaseBlock;
        _tetrimoCreationPoint = tetrimoCreationPoint;
    }

    public GameObject CreateTetrimo(string tetrimoName)
    {
        if (!TetrimoNames.Contains(tetrimoName))
            throw new MissingComponentException($"There is no tetrimo called {tetrimoName}");
        return CreateTetrimo(tetrimoName,TetrimoLayoutDictionary[tetrimoName].First(),0);    
    }

    public GameObject CreateTetrimo(string tetrimoName,int[,] tetrimoLayout,int layoutIndex)
    {
        GameObject tetrimo = new GameObject(TetrimoGOName);

        for(int i=tetrimoLayout.GetLowerBound(0); i<=tetrimoLayout.GetUpperBound(0);i++)
            for(int j=tetrimoLayout.GetLowerBound(1); j<=tetrimoLayout.GetUpperBound(1);j++)
                if (tetrimoLayout[i,j] == 1)
                    drawBaseBlock(i,j,tetrimo.transform);
        
        Tetrimo t = tetrimo.AddComponent<Tetrimo>();
        t.BlockPositions = TetrimoLayoutDictionary[tetrimoName];
        t.CurrentIndex = layoutIndex;
        t.ApplyColour();
        return tetrimo;
    }

    public GameObject CreateRandomTetrimo()
    {
        string randomTetrimo = TetrimoNames[Random.Range(0,TetrimoNames.Length)];
        int randomIndex = Random.Range(0,TetrimoLayoutDictionary[randomTetrimo].Length);
        int[,] randomLayout = TetrimoLayoutDictionary[randomTetrimo][randomIndex];
        return CreateTetrimo(randomTetrimo,randomLayout,randomIndex);
    }

    private void drawBaseBlock(int x, int y, Transform parentTransform)
    {
        GameObject baseBlock = Instantiate(_tetrimoBaseBlock,new Vector3(x,y,0),Quaternion.identity,parentTransform);
        baseBlock.name = BaseBlockGOName;
    }
}
