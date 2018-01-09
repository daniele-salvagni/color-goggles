using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace color_goggles.Model
{
    public interface IDisplay {
        String DeviceName { get; }

        int GetSaturation();

        void SetSaturation(int satValue);
    }
}
