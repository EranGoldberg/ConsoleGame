using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class BigMTP
    {
        Random  rnd = new Random();
        private MTP mtp1 = new MTP(50, 30, '■', ConsoleColor.DarkRed, ConsoleColor.DarkYellow, 2);  // 56
        private MTP mtp2 = new MTP(51, 30, '█', ConsoleColor.DarkGray, ConsoleColor.DarkYellow, 2);  //1234
        private MTP mtp3 = new MTP(52, 30, '█', ConsoleColor.DarkGray, ConsoleColor.DarkYellow, 2);
        private MTP mtp4 = new MTP(53, 30, '■', ConsoleColor.DarkRed, ConsoleColor.DarkYellow, 2);
        private MTP mtp5 = new MTP(51, 29, '■', ConsoleColor.DarkRed, ConsoleColor.DarkYellow, 2);
        private MTP mtp6 = new MTP(52, 29, '■', ConsoleColor.DarkRed, ConsoleColor.DarkYellow, 2);
        private ConsoleColor Fcolor;
        private ConsoleColor Bcolor;
        private int health;
        

        public BigMTP()
        {
            this.mtp1 = mtp1;
            this.mtp2 = mtp2;
            this.mtp3 = mtp3;
            this.mtp4 = mtp4;
            this.mtp5 = mtp5;    
            this.mtp6 = mtp6;
            this.health = 4;
            
        }

        public int GetHealth() { return health; }
        public void SetHealth(int health) { this.health= health; }
        public ConsoleColor GetBcolor()
        {
            return mtp1.GetBcolor();
        }
        public void SetBcolor(ConsoleColor color)
        {
            mtp1.SetBcolor(color);
            mtp2.SetBcolor(color);
            mtp3.SetBcolor(color);
            mtp4.SetBcolor(color);
            mtp5.SetBcolor(color);
            mtp6.SetBcolor(color);
            
        }
        public ConsoleColor GetFcolor()
        {
            return mtp1.GetFcolor();
        }
        public void SetFolor(ConsoleColor color)
        {
            mtp1.SetFcolor(color);
            mtp2.SetFcolor(color);
            mtp3.SetFcolor(color);
            mtp4.SetFcolor(color);
            mtp5.SetFcolor(color);
            mtp6.SetFcolor(color);

        }

        public MTP GetM1()
        {
            return mtp1;
        }
        public MTP GetM2()
        {
            return mtp2;
        }

        public MTP GetM3()
        {
            return mtp3;
        }

        public MTP GetM4()
        {
            return mtp4;

        }

        public MTP GetM5()
        {
            return mtp5;
        }

        public MTP GetM6()
        {
            return mtp6;
        }
        public int GetX6()
        {
           
            return mtp6.GetX();
        }
        public int GetX5()
        {
            return mtp5.GetX();
        }

        public int GetX4()
        {
            return mtp4.GetX();
        }
        public int GetX3()
        {
            return mtp3.GetX();
        }
        public int GetX2()
        {
            return mtp2.GetX();
        }
        public int GetX1()
        {
            return mtp1.GetX();
        }
        public int GetY6()
        {
            return mtp6.GetY();
          
        }
        public int GetY1()
        {
            return mtp1.GetY();
        }

        public void SetX(int num)
        {
            mtp1.SetX(num);
            mtp2.SetX(num+1);
            mtp3.SetX(num+2);
            mtp4.SetX(num+3);
            mtp5.SetX(num+1);
            mtp6.SetX(num+2);
        }
         
        public void SetY(int num)
        {
            mtp1.SetY(num);
            mtp2.SetY(num);
            mtp3.SetY(num);
            mtp4.SetY(num);
            mtp5.SetY(num-1);
            mtp6.SetY(num-1);

        }

    
        public void MoveRight()
        {
            if (mtp4.GetX() +mtp4.GetSpeed() < 115)
            {
                mtp1.MoveRight();
                mtp2.MoveRight();
                mtp3.MoveRight();
                mtp4.MoveRight();
                mtp5.MoveRight();
                mtp6.MoveRight();
            }
            else
            {
                mtp1.MoveLeft();
                mtp2.MoveLeft();
                mtp3.MoveLeft();
                mtp4.MoveLeft();
                mtp5.MoveLeft();
                mtp6.MoveLeft();
            }
            
        }
        public void MoveLeft()
        {
            if (mtp1.GetX() + mtp1.GetSpeed() > 30)
            {
                mtp1.MoveLeft();
                mtp2.MoveLeft();
                mtp3.MoveLeft();
                mtp4.MoveLeft();
                mtp5.MoveLeft();
                mtp6.MoveLeft();

            }
           else
            {
                mtp1.MoveRight();
                mtp2.MoveRight();
                mtp3.MoveRight();
                mtp4.MoveRight();
                mtp5.MoveRight();
             mtp6.MoveRight();
           }
          
        }

        public void MoveUp()
        {
            if (mtp6.GetY() + mtp6.GetSpeed() > 2)
            {
                mtp1.MoveUp();
                mtp2.MoveUp();
                mtp3.MoveUp();
                mtp4.MoveUp();
                mtp5.MoveUp();
                mtp6.MoveUp();
            }
            else 
            { 
            mtp1.MoveDown();
            mtp2.MoveDown();
            mtp3.MoveDown();
            mtp4.MoveDown();
            mtp5.MoveDown();
            mtp6.MoveDown();
            }
           
        }

        public void MoveDown()
        {
            if(mtp4.GetY()+mtp4.GetSpeed() <34)
            {
                mtp1.MoveDown();
                mtp2.MoveDown();
                mtp3.MoveDown(); 
                mtp4.MoveDown() ;
                mtp5.MoveDown();
                mtp6.MoveDown();
                    
            }
            else
            {
                mtp1.MoveUp();
                mtp2.MoveUp();
                mtp3.MoveUp();
                mtp4.MoveUp();
                mtp5.MoveUp();
                mtp6.MoveUp();
            }
            
        }

        public void MoveOneStep()
        {
         
          switch(mtp1.GetDirection()) 
            { 
                case 1: MoveUp(); break;
                case 2: MoveDown(); break;
                case 3: MoveRight(); break;
                case 4: MoveRight(); break;
                case 5: MoveDown(); break;
                case 7: MoveLeft(); break;
                case 8: MoveLeft(); break;
            }
        }
        public void RndMove()
        {
            if(rnd.Next(1, 3) == 2)
            {
                mtp1.SetDirection(rnd.Next(1, 9));
                
            }
            MoveOneStep();
        }

        public void Draw()
        {
            mtp1.Draw();
            mtp2.Draw();
            mtp3.Draw();
            mtp4.Draw();
            mtp5.Draw();
            mtp6.Draw();
        }
        public void UnDraw()
        {
            mtp1.UnDraw();
            mtp2.UnDraw();
            mtp3.UnDraw();
            mtp4.UnDraw();
            mtp5.UnDraw();
            mtp6.UnDraw();
        }


    }
}                
             