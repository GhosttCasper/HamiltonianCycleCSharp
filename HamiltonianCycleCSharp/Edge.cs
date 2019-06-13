using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonianCycleCSharp
{    
    public class IncidentEdge 
    {
        public Vertex IncidentTo; // входит (конец)

        public IncidentEdge(Vertex incidentTo) 
        {
            IncidentTo = incidentTo;
        }
    }
}
