using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BFS 
{
    //esta es la lista la cual se encuentra el camino seleccionado
    public static List<Slot> Path;

    public static IEnumerator BreadthFirstSearch(Slot start, Slot end)
    {
        Queue<Slot> _slot = new Queue<Slot>();
        _slot.Enqueue(start);
        start.visited = true;
        Queue<Slot> path = new Queue<Slot>();

        while (path.Count != 0)
        {
            Slot s = _slot.Dequeue();
            path.Enqueue(s);
            if (!s.visited)
            {
                //randomxd
                s.RemoveWalls(s.links[0]);


                List<Slot> notVisited = new List<Slot>();
                foreach (var l in s.links)
                {
                    if (!l.visited)
                        notVisited.Add(l);
                }
                int rnd = Random.RandomRange(0, notVisited.Count);
                {
                    //estacosaquenofunciona.jpg 
                    //dosomething
                }
            }
        }
        //hagan todo aca...
        //recuerden ir llenando la lista del Path

        //en algun punto, ustedes sabran en que momento...
        MazeManager.instance.DoneBFS();
        yield return new WaitForEndOfFrame();
        //pista: no es al final
    }

}
