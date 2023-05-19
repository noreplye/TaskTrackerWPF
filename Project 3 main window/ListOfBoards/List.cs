using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfBoards
{
    class List
    {
        class Board
        {
            public string data { get; set; }
            public string creater { get; set; }
            public string task { get; set; }
        }
        List<Board> boards = new List<Board>();
    }
}
