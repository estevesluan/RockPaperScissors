using RockPaperScissorsApp.Exceptions;
using System;

namespace RockPaperScissorsApp
{
    public class GameRPS
    {
        public const string PLAYER_STRATEGY = "RrPpSs";
        public GameRPS()
        {

        }

        public string[] Rps_game_winner(string[,] game)
        {
            //If the number of players is not equal to 2, raise WrongNumberOfPlayersError.
            if (game.GetLength(0) != 2 || game.GetLength(1) != 2 || 
                    string.IsNullOrEmpty(game[0,0]) || string.IsNullOrEmpty(game[1, 0]))
            {
                throw new WrongNumberOfPlayersError("The number of players is not equal to 2");
            }

            //If either player's strategy is something other than "R", "P" or "S" (case-insensitive),raise NoSuchStrategyError
            if (string.IsNullOrEmpty(game[0, 1]) || string.IsNullOrEmpty(game[1, 1]) ||
                    game[0, 1].Length != 1 || game[1, 1].Length != 1 ||
                        !PLAYER_STRATEGY.Contains(game[0,1]) || !PLAYER_STRATEGY.Contains(game[1, 1]))
            {
                throw new NoSuchStrategyError("Either player's strategy is something other than 'R', 'P' or 'S' (case-insensitive)");
            }

            // Winner
            int result = playerWinner(game);

            // return the name and move of the winning player
            return new string[] { game[result, 0], game[result, 1] };
        }

        public string[] Rps_tournament_winner(string[,,] tournament)
        {
            try
            {
                //Note that the tournament continues until there is only a single winner
                while (tournament.GetLength(0) > 1)
                {
                    int posPlayer = 0;
                    int countGames = tournament.GetLength(0);
                    string[,,] proxTournament = new string[countGames / 2, 2, 2];

                    for (int i = 0; i < tournament.GetLength(0); i++)
                    {
                        string[,] elements = new string[2, 2];

                        elements[0, 0] = tournament[i, 0, 0];
                        elements[0, 1] = tournament[i, 0, 1];
                        elements[1, 0] = tournament[i, 1, 0];
                        elements[1, 1] = tournament[i, 1, 1];

                        string[] PlayerWinner = Rps_game_winner(elements);

                        if (i % 2 == 0)
                        {
                            proxTournament[posPlayer, 0, 0] = PlayerWinner[0];
                            proxTournament[posPlayer, 0, 1] = PlayerWinner[1];
                        }
                        else
                        {
                            proxTournament[posPlayer, 1, 0] = PlayerWinner[0];
                            proxTournament[posPlayer, 1, 1] = PlayerWinner[1];
                            posPlayer++;
                        }
                    }
                    tournament = proxTournament;
                }

                // return the name and move of the winning player
                return new string[] { tournament[ 0, 0, 0], tournament[0, 0, 1] };
            }
            catch (WrongNumberOfPlayersError ex)
            {
                throw ex;
            }
            catch (NoSuchStrategyError ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int playerWinner(string[,] game)
        {
            char player0 = game[0, 1].ToUpper().ToCharArray()[0];
            char player1 = game[1, 1].ToUpper().ToCharArray()[0];
            
            // If both players play the same move, the first player is the winner.
            if (player0 == player1)
            {
                //Player 0
                return 0;
            }

            // R beats S
            if (player0 == 'R' && player1 == 'S')
            {
                //Player 0
                return 0;
            }

            // S beats P
            if (player0 == 'S' && player1 == 'P')
            {
                //Player 0
                return 0;
            }

            // P beats R
            if (player0 == 'P' && player1 == 'R')
            {
                //Player 0
                return 0;
            }

            //Player 1
            return 1;
        }
    }
}
