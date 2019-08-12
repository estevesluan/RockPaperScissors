using Newtonsoft.Json;
using RockPaperScissorsApp.Exceptions;
using System;

namespace RockPaperScissorsApp
{
    public class Program
    {
        GameRPS game;
        static void Main(string[] args)
        {
            string strGame = "[[\"Armando\",\"P\"],[\"Dave\",\"S\"]]";

            string strTournament = "[[[[\"Armando\",\"P\"],[\"Dave\",\"S\"]],[[\"Richard\",\"R\"],[\"Michael\",\"S\"]],[[\"Allen\",\"S\"],[\"Omer\",\"P\"]],[[\"David E.\",\"R\"],[\"Richard X\",\"P\"]]]]";

            Console.WriteLine("Part A - Game");
            PartA(strGame);

            Console.WriteLine("Part B - Tournament");
            PartB(strTournament);

            Console.ReadKey();
        }

        public static void PartA(string strGame)
        {
            try
            {
                GameRPS game = new GameRPS();
                string[,] elements = JsonConvert.DeserializeObject<string[,]>(strGame);

                string[] PlayerWinner = game.Rps_game_winner(elements);
                Console.WriteLine($"Winner Name [{PlayerWinner[0]}] Move [{PlayerWinner[1]?.ToUpper()}]");
            }
            catch (WrongNumberOfPlayersError ex)
            {
                Console.WriteLine($"Error #{ex.Message}");
            }
            catch (NoSuchStrategyError ex)
            {
                Console.WriteLine($"Error #{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error #{ex.Message}");
            }
        }

        public static void PartB(string strTournament)
        {
            try
            {
                GameRPS game = new GameRPS();
                string[,,] tournament = JsonConvert.DeserializeObject<string[,,]>(strTournament.Remove(strTournament.Length - 1).Remove(0, 1));

                string[] PlayerWinner = game.Rps_tournament_winner(tournament);
                Console.WriteLine($"Winner Name [{PlayerWinner[0]}] Move [{PlayerWinner[1]?.ToUpper()}]");
            }
            catch (WrongNumberOfPlayersError ex)
            {
                Console.WriteLine($"Error #{ex.Message}");
            }
            catch (NoSuchStrategyError ex)
            {
                Console.WriteLine($"Error #{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error #{ex.Message}");
            }
        }
    }
}
