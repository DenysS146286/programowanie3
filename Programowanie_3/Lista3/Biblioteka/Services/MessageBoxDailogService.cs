using System.Windows;

namespace Biblioteka.Services
{
    public class MessageBoxDailogService : IDialogService
    {
        public bool Potwierdz(string tekst)
        {
            return System.Windows.MessageBox.Show(tekst, "Potwierdzenie", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes;
        }

        public void Informacja(string tekst)
        {
            System.Windows.MessageBox.Show(tekst, "Informacja", System.Windows.MessageBoxButton.OK);
        }
    }
}
