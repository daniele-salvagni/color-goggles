using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using igfxDHLib;

namespace color_goggles.Model
{

    class Display : IDisplay {

        private CUI_GET_CURRCONFIG_ARGS selectedConfig = default(CUI_GET_CURRCONFIG_ARGS);
        private _CUI_COLOR_DEVICES colorDevices = default(_CUI_COLOR_DEVICES);

        private uint ulDevices = 0u;
        private uint ulDeviceID = 0u;
        

        public Display(String deviceName) {
            DeviceName = deviceName;
        }

        public String DeviceName { get; }

        private void GetColorInfo() {

            IgfxDH.DataHandler.get_CurrentConfig(ref selectedConfig);
            for (uint i = 0u; i < 3u; i++) {
                ulDevices |= selectedConfig.systemTopology.pathInfo[i].dwTargetId;
            }
            ulDeviceID = selectedConfig.systemTopology.pathInfo[0].dwTargetId;

            colorDevices.ulDevices = ulDevices;
            colorDevices.Device = new _CUI_COLOR_INFO[3];

            //uint[] array = new uint[3];
            //IgfxDH.DataHandler.get_GetDeviceList(colorDevices.ulDevices, array);

            for (uint i = 0u; i < 3u; i++) {
                colorDevices.Device[i] = default(_CUI_COLOR_INFO);
            }

            colorDevices.Command = _CUI_COLOR_COMMAND.GET_COLOR;
            IgfxDH.DataHandler.get_color(0u, ref colorDevices);

        }

        public int GetSaturation() {

            GetColorInfo();
            return (int)colorDevices.Device[0].Saturation.fCurrent;

        }

        public void SetSaturation(int satValue) {

            GetColorInfo();

            for (uint num = 0u; num < 3u; num += 1u) {
                colorDevices.Device[num].Saturation.fCurrent = satValue; 
            }

            colorDevices.Command = _CUI_COLOR_COMMAND.CHANGE_DEVICE_COLOR;
            IgfxDH.DataHandler.set_color(ulDeviceID, ref colorDevices, 0u);

        }


    }

}
