﻿using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Application
{
    class StartGame
    {
        static void Main(string[] args)
        {
            GameWindow gameWindow = new GameWindow();

            gameWindow.SetWindowParameters();

            gameWindow.ShowTitle();

            TetrisGame game = new TetrisGame();

            game.Start();

            while(GameWindow.QueryYN(FrasesConst.WantTryAgain))
            {
                Console.Clear();
                game = new TetrisGame();
                game.Start();
            }

            ScoreTable scores = new ScoreTable();

            scores.AddNameToScore(gameWindow.QueryForName(), TetrisGame.Score);
            scores.ShowScore();

            Thread.Sleep(3000);

            while (GameWindow.QueryYN(FrasesConst.WantSendMail))
            {                
                scores.SendScoreToMail(gameWindow.QueryForEmail());
                break;
            }

            gameWindow.SayGoodbye();

            Environment.Exit(1);
        }
    }
}