using Statki;
using System.Windows;

namespace Lista2
{
    public partial class statkiOne : Window
    {
        public statkiOne()
        {
            InitializeComponent();

            GameData.Player1 = this;

            GameData.CreateBoard(MyBoard, 1, false);
            GameData.CreateBoard(EnemyBoard, 1, true);

            RefreshBoards();

            statkiTwo second = new statkiTwo();
            second.Show();
        }

        public void RefreshBoards()
        {
            GameData.RefreshBoards(MyBoard, EnemyBoard, 1);
        }
    }
}
