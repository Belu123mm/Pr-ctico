using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DFS
{
    #region
    /*
     * Si recuerdan lo de la semana pasada, haganlo.
       Sumandole el hecho de que ahora no busca un nodo final,
       sino que tiene que completar toda la grilla..


       Si no lo recuerdan, les dejo otra forma ;)

        Backtrack Recursivo

        Hacer la celda inicial la celda actual y marcarla como visitada
        Hacer...
            Fijarse si quedan celdas sin visitar
            Si la celda actual tiene vecinos que no han sido visitados
                Elegir aleatoriamente a uno de los vecinos no visitados
                Agregar la celda actual a la pila
                Quitar la pared entre la celda actual y la celda elegida
                Hacer que la celda elegida sea la celda actual y marcarla como visitada
                Agregar la celda elegida a la lista de caminables de la actual
            Si no, si la pila no está vacía
                Sacar una celda de la pila y hacerla la celda actual
        ...Mientras haya celdas no visitadas


        Ayuda:
        -el slot tiene un bool .visited
        -la grilla entera se encuentra en Mazemanager.maze
        -los vecinos de cada slot estan en .links
        -para eliminar las paredes entre 2 slots se usa el metodo nodoA.RemoveWalls(nodoB)
        -hay una lista que tiene cada slot la cual van a utilizar para el BFS que es la de vecinos "Caminables", se encuentra en .walkableNext

    */
    #endregion

    public static IEnumerator DeepFirstSearch(Slot start)
    {
        #region
        /*
        //hacer todo aca...
        List<Slot> _slot = new List<Slot>();
        _slot.Add(start);
        // start.visited = true;
        List<Slot> path = new List<Slot>();

        while (_slot.Count != 0)
        {
            Debug.Log("hello");
            Slot s = _slot[_slot.Count - 1];
            _slot.Remove(s);
            path.Add(s);
            if (s == MazeManager.maze[MazeManager.maze.Count - 1])
            {
                foreach (var item in MazeManager.maze)
                    item.visited = false;
                MazeManager.instance.DoneDFS();

            }

            List<Slot> notVisited = new List<Slot>();
            foreach (var l in s.links)
            {
                if (!l.visited)
                    notVisited.Add(l);
                _slot.Add(l);
                yield return new WaitForEndOfFrame();
            }
            int rnd = Random.Range(0, notVisited.Count);
            s.RemoveWalls(s.links[rnd]);*/

        //estacosaquenofunciona.jpg 
        //dosomething
        #endregion

        //hacer todo aca...
        Stack<Slot> _slot = new Stack<Slot>();
        _slot.Push(start);
        start.visited = true;

        List<Slot> path = new List<Slot>();

        while (_slot.Count != 0)
        {
            Slot s = _slot.Pop();

            foreach (var l in s.links)
            {
                if (!l.visited)
                {
                    path.Add(l);
                }
            }

            if (path.Count > 0)
            {
                int rnd = Random.Range(0, path.Count - 1);

                _slot.Push(path[rnd]);
                path[rnd].visited = true;
                s.RemoveWalls(path[rnd]);
                // quiero suponer que ak va algo con el previus
                s.walkableNext.Add(path[rnd]);
                path.Clear();
            }

            if (path.Count == 0 && _slot.Count > 0)
            {
                //Aca deberia poner algo pero no se que, onda se hace pero hay slots sin ser visitados pero como que me quedo sin path

            }
            yield return new WaitForEndOfFrame();
        }



        //esto va en algun lado para alivianar la carga del programa, piensen donde
        yield return new WaitForEndOfFrame();
        //esto va como ultimas lineas
        //cuando se complete el DFS, se limpian los visitados
        //y se continua al BFS
        foreach (var item in MazeManager.maze)
            item.visited = false;
        MazeManager.instance.DoneDFS();
    }
}
