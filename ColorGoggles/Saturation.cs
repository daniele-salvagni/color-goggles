using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using igfxDHLib;

namespace ColorGoggles
{
    static class Saturation
    {

        private static Dictionary<uint, String> deviceList = new Dictionary<uint, String>();
        private static uint ulDevices = 0u;
        private static uint ulDeviceID = 0u;

        private static _CUI_COLOR_DEVICES colorDevices = default(_CUI_COLOR_DEVICES);

        public static String GetAdapterName()
        {
            return IgfxDH.DataHandler.BrandInfo.wcAdapterName;
        }


        private static void PopulateDisplayMap()
        {
            deviceList.Clear();

            CUI_AVAILABLE_DISPLAYS cUI_AVAILABLE_DISPLAYS = default(CUI_AVAILABLE_DISPLAYS);
            IgfxDH.DataHandler.get_AvailableDisplays(ref cUI_AVAILABLE_DISPLAYS);

            for (uint i = 0u; i < cUI_AVAILABLE_DISPLAYS.dwTotalDisplays; i++)
            {
                uint ulCUIID = cUI_AVAILABLE_DISPLAYS.DisplayDevices[i].ulCUIID;
                if (ulCUIID != 0u)
                {
                    CUI_DISPLAY_INFO cUI_DISPLAY_INFO = default(CUI_DISPLAY_INFO);
                    IgfxDH.DataHandler.get_DisplayInfo(ulCUIID, ref cUI_DISPLAY_INFO);
                    string text = "";

                    int num = 0;
                    while (cUI_DISPLAY_INFO.displayName[num] != 0)
                    {
                        char c = Convert.ToChar(cUI_DISPLAY_INFO.displayName[num]);
                        text += c;
                        num++;
                    }

                    if (text != string.Empty)
                    {
                        deviceList.Add(ulCUIID, text);
                    }
                }
            }
        }

        public static String getMainDisplayName()
        {
            PopulateDisplayMap();
            PopulateDevices();

            String displayName = "";
            deviceList.TryGetValue(ulDeviceID, out displayName);
            return displayName;
        }

        private static void PopulateDevices()
        {
            ulDevices = 0u;
            ulDeviceID = 0u;

            CUI_GET_CURRCONFIG_ARGS selectedConfig = default(CUI_GET_CURRCONFIG_ARGS);
            IgfxDH.DataHandler.get_CurrentConfig(ref selectedConfig);

            for (uint i = 0u; i < 3u; i++)
            {
                ulDevices |= selectedConfig.systemTopology.pathInfo[i].dwTargetId;
            }

            ulDeviceID = selectedConfig.systemTopology.pathInfo[0].dwTargetId;
        }

        private static void GetColorInfo()
        {
            PopulateDevices();
            colorDevices.ulDevices = ulDevices;

            colorDevices.Device = new _CUI_COLOR_INFO[3];
            uint[] array = new uint[3];

            colorDevices.Command = _CUI_COLOR_COMMAND.GET_COLOR;
            IgfxDH.DataHandler.get_GetDeviceList(colorDevices.ulDevices, array);

            for (uint i = 0u; i < 3u; i++)
            {
                colorDevices.Device[i] = default(_CUI_COLOR_INFO);
            }


            colorDevices.Command = _CUI_COLOR_COMMAND.GET_COLOR;
            IgfxDH.DataHandler.get_color(0u, ref colorDevices);
        }

        public static void SetSaturation(int satValue)
        {
            GetColorInfo();
            colorDevices.Command = _CUI_COLOR_COMMAND.CHANGE_DEVICE_COLOR;

            for (uint num = 0u; num < 3u; num += 1u)
            {
                colorDevices.Device[num].Saturation.fCurrent = satValue;
            }

            IgfxDH.DataHandler.set_color(ulDeviceID, ref colorDevices, 0u);
        }

        public static int GetSaturation()
        {
            GetColorInfo();
            return (int) colorDevices.Device[0].Saturation.fCurrent;
        }

    }
}
