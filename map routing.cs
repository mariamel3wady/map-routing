using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace ConsoleApplication51
{

    class GraphConstruction
    {
        Dictionary<int, Dictionary<int, double>> vertices = new Dictionary<int, Dictionary<int, double>>();
        //Function to fill the graph vertices with inputs
        public void add_vertex(int vertex, int vertex2, double time )
        {
            // check if this vertex doesn't exist in the graph and if so add a dummy dictionary to it.
            if(!vertices.ContainsKey(vertex))
            {
                vertices[vertex] = new Dictionary<int, double>();
            }
            var dict = vertices[vertex];
            dict[vertex2] = time;
        }


        public pathData shortest_path(int start, int finish)
        {
            var previous = new Dictionary<int, int>();
            var distances = new Dictionary<int, double>();
            //priority queue
            var intersections1 = new SortedDictionary<int, double>();
            //returned path
            List<int> path = null;
            // initialize starting node with zero and every other node with infinity & add them to a list of nodes
            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }

                intersections1.Add(vertex.Key, distances[vertex.Key]);
            }

            while (intersections1.Count != 0)
            {
                //get minimum of nodes;
                // needs to get minimum based on time.
                intersections1.ToList();
                //pass delegate to order it depends on weight of the graph
                //refactoring
                var smallest = intersections1.OrderBy(a => a.Value).First();
    
                intersections1.Remove(smallest.Key);
                // like the base case were the code ends
                if (smallest.Key == finish)
                {
                    path = new List<int>();
                    //double timeHolder = 0.0;
                    while (previous.ContainsKey(smallest.Key))
                    {
                        // needs to be refactored , replaces the previous value to the smallest and adds it to the path.
                        
                        path.Add(smallest.Key);
                        //timeHolder += smallest.Value;
                        int keyHolder = previous[smallest.Key];
                        var temp = new KeyValuePair<int, double>(keyHolder, smallest.Value);
                        smallest = temp;
                    }

                    break;
                }

                if (distances[smallest.Key] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest.Key])
                {
                    var alt = distances[smallest.Key] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest.Key;
                        intersections1[neighbor.Key] = alt;
                    }
                }
            }
            
            path.Add(start);
         
                
            var returnedPath = new pathData(path,distances[finish]);
            return returnedPath;
            //return path;
        }
    }
}


