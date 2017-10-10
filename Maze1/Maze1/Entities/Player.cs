using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;
namespace Maze1.Entities
{
    class Player : Entity
    {
        Session player;
        int lastKey = 0;
        float speed = 1f;

        //BoxCollider hitbox = new BoxCollider(12, 12, (int)Tags.Player);
        public Player(Session player, float x, float y) : base(x, y)
        {
            this.player = player;
            
            Image image;
            if (player.Id==0)
            {
                //El verdadero, uso el otro para mientras que el algoritmo no esta completo
                /*image = Image.CreateRectangle(12, 12, Color.Green);
                SetHitbox(12, 12, (int)Tags.PlayerOne);*/
                image = Image.CreateRectangle(6, 6, Color.Green);
                SetHitbox(6, 6, (int)Tags.PlayerOne);


            }
            else
            {
                //BoxCollider hitbox = new BoxCollider(6, 6, (int)Tags.PlayerTwo);
                image = Image.CreateRectangle(6, 6, Color.Blue);
                SetHitbox(6, 6, (int)Tags.PlayerTwo);
            }
            AddGraphic(image);

        }
        public override void Update()
        {
            base.Update();
            //Console.WriteLine(player.Id);
            var c = Collider.Collide(X, Y, (int)Tags.Wall);
            if (c != null && player.Id==1)
            {
                switch (lastKey)
                {
                    case 1:
                        X += 1f;
                        break;
                    case 2:
                        X -= 1f;
                        break;
                    case 3:
                        Y += 1f;
                        break;
                    case 4:
                        Y -= 1f;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                lastKey = 0;
                if (player.Controller.Button("Left").Down)
                {
                    X -= speed;
                    lastKey = 1;
                }
                if (player.Controller.Button("Right").Down)
                {
                    lastKey = 2;
                    X += speed;
                }
                if (player.Controller.Button("Up").Down)
                {
                    lastKey = 3;
                    Y -= speed;
                }
                if (player.Controller.Button("Down").Down)
                {
                    lastKey = 4;
                    Y += speed;
                }
            }
        }
        public void moverprr() {
            Y += 14;
        }
        public override void Render()
        {
            base.Render();
            Collider.Render();
        }
    }
}
