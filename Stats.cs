using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Stats
    {
        private Trect board = new Trect(0, 0, 26, 19, ConsoleColor.Yellow);
        private int bossHealth;
        private int timeLeft;
        private int health;
        private int points;

        public Stats() 
        {
            bossHealth = 12;
            timeLeft = 120;
            health = 100;
            points= 10;

        }
         public int GetBossHealth() { return bossHealth; }

        public int GetTimeLeft() { return timeLeft; }
        public int GetHealth() { return health; }
        public int GetPoints() { return points; }
        public void SetBossHealth (int health) { this.bossHealth = health; }
        public void SetTimeLeft(int time ) { timeLeft = time; }
        public void SetHealth(int health ) { this.health= health; }
        public void SetPoints(int points ) { this.points = points; }
       
        
        private void OutLine(ConsoleColor color, ConsoleColor green, int bossH, int playerH)
        {
            Console.ForegroundColor = color;
          
            board.Draw();
            for (int i = 0; i < 19; i = i + 1)
            {
                Console.SetCursorPosition(2, i);
                Console.ForegroundColor = green;
                switch (i)
                {
                    case 1: Console.WriteLine("======================"); break;
                    case 2: Console.WriteLine("Time Left: " + this.timeLeft); break;
                    case 4: Console.WriteLine("Your Health (" + this.health + "): "); Console.SetCursorPosition(2, 5);
                            for (int j = 0; j < playerH/10; j++)
                          {
                            Console.Write("█");
                           }
                        if (this.health < 10) { Console.Write("|" + " "); };
                        break;
                   case 7: Console.WriteLine("Boss's Health: "); Console.SetCursorPosition(2, 8); 
                        for(int g =0; g<bossH; g++)
                            {
                            Console.Write("█");
                            }
                        break;
                    case 10: Console.WriteLine("Point: " + this.points + " ");  break;
                    case 12: Console.WriteLine("TOUCH THE GREEN FOR"); break;
                    case 13: Console.WriteLine("POINTS!"); break;
                    case 15: Console.WriteLine("SHOOT WITH SPACEBAR TO"); break;
                    case 16: Console.WriteLine("KILL ENEMIES!"); break;
                    case 17 : Console.WriteLine("======================"); break;
                        
                    default: break;
                }


            }
          

        }

        public void Draw()
        {
            OutLine(ConsoleColor.Yellow, ConsoleColor.Cyan, bossHealth, health);
            Console.BackgroundColor= ConsoleColor.Black;
        }
        public void Undraw()
        {
            OutLine(ConsoleColor.Black, ConsoleColor.Black,12,100); 
        }

    }
}
