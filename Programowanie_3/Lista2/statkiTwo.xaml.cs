using Statki;
using System.Windows;

namespace Lista2
{
    public partial class statkiTwo : Window
    {
        public statkiTwo()
        {
            InitializeComponent();

            GameData.Player2 = this;

            GameData.CreateBoard(MyBoard, 2, false);
            GameData.CreateBoard(EnemyBoard, 2, true);

            RefreshBoards();
        }

        public void RefreshBoards()
        {
            GameData.RefreshBoards(MyBoard, EnemyBoard, 2);
        }
    }
}
