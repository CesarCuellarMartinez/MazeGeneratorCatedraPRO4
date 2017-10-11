using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze1.Entities
{
    class Background:Entity
    {
        public bool estado;
        public Background(float x, float y, Color c):base(x,y) {
            estado = true;
            Image img = Image.CreateRectangle(14, 14,c);
            AddGraphic(img);
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Render()
        {
            base.Render();
        }
    }
}
