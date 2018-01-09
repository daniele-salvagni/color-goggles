using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace color_goggles.View
{
    public interface IGogglesView {

        IList<String> GameList { get; }

        String DisplayName { set; }

        int WinSaturation { get; set; }

        int GameSaturation { get; set; }

        bool AppEnabled { get; set; }

        bool Autostart { get; set; }

        bool IgnoreFocus { get; set; }

        bool RemoveLimits { get; set; }

        void AddGame(string processName);

        void RemoveGame(string processName);

        void NotifyNewVersion();

        Presenter.GogglesPresenter Presenter { set; }

    }
}
