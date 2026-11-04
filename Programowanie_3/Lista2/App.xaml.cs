
using System.Windows;

namespace Lista2
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Gracz1 okno = new Gracz1();
            okno.Show();
        }
    }
}
