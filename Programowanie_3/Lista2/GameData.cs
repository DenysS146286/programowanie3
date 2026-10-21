using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
namespace Statki
{
    public static class GameData
    {
        // These hold the two players' game objects.
        public static Lista2.statkiOne Player1;
        public static Lista2.statkiTwo Player2;

        // "true" means there is a ship in that square.
        public static bool[,] Ships1 = new bool[10, 10];
        public static bool[,] Ships2 = new bool[10, 10];

        // These remember which squares each player has shot at.
        public static bool[,] Shots1 = new bool[10, 10];
        public static bool[,] Shots2 = new bool[10, 10];

        public static void CreateBoard(UniformGrid board, int player, bool enemy) {
            for (int i = 0; i < 100; i++) {
                Button b = new Button();
                b.Margin = new Thickness(1);
                b.Tag = i;

                b.Click += (s, e) =>
                {
                    if (enemy)
                        Fire(player, (int)b.Tag);
                    else
                        PlaceShip(player, (int)b.Tag);
                };

                board.Children.Add(b);
            }
        }

        public static void PlaceShip(int player, int i) {
            int r = i / 10, c = i % 10;

            bool[,] ships = player == 1 ? Ships1 : Ships2;
            bool[,] shots = player == 1 ? Shots2 : Shots1;

            if (!shots[r, c])
                ships[r, c] = !ships[r, c];

            RefreshAll();
        }

        public static void Fire(int player, int i) {
            int r = i / 10, c = i % 10;

            bool[,] shots = player == 1 ? Shots1 : Shots2;

            shots[r, c] = true;

            RefreshAll();
        }

        public static void RefreshBoards(UniformGrid myBoard, UniformGrid enemyBoard, int player) {
            bool[,] myShips = player == 1 ? Ships1 : Ships2;
            bool[,] enemyShips = player == 1 ? Ships2 : Ships1;

            bool[,] myShots = player == 1 ? Shots2 : Shots1;
            bool[,] enemyShots = player == 1 ? Shots1 : Shots2;

            for (int i = 0; i < 100; i++) {
                int r = i / 10, c = i % 10;

                Button mine = (Button)myBoard.Children[i];
                Button enemy = (Button)enemyBoard.Children[i];

                mine.Content = "";
                enemy.Content = "";

                mine.Background = myShips[r, c]
                    ? Brushes.Black : Brushes.White;

                if (myShots[r, c])
                    mine.Background = myShips[r, c]
                        ? Brushes.Red : Brushes.LightGray;

                enemy.Background = Brushes.White;

                if (enemyShots[r, c]) {
                    bool hit = enemyShips[r, c];

                    enemy.Background = hit
                        ? Brushes.Red : Brushes.LightGray;

                    enemy.Content = hit ? "X" : "O";
                }
            }
        }

        public static void RefreshAll() {
            Player1?.RefreshBoards();
            Player2?.RefreshBoards();
        }
    }
}