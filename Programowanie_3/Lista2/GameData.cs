using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace Lista2
{
    public class Cell : INotifyPropertyChanged
    {
        private Brush color = Brushes.White;
        private string text = "";

        public Brush Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Color"));
            }
        }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }

        public ICommand ClickCommand { get; set; }

        public Cell(Action click)
        {
            ClickCommand = new RelayCommand(delegate
            {
                click();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class PlayerBoards
    {
        public ObservableCollection<Cell> MyBoard = new ObservableCollection<Cell>();

        public ObservableCollection<Cell> EnemyBoard = new ObservableCollection<Cell>();
    }

    public static class GameData
    {
        public static bool[] ships1 = new bool[100];
        public static bool[] ships2 = new bool[100];

        public static bool[] shots1 = new bool[100];
        public static bool[] shots2 = new bool[100];

        public static PlayerBoards Player1 = new PlayerBoards();
        public static PlayerBoards Player2 = new PlayerBoards();

        static GameData()
        {
            int i = 0;

            while (i < 100)
            {
                int number = i;

                Player1.MyBoard.Add(new Cell(delegate
                {
                    PlaceShip(1, number);
                }));

                Player1.EnemyBoard.Add(new Cell(delegate
                {
                    Fire(1, number);
                }));

                Player2.MyBoard.Add(new Cell(delegate
                {
                    PlaceShip(2, number);
                }));

                Player2.EnemyBoard.Add(new Cell(delegate
                {
                    Fire(2, number);
                }));

                i++;
            }

            RefreshAll();
        }

        public static void PlaceShip(int player, int i)
        {
            if (player == 1)
            {
                if (shots2[i] == false)
                {
                    if (ships1[i] == true)
                    {
                        ships1[i] = false;
                    }
                    else
                    {
                        ships1[i] = true;
                    }
                }
            }
            else
            {
                if (shots1[i] == false)
                {
                    if (ships2[i] == true)
                    {
                        ships2[i] = false;
                    }
                    else
                    {
                        ships2[i] = true;
                    }
                }
            }

            RefreshAll();
        }

        public static void Fire(int player, int i)
        {
            if (player == 1)
            {
                shots1[i] = true;
            }
            else
            {
                shots2[i] = true;
            }

            RefreshAll();
        }

        public static void RefreshAll()
        {
            int i = 0;

            while (i < 100)
            {
                // Player 1 board

                if (shots1[i] == true)
                {
                    if (ships1[i] == true)
                    {
                        Player1.MyBoard[i].Color = Brushes.Red;
                    }
                    else
                    {
                        Player1.MyBoard[i].Color = Brushes.LightGray;
                    }
                }
                else
                {
                    if (ships1[i] == true)
                    {
                        Player1.MyBoard[i].Color = Brushes.Black;
                    }
                    else
                    {
                        Player1.MyBoard[i].Color = Brushes.White;
                    }
                }

                if (shots2[i] == true)
                {
                    if (ships1[i] == true)
                    {
                        Player1.EnemyBoard[i].Color = Brushes.Red;
                        Player1.EnemyBoard[i].Text = "X";
                    }
                    else
                    {
                        Player1.EnemyBoard[i].Color = Brushes.LightGray;
                        Player1.EnemyBoard[i].Text = "O";
                    }
                }
                else
                {
                    Player1.EnemyBoard[i].Color = Brushes.White;
                    Player1.EnemyBoard[i].Text = "";
                }

                // Player 2 board

                if (shots2[i] == true)
                {
                    if (ships2[i] == true)
                    {
                        Player2.MyBoard[i].Color = Brushes.Red;
                    }
                    else
                    {
                        Player2.MyBoard[i].Color = Brushes.LightGray;
                    }
                }
                else
                {
                    if (ships2[i] == true)
                    {
                        Player2.MyBoard[i].Color = Brushes.Black;
                    }
                    else
                    {
                        Player2.MyBoard[i].Color = Brushes.White;
                    }
                }

                if (shots1[i] == true)
                {
                    if (ships2[i] == true)
                    {
                        Player2.EnemyBoard[i].Color = Brushes.Red;
                        Player2.EnemyBoard[i].Text = "X";
                    }
                    else
                    {
                        Player2.EnemyBoard[i].Color = Brushes.LightGray;
                        Player2.EnemyBoard[i].Text = "O";
                    }
                }
                else
                {
                    Player2.EnemyBoard[i].Color = Brushes.White;
                    Player2.EnemyBoard[i].Text = "";
                }

                i++;
            }
        }
    }
}