using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetadaneORTO.Core.Zakresy
{
    abstract class ZakresyLoader
    {
        protected GeometryLayer _geometryLayer;

        protected ZakresyLoader(GeometryLayer geometryLayer)
        {
            _geometryLayer = geometryLayer;
        }

        public abstract void Importuj();
    }
}
