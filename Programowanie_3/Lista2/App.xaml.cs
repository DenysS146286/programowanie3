using System.Windows;

namespace Lista2
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            GraStatki gra = new GraStatki();

            new GraczOkno(new GraczWidok(gra, 0)).Show();
            new GraczOkno(new GraczWidok(gra, 1)).Show();
        }
    }
}
