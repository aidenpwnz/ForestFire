using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOREST_FIRE
{
    class Forest
    {
        public void Show()
        {
            const int AxisX = 21;

            const int AxisY = 21;

            bool exit = false;
            

            Cell[,] cell = new Cell[AxisX, AxisY];
            
            
            Perimeter();

            for (int x = 0; x < AxisX; x++)
            {
                Corner();

                for (int y = 0; y < AxisY; y++)
                {
                    cell[x, y] = new Cell(1, 0, 0, 0); // tree // burning // empty // ignited
                    cell[x, y].Show(cell[x, y].TreeStatus);
                }

                Corner();

                Console.WriteLine();
            }

            Perimeter();

            Console.ReadKey();

            Console.Clear();

            cell[10, 10].Ignite = 1;
            



            while (!exit)
            {
                Perimeter();

                for (int x = 0; x < AxisX; x++)
                {
                    Corner();

                    for (int y = 0; y < AxisY; y++)
                    {
                        cell[x, y].Show(cell[x, y].TreeStatus);
                    }

                    Corner();

                    Console.WriteLine();

                }

                Perimeter();

                Console.ReadKey();

                Console.Clear();


                for (int x = 0; x < AxisX; x++)
                {

                    for (int y = 0; y < AxisY; y++)
                    {
                        
                        if (cell[x, y].Burning == 1)
                        {


                            if (y - 1 >= 0 && cell[x, y - 1].Burning == 0 && cell[x, y - 1].Ignite == 0 && cell[x, y - 1].Empty == 0)
                            {
                                FireChance(cell[x, y - 1]);
                            }
                            

                            if (y + 1 < AxisY && cell[x, y + 1].Burning == 0 && cell[x, y + 1].Ignite == 0 && cell[x, y + 1].Empty == 0)
                            {
                                FireChance(cell[x, y + 1]);
                            }


                            if (x - 1 >= 0 && cell[x - 1, y].Burning == 0 && cell[x - 1, y].Ignite == 0 && cell[x - 1, y].Empty == 0)
                            {
                                FireChance(cell[x - 1, y]);
                            }

                            if (x + 1 < AxisX && cell[x + 1, y].Burning == 0 && cell[x + 1, y].Ignite == 0 && cell[x + 1, y].Empty == 0)
                            {
                                FireChance(cell[x + 1, y]);
                            }



                            TurnEmpty(cell[x, y]);

                        }


                        if (cell[x, y].Ignite == 1)
                        {

                            Burn(cell[x, y]);

                        }

                        
                    }
                }
            }
        }

        public void Burn(Cell burn)
        {
            burn.Burning = 1;
            burn.Ignite = 0;
            burn.Empty = 0;
            burn.TreeStatus = '*';
           
        }

        public void TurnEmpty(Cell emp)
        {

            emp.Empty = 1;
            emp.Burning = 0;
            emp.Ignite = 0;
            emp.TreeStatus = '.';
        }
        
        public void Perimeter()
        {
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - -");
        }

        public void Corner()
        {
            Console.Write("- ");
        }

        Random random = new Random();
        public void FireChance(Cell ign)
        {            
            int ran = random.Next(0, 100); //also calculates min -1 and max +1?

            if (ran <= 50)
            {
                ign.Ignite = 1;
                
                
            }
        }

    }
}



    
