using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TeploLibrary;

namespace Teplo_WCF_Library
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class CulcService : ICulcService
    {
        public OutputDate SumMatrixes(InputDate inputMatrixes)
        {
            // inputMatrixes.Mass_a
            OutputDate mass_data = new OutputDate();
            int a = inputMatrixes.Mass_u.GetLength(0);
            int b = inputMatrixes.Mass_u.GetLength(1);
            double h = inputMatrixes.H;
            double time = inputMatrixes.Time;
            double tau = inputMatrixes.Tau;
            
            mass_data.Culc_Teplo = new double[a, b];
            Teplo teplo = new Teplo();
            mass_data.Culc_Teplo = teplo.PoslCulc(inputMatrixes.Mass_u, time, tau, h);

            return mass_data;
        }
    }
}
