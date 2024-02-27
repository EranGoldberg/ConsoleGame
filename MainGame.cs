using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleGame
{


    internal class MainGame
    {
        //the method gets an MTP and a bool and a stats
        //the method checks and acts accordingly, if MTPs touched
        public static void Touch(MTP playerOrBulletOrBot, MTP targetOrPoint, bool isPlayerOnPoint, bool isPlayerOnTarget, Stats stats)
        {
           if (Math.Abs(playerOrBulletOrBot.GetX() - targetOrPoint.GetX()) <=2  && Math.Abs(playerOrBulletOrBot.GetY() - targetOrPoint.GetY()) <= 2)
           {
                //when player and point touch:
                if (isPlayerOnPoint && targetOrPoint.GetBcolor() != ConsoleColor.Black && playerOrBulletOrBot.GetX() == targetOrPoint.GetX() && playerOrBulletOrBot.GetY() == targetOrPoint.GetY()) 
                {
                    targetOrPoint.SetBcolor(ConsoleColor.Black);
                    stats.SetPoints(stats.GetPoints() + 1); 
                    stats.SetHealth(stats.GetHealth() + 2);
                }
                //when player and target touch:
                else if (isPlayerOnTarget) 
                {
                    stats.SetHealth(stats.GetHealth() - 1);
                    playerOrBulletOrBot.Draw();
                    targetOrPoint.Draw();
                }
           }
           
            
        }
        //the method gets an MTP and bosses (array of BigMTPs)
        //the method checks and acts accordingly, if the player has shot a boss or shot bosses
        public static void CheckBossGun (MTP player, BigMTP [] boss, Stats stats)
        {
            int x = player.GetX();
            int y = player.GetY();
            for (int i=0; i<boss.Length; i++)
            {
                if ((x == boss[i].GetX1()|| x == boss[i].GetX2() ||x== boss[i].GetX3() || x == boss[i].GetX4()) && (boss[i].GetBcolor()!=ConsoleColor.Black && boss[i].GetY1()<=y))
                {
                    boss[i].SetHealth(boss[i].GetHealth() - 1);
                    stats.SetBossHealth( stats.GetBossHealth() - 1);
                    boss[i].UnDraw();
                    Thread.Sleep(100);
                    boss[i].Draw();
                    Thread.Sleep(100);
                    boss[i].UnDraw();
                    Thread.Sleep(100);
                    boss[i].UnDraw();


                    //checks to see if boss is dead; and makes him black if so:
                    if (boss[i].GetHealth()==0)
                    {
                        boss[i].SetBcolor(ConsoleColor.Black); boss[i].SetFolor(ConsoleColor.Black);
                    }
                }
            }
        }
        //the method get an MTP (a gun), and two other MTPs (a point and a target or a player), and stats
        //the method creates bullet animation and checks and acts accordingly if a bullet touched a point or target
        public static void Shoot(MTP gun, MTP point, MTP target  ,Stats stats)
        {
            int startY = gun.GetY();
            bool touchedPoint = false;
            for (int i = startY; i > 0; i--)
            {
                gun.SetY(i);
                
                //when bullet touched target:
                if(target.GetX()==gun.GetX() && target.GetBcolor()!=ConsoleColor.Black)
                {
                    target.Draw();
                    ConsoleColor priorBColor =target.GetBcolor();
                    ConsoleColor priorFColor = target.GetFcolor();
                    target.SetBcolor(ConsoleColor.White);
                    target.Draw();
                    Thread.Sleep(80);
                    target.SetBcolor(priorBColor); 
                    target.SetFcolor(priorFColor);
                    if (target.GetBcolor() != ConsoleColor.Blue)
                    {
                        stats.SetPoints(stats.GetPoints() + 2);
                        target.SetFcolor(ConsoleColor.Black);
                        target.SetBcolor(ConsoleColor.Black);
                        target.UnDraw();
                    }
                    //when boss bullet touches player
                    else
                    {
                        stats.SetHealth(stats.GetHealth()-20);
                        break;
                    }
                }
            }
            gun.SetY(startY);

            for (int i =startY ; i > 0 && !touchedPoint; i--)
            {

                gun.SetY(i);

                //when bullet and point hit  
                if (point.GetX() == gun.GetX() && point.GetBcolor() == ConsoleColor.Green)
                {
                    touchedPoint = true;
                    point.Draw(); 
                }      
                
                gun.Draw();

                if (i % 2 == 1)
                    Thread.Sleep(1);
              
                gun.UnDraw();
              
            }
            gun.UnDraw();
        }

       //Main:
        static void Main(string[] args)
        { 
            //game openning instructions:
            Console.WriteLine("Welcome to the game! The aim of the game is to kill all the bosses. You do this by shooting them.");
            Console.WriteLine("Collect bullets, called points, by shooting the red targets and touching the green points.");
            Console.WriteLine("Avoid the boss's bullets and the red targets as they can kill you! Press enter to begin!!!!");
            Console.ReadLine();
            Console.Clear();

            //variables, objects:
            Random rnd = new Random();
            int n1 = 13; //number of ponts
            int n2 = 12; //number of targets
            int n3 = 3;  //nunber of busses 
            MTP[] point = new MTP[n1]; //points
            MTP[] targets = new MTP[n2]; //targets
            BigMTP[] boss = new BigMTP[n3];//bosses
            MTP[] bossGun1 = new MTP[n3];//boss's gun
            MTP[] bossGun2 = new MTP[n3];//boss's other gun
            MTP player = new MTP(45, 20, 'X', ConsoleColor.White, ConsoleColor.Blue, 1);//player
            MTP shot = new MTP(40, 40, '■', ConsoleColor.White, ConsoleColor.Black, 1);//player's gun
            Trect board = new Trect(26, 0, 90, 35, ConsoleColor.Red);//game boundry board
            Stats stats = new Stats();//info about players health, time left, boss's health, points etc...(on upper left corner).
            bool gameOver = false;//checks when to end game
            Stopwatch stopwatch = new Stopwatch();//checks when one second passes

            //points creation:
            for (int i = 0; i < n1; i++)
            {
                point[i] = new MTP(rnd.Next(27, 90), rnd.Next(1, 34), '+', ConsoleColor.White, ConsoleColor.DarkGreen, 0);
                point[i].Draw();
            }
            //targets creation:
            for (int i = 0; i < n2; i++)
            {
                targets[i] = new MTP(rnd.Next(27, 90), rnd.Next(1, 34), 'V', ConsoleColor.Black, ConsoleColor.Red, 1);
                targets[i].Draw();
            }
            //boss's and boss's guns creation:
            for (int i = 0; i < n3; i++)
            {
                boss[i] = new BigMTP();
                bossGun1[i] = new MTP(boss[i].GetX5(), boss[i].GetY6(), '*', ConsoleColor.White, ConsoleColor.Black, 1);
                bossGun2[i] = new MTP(boss[i].GetX6(), boss[i].GetY6(), '*', ConsoleColor.White, ConsoleColor.Black, 1);
                boss[i].SetHealth(n3 * 4);
            }

            //creation of the game "outline":
            stats.Draw();
            board.Draw();
            stopwatch.Start();

            //game loop:
            while (!gameOver)
            {
              Console.CursorVisible = false;//so it looks better

             //setting the players's gun postion:
             shot.SetX(player.GetX());
             shot.SetY(player.GetY());

            //setting the boss's guns postion, moving the boss and drawing it
                for(int i = 0; i < n3; i++)
                {
                    if (boss[i].GetBcolor()!=ConsoleColor.Black)//checks if the boss is "alive"
                    {
                        boss[i].UnDraw();
                        bossGun1[i].SetX(boss[i].GetX5());
                        bossGun1[i].SetY(boss[i].GetY6());
                        bossGun2[i].SetX(boss[i].GetX6());
                        bossGun2[i].SetY(boss[i].GetY6());
                        boss[i].RndMove();
                        boss[i].Draw();
                        if (rnd.Next(1, 100) == 1)//so boss only shoots sometimes
                        {
                            player.Draw();
                            stats.Draw();
                            boss[i].Draw();
                            //checks if player touches bullet and also does bullet animation:
                            Shoot(bossGun1[i], player, player, stats);
                            Shoot(bossGun2[i], player, player, stats);
                        }
                    }
                
                }
                
                //moves targets:
                for (int j = 0; j < n2; j++)
                {
                    targets[j].UnDraw();
                    targets[j].LessRndMove();
                    targets[j].Draw();
                }
                
                //checks player's input and acts accordingly:
                if (Console.KeyAvailable)
                {
                    player.UnDraw();
                    ConsoleKeyInfo k = Console.ReadKey();

                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey();
                    }

                    if (k.Key == ConsoleKey.UpArrow)
                    {
                        player.MoveUp();
                    }
                    else if (k.Key == ConsoleKey.DownArrow)
                    {
                        player.MoveDown();
                    }
                    else if (k.Key == ConsoleKey.RightArrow)
                    {
                        player.MoveRight();
                    }
                    else if (k.Key == ConsoleKey.LeftArrow)
                    {
                        player.MoveLeft();
                    }
                    else if (k.Key == ConsoleKey.Spacebar && stats.GetPoints()>0) //checks if player shoots (presses spaccebar)
                    {
                        stats.SetPoints(stats.GetPoints()-1);
                        player.Draw();

                       if( shot.GetY()>1)
                       {
                            shot.SetY(player.GetY() - 1);
                       }
                          
                       //does bullet animation and checks to see if target/s touch the bullet:
                        for(int p = 0; p< n1; p++)
                        {
                            if(p<n2)
                            {
                                Shoot(shot, point[p], targets[p], stats);
                            }
                            else
                            {
                                Shoot(shot, point[p], targets[p-n2], stats);
                            } 
                          
                        }
                        CheckBossGun(player, boss, stats);//checks if bullet touched any of the bosses
                    }
                  player.Draw();
                   
                 }

                for (int t = 0; t < point.Length; t++)
                {
                    if (point[t].GetBcolor() != ConsoleColor.Black)//draw point (in case it has been earesed by a boss/target, if player earesed it then it does not draw it)
                    {
                        point[t].Draw();
                    }
                    if (t < n2)
                    {
                        Touch(player, point[t], true, false, stats);//checks if player touched a point
                        Touch(player, targets[t], false, true, stats);//checks if player touched a target
                        if (point[t].GetBcolor() != ConsoleColor.Black)//draw point (in case it has been earesed by a boss/target, if player earesed it then it does not draw it)
                        {
                            point[t].Draw();
                        }
                    }
                    else
                    {
                        Touch(player, point[t], true, false, stats);//checks if player touched a point
                    }
                }

                //checks if a second passes and updates the screen:
                TimeSpan elapsed = stopwatch.Elapsed;
                if (elapsed.TotalMilliseconds >= 1000)
                {
                    stats.Undraw();
                    stats.SetTimeLeft(stats.GetTimeLeft() - 1);
                    stopwatch.Restart();
                }

               //checks if the game should be over:
                if(stats.GetTimeLeft() == 0 || stats.GetHealth() == 0 || stats.GetBossHealth() == 0)
                {
                    gameOver = true;
                }

                stats.Draw();
                Thread.Sleep(50); 
            } //end of game loop
          
            //tells the player his results:
            Thread.Sleep(300);
            Console.Clear();
            if(stats.GetTimeLeft() == 0)
            {
                Console.WriteLine("GAME OVER! YOU RAN OUT OF TIME!");
            }
            else if(stats.GetBossHealth() == 0)
            {
                Console.WriteLine("YOU WIN! YOU KILLED ALL THE BOSSES");
            }
            else if (stats.GetHealth() == 0)
            {
                Console.WriteLine("GAME OVER! YOU DIED!");
            }
            Console.ReadLine();

        }
    }
}
      