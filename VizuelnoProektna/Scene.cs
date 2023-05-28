using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizuelnoProektna
{
    public class Scene
    {
        public HorizonralPlayer hPlayer { set; get; }
        public List<VerticalPlayer> vPlayers { set; get; }
        public List<Blocks> blocks { set; get; }


    }
}
