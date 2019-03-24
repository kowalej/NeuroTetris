using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrmioBuilder : MonoBehaviour
{
    private readonly int[][,] TLayouts = {
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
    private readonly int[][,] LLayouts = {
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
    private readonly int[][,] JLayouts = {
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
    private readonly int[][,] ILayouts = {
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
    private readonly int[][,] SLayouts = {
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

    private readonly int[][,] ZLayouts = {
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
