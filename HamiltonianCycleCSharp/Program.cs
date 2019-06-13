using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonianCycleCSharp
{
    class Program
    {
        private static List<Vertex> VerticesList = new List<Vertex>();
        private static List<Vertex> verticesPath = new List<Vertex>();
        private static int Size;

        static void Main(string[] args)
        {
            ReadFileWithAdjacencyList("input.txt");
            if (HamiltonianCycleSearch(VerticesList[0]))
                Output("output.txt");
        }

        private static void Output(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                string indexes = "";
                foreach (var vertex in verticesPath)
                {
                    indexes += vertex.Index.ToString();
                    indexes += " ";
                }
                writer.WriteLine(indexes);
            }
        }

        private static bool HamiltonianCycleSearch(Vertex curVertex)
        {
            verticesPath.Add(curVertex);
            if (verticesPath.Count == Size)
            {
                if (verticesPath.Last().AdjacencyList.Find(edge => edge.IncidentTo.Index == verticesPath.First().Index) != null)
                    return true;
                verticesPath.Remove(verticesPath.Last());
                return false;
            }

            curVertex.IsDiscovered = true;

            foreach (var edge in curVertex.AdjacencyList)
            {
                if (!edge.IncidentTo.IsDiscovered && HamiltonianCycleSearch(edge.IncidentTo))
                    return true;
            }

            curVertex.IsDiscovered = false;
            verticesPath.Remove(verticesPath.Last());

            return false;
        }

        private static void ReadFileWithAdjacencyList(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                int size = ReadNumber(reader);
                Size = size;
                for (int i = 1; i <= size; i++)
                    VerticesList.Add(new Vertex(i));

                string[] numbersStrs = new string[size];
                for (int i = 0; i < size; i++)
                {
                    numbersStrs[i] = reader.ReadLine();
                    var array = numbersStrs[i].Split();

                    if (!string.IsNullOrEmpty(numbersStrs[i]))
                        foreach (var str in array)
                        {
                            int intVar = int.Parse(str);
                            if (intVar > size)
                                throw new Exception("The vertex is missing");
                            Vertex curVertexTo = VerticesList[intVar - 1];

                            IncidentEdge curEdge = new IncidentEdge(curVertexTo);
                            VerticesList[i].AdjacencyList.Add(curEdge);
                        }
                }
            }
        }

        private static int ReadNumber(StreamReader reader)
        {
            var numberStr = reader.ReadLine();
            if (numberStr == null)
                throw new Exception("String is empty (ReadNumber)");
            var array = numberStr.Split();
            int number = int.Parse(array[0]);
            return number;
        }
    }
}
