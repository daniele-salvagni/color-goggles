using igfxDHLib;
using System;
using System.IO;

namespace ColorGoggles
{
    internal class IgfxDH
    {

        private static DataHandler m_dataHandler;

        public static DataHandler DataHandler
        {
            get
            {
                if (IgfxDH.m_dataHandler == null)
                {
                    try
                    {
                        IgfxDH.m_dataHandler = (DataHandler)Activator.CreateInstance(Type.GetTypeFromCLSID(
                            new Guid("D5F5053A-9585-4D80-8F6F-7B6587CEFB93"), true));
                    }
                    catch (Exception e)
                    {
                    }
                }

                return IgfxDH.m_dataHandler;
            }
        }

    }
}
