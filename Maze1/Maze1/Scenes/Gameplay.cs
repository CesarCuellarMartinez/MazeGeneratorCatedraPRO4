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
        public Player p1;
        public Player p2;
        public bool finalizado = false;
        Cell current;
        Stack<Cell> pila = new Stack<Cell>();
        Cell[,] celdas;
        int i = 0,k=0;
        public Gameplay(Cell[,] c, Player uno, Player dos)
        {
            celdas = c;
            p1 = uno;
            p2 = dos;
            Add(ref p1);
            Add(ref p2);
            Dibujar();
        }
        public void Limpiar()
        {
            foreach (Cell celda in celdas)
            {
                Remove(celda.left);
                Remove(celda.rigth);
                Remove(celda.top);
                Remove(celda.bottom);

            }
           // Game.SwitchScene(this);
        }
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
            }

        }
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
        public void backTracking(Cell actual) {

        }
        public void buscarSiguiente()
         {
                base.Update();
                celdas[0, k].left.estado = false;
                Limpiar();
                Dibujar();
                Game.UpdateScenes();
                Game.SwitchScene(this);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Entro i: " + i);
                k++;
        }
        
        public override void Update()
        {
            if ((i % 2) == 0)
            {
                buscarSiguiente();
            }
            else
            {
                Dibujar();
                Console.WriteLine("Entro i: " + i);
            }
            
            i++;

        }

    }
}
