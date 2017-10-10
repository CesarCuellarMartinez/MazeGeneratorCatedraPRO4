using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;
namespace Maze1
{
    class Global
    {
        public static Session
            PlayerOne,
            PlayerTwo;
    }
    public enum Tags {
        PlayerOne,
        Wall,
        PlayerTwo
    }
}
