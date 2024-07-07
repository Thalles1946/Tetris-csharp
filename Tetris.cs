using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Tetris
    {

        int[,] map = new int[10, 10] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

        Random rng = new Random();
            bool game = true;
        public Tetris()
        {


            while (game)
            {
                tickExec();
                play();
                winValdiation();
            }
        }

        private void winValdiation()
        {
            for (int i = 0; i < 10; i++)
            {

                if (map[0, i] == 1)
                {
                    Console.WriteLine("Fim de jogo");
                    game = false;
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
                    tInvertido();
                    break;
                case 2:
                    canto();
                    break;
                default:
                    break;
            }
        }


        private void tInvertido()
        {
            int tick = 0;

            int descend = 0;
            bool end = false;
            while (!end)
            {
                tick++;
                if (tick == 270000000)
                {
                    map[0 + descend, 4] = 1;
                    map[1 + descend, 3] = 1;
                    map[1 + descend, 4] = 1;
                    map[1 + descend, 5] = 1;

                    tickExec();
                    if (1 + descend == 9 || map[2 + descend, 4] == 1)
                    {
                        end = true;
                        break;
                    }
                    map[0 + descend, 4] = 0;
                    map[1 + descend, 3] = 0;
                    map[1 + descend, 4] = 0;
                    map[1 + descend, 5] = 0;
                    descend++;
                    tick = 0;
                }
            }
        }

        private void canto()
        {
            int tick = 0;

            int descend = 0;
            bool end = false;
            while (!end)
            {
                tick++;
                if (tick == 270000000)
                {
                    map[0 + descend, 1] = 1;
                    map[0 + descend, 2] = 1;
                    map[1 + descend, 2] = 1;

                    tickExec();
                    if (1 + descend == 9 || map[2 + descend, 2] == 1)
                    {
                        end = true;
                        break;
                    }
                    map[0 + descend, 1] = 0;
                    map[0 + descend, 2] = 0;
                    map[1 + descend, 2] = 0;
                    descend++;
                    tick = 0;
                }
            }
        }

        private void linha()
        {
            int tick = 0;

            int descend = 0;
            bool end = false;
            while (!end)
            {
                tick++;
                if (tick == 270000000)
                {
                    map[0 + descend, 0] = 1;
                    map[1 + descend, 0] = 1;
                    map[2 + descend, 0] = 1;

                    tickExec();
                    if (2 + descend == 9 || map[3 + descend, 0] == 1)
                    {
                        end = true;
                        break;
                    }
                    map[0 + descend, 0] = 0;
                    map[1 + descend, 0] = 0;
                    map[2 + descend, 0] = 0;
                    descend++;
                    tick = 0;
                }
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

                    if (map[i, j] == 0)
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
