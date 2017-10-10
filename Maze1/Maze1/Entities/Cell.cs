﻿using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze1.Entities
{
    class Cell
    {
        public string value;
        public bool visitado;
        public Wall left, top, rigth, bottom;
        public int x, y;
        public int i, j;
        public Cell(int xo, int yo, string v,int ii, int jj) {
            value = v;
            visitado = false;
            i = ii;
            j = jj;
            x = xo;
            y = yo;
            left = new Wall(x, y, 2, 16);
            top = new Wall(x, y, 16, 2);
            rigth = new Wall(x+14, y, 2, 16);
            bottom = new Wall(x, y+14, 16, 2);

        }
        public Wall[] getWalls() {
            Wall[] walls = new Wall[4] { left, top, rigth, bottom };
            return walls;
        }
    }
    
}
