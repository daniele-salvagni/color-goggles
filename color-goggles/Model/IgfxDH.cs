using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using igfxDHLib;

namespace color_goggles.Model
{

    internal class IgfxDH {

        private static igfxDHLib.DataHandler instance;

        public static DataHandler DataHandler {
            get {
                if (IgfxDH.instance == null) {
                    try {
                        IgfxDH.instance = (DataHandler)Activator.CreateInstance(Type.GetTypeFromCLSID(
                            new Guid("D5F5053A-9585-4D80-8F6F-7B6587CEFB93"), true));
                    } catch (Exception e) {}
                }

                return IgfxDH.instance; // Singleton
            }
        }

    }

}
