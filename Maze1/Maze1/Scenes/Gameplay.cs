using Otter;
using Maze1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace Maze1.Scenes
{
    class Gameplay : Scene
    {
        //Jugadores
        public Player p1;
        public Player p2;
        //Bandera cuando se complete el laberinto pasara a true
        public bool finalizado = false;
        //Celda actual del algoritmo backtraking(la que se le busca vecinos)
        Cell current;
        //Pila del algoritmo
        Stack<Cell> pila = new Stack<Cell>();
        //Arreglo de celdas
        Cell[,] celdas;
        //Estas son para probar modo desarrollo
        int i = 0,k=0;
        //Constructor se agregan los jugadores y se dibujan las celdas
        public Gameplay(Cell[,] c, Player uno, Player dos)
        {
            
            celdas = c;
            p1 = uno;
            p2 = dos;
            
            Dibujar();
            //La primera celda se toma como la actual para iniciar el algoritmo
            current = celdas[0, 0];
            //Se marca como visitada
            celdas[current.i, current.j].visitar();
            //Se cambia el color de actual(gris)
            celdas[current.i, current.j].actual();
        }
        //Metodo para remover las celdas dentro de la entidad gameplay(scene o escena)
        public void Limpiar()
        {
            foreach (Cell celda in celdas)
            {
                Remove(celda.left);
                Remove(celda.rigth);
                Remove(celda.top);
                Remove(celda.bottom);

            }
        }
        //Metodo que dibuja las paredes de cada celda segun su estado(si existe o no)
        public void Dibujar()
        {
            
            foreach (Cell celda in celdas)
            {
                if (celda.left.estado)
                {
                    Add(ref celda.left);
                }
                if (celda.rigth.estado)
                {
                    Add(ref celda.rigth);
                }
                if (celda.top.estado)
                {
                    Add(ref celda.top);
                }
                if (celda.bottom.estado)
                {
                    Add(ref celda.bottom);
                }
                Add(ref celda.fondo);
            }

        }
        //Metodo que comprueba con una posicion dada
        //si una celda existe(retorna true), si no existe o ya ha sido visitada(retorna false)
        public bool existeNoVisitado(int i, int j)
        {
            try
            {
                string value = celdas[i, j].value;
                return !celdas[i, j].visitado;
            }
            catch 
            {

                return false;
            }
        }
        //Metodo para encontrar de forma aleatoria
        //Un vecino de la celda actual que no ha sido visitado
        public Cell encontrarVecino() {
            List<Cell> vecinos = new List<Cell>();
            //Vecino de arriba
            if (existeNoVisitado(current.i, current.j-1))
            {
                vecinos.Add(celdas[current.i, current.j - 1]);
            }
            //Vecino de la derecha
            if (existeNoVisitado(current.i+1, current.j))
            {
                vecinos.Add(celdas[current.i + 1, current.j]);
            }
            //Vecino de abajo
            if (existeNoVisitado(current.i, current.j + 1))
            {
                vecinos.Add(celdas[current.i, current.j + 1]);
            }
            //Vecino de la izquida
            if (existeNoVisitado(current.i-1, current.j))
            {
                vecinos.Add(celdas[current.i-1, current.j]);
            }
            if (vecinos.Count>0)
            {
                Random rnd = new Random();
                int r = rnd.Next(0,vecinos.Count);
                return vecinos.ElementAt(r);
            }
            else
            {
                return null;
            }
            
        }
        //Metodo para remover pared
        public void removerPared(Cell a, Cell b){
            int x = a.i - b.i;
            if (x==1)
            {
                celdas[a.i, a.j].left.estado = false;
                celdas[b.i, b.j].rigth.estado = false;
            }
            else if(x==-1)
            {
                celdas[a.i, a.j].rigth.estado = false;
                celdas[b.i, b.j].left.estado = false;
            }
            int y = a.j - b.j;
            if (y == 1)
            {
                celdas[a.i, a.j].top.estado = false;
                celdas[b.i, b.j].bottom.estado = false;
            }
            else if (y == -1)
            {
                celdas[a.i, a.j].bottom.estado = false;
                celdas[b.i, b.j].top.estado = false;
            }
        }
        //Metodo de backtracking
        public void backTracking() {        
            //PASO 1    se verifica si existen vecinos no visitados
            Cell siguiente = encontrarVecino();
            if (siguiente != null)
            {

                //PASO 2 se mete la celda actual a la pila
                pila.Push(current);
                //PASO 3 se remueve la pared entre la vecino encotrado y la celda actual
                removerPared(current, siguiente);
                //se quita el color de actual
                celdas[current.i, current.j].noActual();
                //PASO 4 el vecino encontrado sera la celda actual
                //se marca como visitado
                //se cambia el color a actual(gris)
                current = celdas[siguiente.i, siguiente.j];
                celdas[current.i, current.j].visitar();
                celdas[current.i, current.j].actual();
            }
            else if (pila.Count > 0)
            {
                //se quita el color de actual
                celdas[current.i, current.j].noActual();
                //el actual sera el ultimo en la pila
                current = pila.Pop();
                //se cambia el color a actual(no se marca como visitado porque ya se marco al meterse a la pila, ya ha sido actual antes)
                celdas[current.i, current.j].actual();
            }
            else {
                finalizado = true;
                celdas[current.i, current.j].noActual();
                //Add(ref p1);
                Add(ref p2);
            }
            Limpiar();
            Dibujar();
            Game.UpdateScenes();
            //System.Threading.Thread.Sleep(20);
        }
        //Prueba refrescar pantalla
        public void buscarSiguiente()
         {
                base.Update();
                celdas[0, k].left.estado = false;
                Limpiar();
                Dibujar();
                Game.UpdateScenes();
               // Game.SwitchScene(this);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Entro i: " + i);
                k++;
        }
        
        public override void Update()
        {
            Dibujar();
            if (!finalizado)
            {
                if ((i % 2) == 0)
                {
                    Console.WriteLine("Entro i: " + i);
                    backTracking();

                }
                else
                {

                    Console.WriteLine("Entro i: " + i);
                }

                i++;
            }

        }

    }
}
