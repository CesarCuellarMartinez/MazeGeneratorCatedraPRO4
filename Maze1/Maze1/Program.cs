using Maze1.Entities;
using Maze1.Scenes;
using Maze1.Games;
using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Maze1
{
    class Program
    {
        static void agregar(int n)
        {
            n += 10;
        }
        static void Main(string[] args)
        {

            int num = 10;
            Program.agregar(num);
            Game game = new Game("My first Otter Game", 800, 600, 60, false);
            game.Color = Color.White;
            Global.PlayerOne = game.AddSession("P1");
            Global.PlayerOne.Controller.AddButton("Left");
            Global.PlayerOne.Controller.Button("Left").AddKey(Key.Left);
            Global.PlayerOne.Controller.AddButton("Right");
            Global.PlayerOne.Controller.Button("Right").AddKey(Key.Right);
            Global.PlayerOne.Controller.AddButton("Up");
            Global.PlayerOne.Controller.Button("Up").AddKey(Key.Up);
            Global.PlayerOne.Controller.AddButton("Down");
            Global.PlayerOne.Controller.Button("Down").AddKey(Key.Down);
            Global.PlayerTwo = game.AddSession("P2");
            Global.PlayerTwo.Controller.AddButton("Left");
            Global.PlayerTwo.Controller.Button("Left").AddKey(Key.A);
            Global.PlayerTwo.Controller.AddButton("Right");
            Global.PlayerTwo.Controller.Button("Right").AddKey(Key.D);
            Global.PlayerTwo.Controller.AddButton("Up");
            Global.PlayerTwo.Controller.Button("Up").AddKey(Key.W);
            Global.PlayerTwo.Controller.AddButton("Down");
            Global.PlayerTwo.Controller.Button("Down").AddKey(Key.S);
            
            Player p1 = new Player(Global.PlayerOne, 25 + 2, 25 + 2);
            Player p2 = new Player(Global.PlayerTwo, 25 + 2, 25 + 2);
            
            int x, y,w,h,ox,oy;
            x = 20;
            y = 20;
            w = 2;
            h = 16;
            ox = 25;
            oy = 25;
            Cell[,] celdas= new Cell[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    celdas[i, j] = new Cell(ox+(i*h)-(i*w),oy+(j*h)-(j*w), "Cell["+i.ToString()+","+j.ToString()+"]",i,j);
                    // Console.WriteLine("Celda[" + i + "," + j + "]: x=" + celdas[i, j].x + ", y=" + celdas[i, j].y);
                    
                 /*   foreach (Wall wall in celdas[i, j].getWalls())
                    {
                        sc.Add(ref wall);
                    }*/
                }
            }
            Gameplay sc = new Gameplay(celdas, p1,p2);
            //sc.Add(ref p1);
            //sc.Add(ref p2);
            game.AddScene(sc);
            Console.WriteLine("Juego Iniciado: " +num);
            game.Start();
            
            
            //sc.algoritmo();
           // game.AddScene(sc);
        }
    }
}
