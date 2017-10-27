using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DFS {
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

    public static IEnumerator DeepFirstSearch( Slot start ) {
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
        List<Slot> _slot = new List<Slot>(); //altok
        List<Slot> visitedRoute = new List<Slot>();  //altok
        _slot.Add(start); //altok
        start.visited = true; //altok
        List<Slot> _nonVisited = new List<Slot>();
        _nonVisited = MazeManager.maze;
        Slot end = MazeManager.maze [ MazeManager.maze.Count - 1];
        Debug.Log(end);

            
        while ( _slot.Count > 0 ) {
            Slot s = _slot [ _slot.Count - 1 ];
            _slot.Remove(s);
            _nonVisited.Remove(s);

            List<Slot> linksNonVisited = new List<Slot>();


            foreach ( var l in s.links ) {      //La cosa es que si uno de los links es el final pos haga la conexion con ese y empieze de la lista de no visitados
                 if ( !l.visited ) {
                    linksNonVisited.Add(l);
                }
            }

            if ( linksNonVisited.Count > 0 ) {
                int rnd = Random.Range(0, linksNonVisited.Count - 1);

                s.RemoveWalls(linksNonVisited [ rnd ]);
                s.walkableNext.Add(linksNonVisited [ rnd ]);
                linksNonVisited [ rnd ].visited = true;
                _slot.Add(linksNonVisited [ rnd ]);
                visitedRoute.Add(linksNonVisited [ rnd ]);
                _nonVisited.Remove(linksNonVisited [ rnd ]);
                yield return new WaitForEndOfFrame();

            } else {
                if (_nonVisited.Count > 0)
                foreach ( var slt in visitedRoute ) {
                    if (slt.id == _nonVisited [ 0 ].id - 1) {
                        _slot.Add(_nonVisited [ 0 ]);
                        slt.RemoveWalls(_nonVisited [ 0 ]);
                        _nonVisited[0].visited = true;
                    }
                }
            }
            Debug.Log(_nonVisited.Count);
            Debug.Log(_slot.Count + " slots");

        }

        Debug.Log("Done ;)");
        foreach ( var item in MazeManager.maze )
            item.visited = false;
        MazeManager.instance.DoneDFS();

        yield return new WaitForEndOfFrame();


    }
}
