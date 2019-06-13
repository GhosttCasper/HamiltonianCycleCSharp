using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonianCycleCSharp
{
    public class Vertex
    {
        public int Index;
        public bool IsDiscovered;
        public List<IncidentEdge> AdjacencyList;


        public Vertex(int index)
        {
            Index = index;
            AdjacencyList = new List<IncidentEdge>();
        }
    }
}
