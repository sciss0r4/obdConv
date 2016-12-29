using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ODXConverter
{
    /*klasa ułatwiająca stworzenie delegatu pozwalajacego wywolac metode invoke na obiektach ktore musza byc aktualizowane
     * z innego watku.
     * metody w niej zawarte sa rozszerzeniem klasy control, maja specyficzna skladnie(jeden parametr z this),
     * ich wywoanie tez jest specyficzne this.metoda
     * <T> pozwala na wywolanie metody dla roznych typow z roznymi parametrami
     */
    public static class CControlRefresh
    {
        public static void InvokeIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
        
        public static void InvokeIfRequired<T>(this Control control, Action<T> action, T parameter)
        {
            if (control.InvokeRequired)
                control.Invoke(action, parameter);
            else
                action(parameter);
        }
    }
}
