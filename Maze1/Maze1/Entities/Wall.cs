using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze1.Entities
{
    class Wall:Entity
    {
        public bool estado;
        public Wall(float x, float y, int w, int h):base(x,y) {
            estado = true;
            Image img = Image.CreateRectangle(w,h,Color.Black);
            SetHitbox(w, h, (int)Tags.Wall);
            AddGraphic(img);
        }
        public override void Update()
        {
            base.Update();
            var cOne=  Collider.Collide(X, Y, (int)Tags.PlayerOne);
            if (cOne!=null)
            {
                estado = false;
                RemoveSelf();
            }

        }
        public override void Render()
        {
            base.Render();
            //Collider.Render();
            //Descomentar la siguiente linea para ver la colicion
            //collider.Render();
        }
    }
}
