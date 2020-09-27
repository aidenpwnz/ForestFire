using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOREST_FIRE
{
    public class Cell
    {

        public int TreeStatus = 0;

        //public string ShowStatus;

        public int Burning = 0; // 0 = normal tree // 1 = burning

        public int Empty = 0;

        public int Ignite = 0;

        /// <summary>
        /// (status : int, BurnStatus : int, EmptyStatus : int, Ignited : int)
        /// </summary>
        public Cell(int status, int BurnStatus, int EmptyStatus, int Ignited)
        {
            TreeStatus = status;
            Burning = BurnStatus;
            Empty = EmptyStatus;
            Ignite = Ignited;
        }



        public void Show(int status)
        {
            if (Burning == 1)
            {
                Console.Write("* ");
            }
            if (Empty == 1)
            {
                Console.Write(". ");
            }
            else
            {
                switch (status)
                {
                    case 0:
                        Console.Write(". ");  //empty
                        break;
                    case 1:
                        Console.Write("& ");  //tree
                        break;
                    case 2:
                        Console.Write("* ");  //burning
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}
