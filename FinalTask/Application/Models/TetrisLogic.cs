﻿using Application.Enums;
using Application.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Application.Models
{
    sealed class TetrisLogic
    {
        private Block myBlock;
        private Direction direction;
        int angle = 90;
        
        public void GameLoop() 
        {
            myBlock = new Block();
            myBlock.DrawBlock();

            while (true)
            {
                Thread.Sleep(500);
                direction = default;
                Action();

                if (Console.KeyAvailable.Equals(false))
                {
                    Action();
                }
                else
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    GetDirection(key.Key);
                    Action();
                }                
            }
        }

        public void Action()
        {
            switch (direction)
            {
                case Direction.Up:
                    myBlock.RotateBlock(angle);
                    break;

                case Direction.Down:
                    //TODO add dropping a figure with more speed
                    break;

                case Direction.Left:
                    for (int i = 0; i < myBlock.MyBlock.Capacity; i++)
                    {
                        myBlock.MyBlock[i].MoveLeft();
                    }
                    break;

                case Direction.Right:
                    for (int i = 0; i < myBlock.MyBlock.Count; i++)
                    {
                        myBlock.MyBlock[i].MoveRight();
                    }
                    break;

                default:
                    for (int i = myBlock.MyBlock.Capacity - 1; i >= 0; i--)
                    {
                        myBlock.MyBlock[i].DropDown();
                    }
                    break;
            }
        }



        public void GetDirection(ConsoleKey consoleKey) 
        {       
            switch (consoleKey)
            {   
                //TODO Add Keys: Space(pause), Esc(cancel) 
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;
                case ConsoleKey.UpArrow:
                    direction = Direction.Up;
                    break;
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
                case ConsoleKey.DownArrow:
                    direction = Direction.Down;
                    break;         
                default:
                    break;
            }
        }        

        private bool IsCollision(List<Point> checkingList)
        {
            bool answer = true;

            foreach (Point p in checkingList)
            {
                if (p.Char.Equals(' ') || p.X < 0 || p.Y < 0)
                {
                    answer = true;
                }
                else
                    answer = false;
            }

            return answer;
        }

        private static bool GameOver()
        {
            return false;
        }

    }
}

