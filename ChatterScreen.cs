using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Engine.Screens;

namespace NPCChatter
{
    public class ChatterScreen : ScreenBase, IGameStateListener
    {
        void IGameStateListener.OnActivate()
        {
            InformationManager.DisplayMessage(new InformationMessage("ChatterScreen -> OnActivate()"));
        }

        void IGameStateListener.OnDeactivate()
        {
            InformationManager.DisplayMessage(new InformationMessage("ChatterScreen -> OnDeactivate()"));
        }

        void IGameStateListener.OnFinalize()
        {
            InformationManager.DisplayMessage(new InformationMessage("ChatterScreen -> OnFinalize()"));
        }

        void IGameStateListener.OnInitialize()
        {
            InformationManager.DisplayMessage(new InformationMessage("ChatterScreen -> OnInitialize()"));
        }
    }
}
