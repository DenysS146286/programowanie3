using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.Services
{
    // 4.5 Vm nie wola MessageBox bezposrednio, tylko przez interfejs IDialogService
    public interface IDialogService
    {
        bool Potwierdz(string tekst);
        void Informacja(string tekst);
    }
}
