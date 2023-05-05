using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profect.TextRPG.Myself
{
    internal abstract class Scene
    {
        public Scene() { }

        public abstract void Render();

        public abstract void Update();
    }
}
