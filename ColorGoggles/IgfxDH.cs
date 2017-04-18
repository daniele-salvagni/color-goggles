using igfxDHLib;

namespace ColorGoggles
{
    internal class IgfxDH
    {

        private static DataHandlerClass _dataHandler;

        public static DataHandlerClass DataHandler
        {
            get
            {
                if (IgfxDH._dataHandler == null)
                    {
                        IgfxDH._dataHandler = new DataHandlerClass();
                    }
                return IgfxDH._dataHandler;
            }
        }

    }
}
