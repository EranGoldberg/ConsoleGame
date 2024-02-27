using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class MTP
    {
        private int x;
        private int y;
        private char ch;
        private ConsoleColor Fcolor;
        private ConsoleColor Bcolor;
        private int direction;
        private int speed;

        Random rnd = new Random();
        public MTP(int x, int y, char ch, ConsoleColor fcolor, ConsoleColor bcolor, int speed)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
            Fcolor = fcolor;
            Bcolor = bcolor;
            this.direction = rnd.Next(1, 9);
            this.speed = speed;
        }

        public int GetX() { return x; }
        public int GetY() { return y; }
        public char GetChar() { return ch; }
        public int GetDirection() { return direction; }
        public int GetSpeed() { return speed; }
        public ConsoleColor GetFcolor() { return Fcolor; }
        public ConsoleColor GetBcolor() { return Bcolor; }
        public void SetX(int x) { this.x = x; }
        public void SetY(int y) { this.y = y; }
        public void SetChar(char ch) { this.ch = ch; }
        public void SetFcolor(ConsoleColor Fcolor) { this.Fcolor = Fcolor; }
        public void SetBcolor(ConsoleColor Bcolor) { this.Bcolor = Bcolor; }

        public void SetDirection(int direction) { this.direction = direction; }
        public void SetSpeed(int speed) { this.speed = speed; }

        public void Draw()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.BackgroundColor = this.Bcolor;
            Console.ForegroundColor = this.Fcolor;
            Console.Write(this.ch);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void UnDraw()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(this.ch);
        }

        public void OppisiteDirection()
        {
            this.direction = (this.direction + 4) % 8;
        }
        public void MoveRight()
        {
            if (this.speed + this.x < 115)
                SetX(this.speed + this.x);
            else OppisiteDirection();
        }

        public void MoveLeft()
        {
            if (this.x - this.speed > 26)
                SetX(this.x - this.speed);
            else OppisiteDirection();
        }

        public void MoveDown()
        {
            if (this.speed + this.y < 34)
                SetY(this.speed + this.y);
            else OppisiteDirection();

        }

        public void MoveUp()
        {
            if (this.y - this.speed > 0)
                SetY(this.y - this.speed);
            else OppisiteDirection();
        }

        public void MoveUpRight()
        {
            MoveUp();
            MoveRight();
        }

        public void MoveUpLeft()
        {
            MoveUp();
            MoveLeft();
        }

        public void MoveDownRight()
        {
            MoveRight();
            MoveDown();
        }

        public void MoveDownLeft()
        {
            MoveDown();
            MoveLeft();
        }

        public void MoveOneStep()
        {

          
            
                switch (this.direction)
                {
                    case 1: MoveUp(); break;
                    case 2: MoveUpRight(); break;
                    case 3: MoveRight(); break;
                    case 4: MoveDownRight(); break;
                    case 5: MoveDown(); break;
                    case 6: MoveDownLeft(); break;
                    case 7: MoveLeft(); break;
                    case 8: MoveUpLeft(); break;

                }
                        
        }

        public void RndMove()
        {
          
            
                this.direction = rnd.Next(1, 9);
                MoveOneStep();
           
        }

        public void LessRndMove()
        {
            if(rnd.Next(1,5)==2)
            {
               RndMove();
            }
            else
            {
                
                MoveOneStep();
            }

        }

    }
}
