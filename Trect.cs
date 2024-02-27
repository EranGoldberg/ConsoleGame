using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Trect
    {
            private int x;
            private int y;
            private double width;
            private double height;
            private ConsoleColor Fcolor;

            public Trect(int x, int y, double width, double height, ConsoleColor Fcolor)
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
                this.Fcolor = Fcolor;
            }

            public int GetX()
            {
                return this.x;
            }
            public int GetY()
            {
                return this.y;
            }
            public double GetWidth()
            {
                return this.width;
            }
            public double GetHeight()
            {
                return this.height;
            }
            public ConsoleColor GetColor()
            {
                return this.Fcolor;
            }
            public void SetX(int x)
            {
                this.x = x;
            }
            public void SetY(int y)
            {
                this.y = y;
            }
            public void SetWidth(double width)
            {
                this.width = width;
            }

            public void SetColor(ConsoleColor Fcolor)
            {
                this.Fcolor = Fcolor;
            }
            public void SetHeigth(double height)
            {
                this.height = height;
            }

            private void DrawRectPath(ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(this.x, this.y);
                int line = this.y;
                int width = (int)this.width;
                int height = (int)this.height;
                if (width > 0 && height > 0)
                {
                    Console.Write('╔');
                    for (int i = 1; i < width - 1; i++)
                    {
                        Console.Write('═');
                    }
                    if (this.width >= 2)
                    {
                        Console.Write('╗');

                    }
                    for (int i = 1; i < height - 1; i++)
                    {
                        line++;
                        Console.SetCursorPosition(this.x, line);
                        Console.Write('║');
                        Console.SetCursorPosition(this.x + width - 1, line);
                        Console.Write('║');
                    }
                    if (height >= 2)
                    {
                        line++;
                        Console.SetCursorPosition(this.x, line);
                        Console.Write('╚');
                        for (int i = 1; i < width - 1; i++)
                        {
                            Console.Write('═');
                        }
                        if (width >= 2)
                        {
                            Console.Write('╝');
                        }
                    }


                }

            }

            public void Draw()
            {
                DrawRectPath(this.Fcolor);
            Console.BackgroundColor = ConsoleColor.Black;

            }
            public void UnDraw()
            {
                DrawRectPath(ConsoleColor.Black);
            }

        }
    }
