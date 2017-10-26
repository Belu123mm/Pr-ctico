using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BFS
{
    //esta es la lista la cual se encuentra el camino seleccionado
    public static List<Slot> Path = new List<Slot>();

    public static IEnumerator BreadthFirstSearch(Slot start, Slot end)
    {
        Queue<Slot> _slot = new Queue<Slot>();
        _slot.Enqueue(start);
        start.visited = true;
        Path.Add(start);

        while (_slot.Count > 0)
        {
            Slot s = _slot.Dequeue();

            if (s == end)
            {
                while (s != start)
                {
                    Path.Add(s);
                    if (s == start)
                        break; //no toques esto si no qieres matar la pc
                }
            }
            else
            {
                foreach (var w in s.walkableNext)
                {
                    w.visited = true;
                    _slot.Enqueue(w);
                }
            }
            yield return new WaitForEndOfFrame();
        }
        //hagan todo aca...
        //recuerden ir llenando la lista del Path

        //en algun punto, ustedes sabran en que momento...
        MazeManager.instance.DoneBFS();
        yield return new WaitForEndOfFrame();

        //pista: no es al final
    }

}
