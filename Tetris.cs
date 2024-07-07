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
            ConsoleKeyInfo arrow;

            int lado = 0;
            int descend = 0;
            bool end = false;
            while (!end)
            {
                
                    map[0 + descend, 4+lado] = 1;
                    map[1 + descend, 3 + lado] = 1;
                    map[1 + descend, 4 + lado] = 1;
                    map[1 + descend, 5 + lado] = 1;

                    tickExec();
                    if (1 + descend == 9 || map[2 + descend, 4 + lado] == 1 || map[2 + descend, 3 + lado] == 1 || map[2 + descend, 5 + lado] == 1)
                    {
                        end = true;
                        break;
                    }
                    map[0 + descend, 4 + lado] = 0;
                    map[1 + descend, 3 + lado] = 0;
                    map[1 + descend, 4 + lado] = 0;
                    map[1 + descend, 5 + lado] = 0;
                    descend++;
                    arrow = Console.ReadKey();

                    if (2 + lado != 9 && 3 + lado != 0)
                    {
                        switch (arrow.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                lado--;
                                break;
                            case ConsoleKey.RightArrow:
                                lado++;
                                break;
                        }
                    }
            }
        }

        private void canto()
        {
            ConsoleKeyInfo arrow;

            int lado = 0;
            int descend = 0;
            bool end = false;
            while (!end)
            {
                
                    map[0 + descend, 1+lado] = 1;
                    map[0 + descend, 2 + lado] = 1;
                    map[1 + descend, 2 + lado] = 1;

                    tickExec();
                    if (1 + descend == 9 || map[2 + descend, 2 + lado] == 1 || map[1 + descend, 1 + lado] == 1)
                    {
                        end = true;
                        break;
                    }
                    map[0 + descend, 1 + lado] = 0;
                    map[0 + descend, 2 + lado] = 0;
                    map[1 + descend, 2 + lado] = 0;
                    descend++;
                    arrow = Console.ReadKey();

                    if (2 + lado != 9 && 2 + lado != 0)
                    {
                        switch (arrow.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                lado--;
                                break;
                            case ConsoleKey.RightArrow:
                                lado++;
                                break;
                        }
                    }
                


            }
        }

        private void linha()
        {
            int lado = 0;
            ConsoleKeyInfo arrow;

            int descend = 0;
            bool end = false;
            while (!end)
            {
             
                    map[0 + descend, 0+lado] = 1;
                    map[1 + descend, 0 + lado] = 1;
                    map[2 + descend, 0 + lado] = 1;

                    tickExec();
                    if (2 + descend == 9 || map[3 + descend, 0 + lado] == 1)
                    {
                        end = true;
                        break;
                    }
                    map[0 + descend, 0 + lado] = 0;
                    map[1 + descend, 0 + lado] = 0;
                    map[2 + descend, 0 + lado] = 0;
                    descend++;
                    arrow = Console.ReadKey();

                    if (2 + lado != 9 && 2 + lado != 0)
                    {
                        switch (arrow.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                lado--;
                                break;
                            case ConsoleKey.RightArrow:
                                lado++;
                                break;
                        }
                    }
            }
        }

        private void tickExec()
        {
            Console.Clear();
            Console.WriteLine(mapPrinter());
        }

        private void lineDelete(int line)
        {
            for (int i = 0; i < 10; i++)
            {

                map[line, i] = 0;
                
            }

            for (int i = line; i > -1; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i - 1 > -1)
                    {

                    map[i, j] = map[i - 1, j];
                    }
                }
            }

        }

        private string mapPrinter()
        {
            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < 10; i++)
            {
                int counter = 0;
                for (int j = 0; j < 10; j++)
                {

                    if (map[i, j] == 0)
                    {
                        sb.Append("░");
                    }
                    else
                    {

                        sb.Append("█");
                        counter++;
                    }

                   

                }
                if (counter == 10)
                {
                    lineDelete(i);
                }

                sb.AppendLine();

            }

            return sb.ToString();
        }



    }




}
