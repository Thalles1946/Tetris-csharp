using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Tetris
    {

        int[,] map = new int[10, 10] { { 0,0,0, 0, 0, 0, 0, 0, 0, 0}, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0,0,0, 0, 0, 0, 0, 0, 0, 0}, { 0,0,0, 0, 0, 0, 0, 0, 0, 0}, { 0,0,0, 0, 0, 0, 0, 0, 0, 0}, { 0,0,0, 0, 0, 0, 0, 0, 0, 0}, { 0,0,0, 0, 0, 0, 0, 0, 0, 0}, { 0,0,0, 0, 0, 0, 0, 0, 0, 0} };

        Random rng = new Random();
        public Tetris()
        {

            int tick = 0;

            while (true)
            {
                tick++;

                if (tick == 170000000)
                {
                    tickExec();
                    play();
                    tick = 0;
                }
                
            }
        }

        private void play()
        {
            int block = rng.Next(0, 3);


            switch (block)
            {
                case 0:
                    linha();
                    break;
                case 1:
                    Console.WriteLine("t invertido");
                    break;
                case 2:
                    Console.WriteLine("canto");
                    break;
                default:
                    break;
            }
        }

        private void linha()
        {
            int descend = 0;
            bool end = false;
            while (!end)
            {
                map[0 + descend, 0 ] = 1;
                map[1 + descend, 0] = 1;
                map[2 + descend, 0] = 1;

                tickExec();
                if (2+descend==9 || map[3 + descend, 0] ==1)
                {
                    end = true;
                    break;
                }
                map[0 + descend, 0] = 0;
                map[1 + descend, 0] = 0;
                map[2 + descend, 0] = 0;
                descend++;

            }
        }

        private void tickExec()
        {
            Console.Clear();
            Console.WriteLine(mapPrinter());
        }

        private string mapPrinter()
        {
            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < 10; i++)
            {

                for (int j = 0; j < 10; j++)
                {

                    if (map[i,j] == 0)
                    {
                        sb.Append("░");
                    }
                    else
                    {
                        sb.Append("█");
                    }

                }
                    sb.AppendLine();

            }

            return sb.ToString();
        }


    
    }


    

}
