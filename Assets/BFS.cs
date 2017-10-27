using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BFS
{
    //esta es la lista la cual se encuentra el camino seleccionado
    public static List<Slot> Path = new List<Slot>();

    public static IEnumerator BreadthFirstSearch(Slot start, Slot end)
    {
        //hagan todo aca...
        //recuerden ir llenando la lista del Path

        //en algun punto, ustedes sabran en que momento...
        MazeManager.instance.DoneBFS();
        yield return new WaitForEndOfFrame();

        //pista: no es al final
    }

}
