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

        //hacer todo aca...
        List<Slot> slot = new List<Slot>(); //altok
        List<Slot> visitedRoute = new List<Slot>();  //altok
        slot.Add(start); //altok
        visitedRoute.Add(start);
        start.visited = true; //altok
        List<Slot> nonVisited = new List<Slot>();
        nonVisited = MazeManager.maze;
            
        while ( slot.Count > 0 ) {
            Slot s = slot [ slot.Count - 1 ];
            slot.Remove(s);
            nonVisited.Remove(s);

            List<Slot> linksNonVisited = new List<Slot>();


            foreach ( var _l in s.links ) {
                 if ( !_l.visited ) {
                    linksNonVisited.Add(_l);
                    yield return new WaitForEndOfFrame();
                }
            }
            if ( linksNonVisited.Count > 0 ) {
                int _rnd = Random.Range(0, linksNonVisited.Count);

                s.RemoveWalls(linksNonVisited [ _rnd ]);
                s.walkableNext.Add(linksNonVisited [ _rnd ]);
                linksNonVisited [ _rnd ].visited = true;
                slot.Add(linksNonVisited [ _rnd ]);
                visitedRoute.Add(linksNonVisited [ _rnd ]);
                nonVisited.Remove(linksNonVisited [ _rnd ]);
                yield return new WaitForEndOfFrame();

            } else if ( nonVisited.Count != 0 ) {
                Slot _nvisited = nonVisited [ 0 ];
                Slot _previousNVisited = null;

                foreach ( var _slt in visitedRoute ) {
                    if ( _slt.id == _nvisited.id - 1 ) {
                        _previousNVisited = _slt;
                        yield return new WaitForEndOfFrame();
                        break;
                    }
                }
                slot.Add(_nvisited);
                _nvisited.visited = true;
                nonVisited.Remove(_nvisited);
                visitedRoute.Add(_nvisited);
                yield return new WaitForEndOfFrame();
                foreach ( var linked in _nvisited.links ) {
                    if(linked == _previousNVisited ) {
                _previousNVisited.walkableNext.Add(linked);
                _previousNVisited.RemoveWalls(linked);
                        yield return new WaitForEndOfFrame();

                    }
                    yield return new WaitForEndOfFrame();

                }
                yield return new WaitForEndOfFrame();


            }

       }

        Debug.Log("Done ;)");
        foreach ( var item in MazeManager.maze )
            item.visited = false;
        MazeManager.instance.DoneDFS();

        yield return new WaitForEndOfFrame();


    }
}
