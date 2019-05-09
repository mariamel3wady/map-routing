using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication51
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            
           
            var mygraph = new List<Dictionary<int, Dictionary<int, double>>>();
            var representedGraph = new GraphConstruction();
            var GraphInfo = new Graph_Data();
            ReturnedGraphData mapGraph;
            var fileman = new fileManager();
            mapGraph = fileman.ReadFile();
            var NodesInfo = mapGraph.Nodes;
            var RoadsInfo = mapGraph.Roads;
            var QueriesInfo = mapGraph.Queries;
            //var timeOfRoads = new List<double>();
            stopwatch.Start();
            for (int i = 0; i < RoadsInfo.Count; i++)
            {
                double returnedTime = GraphInfo.CalculatingTime(RoadsInfo[i].length, RoadsInfo[i].speed);
                // needs refactoring
                //timeOfRoads.Add(returnedTime);
                //int vertex2 = RoadsInfo[i].SecondVertex;
                representedGraph.add_vertex(RoadsInfo[i].FirstVertex, RoadsInfo[i].SecondVertex, returnedTime);
                representedGraph.add_vertex(RoadsInfo[i].SecondVertex, RoadsInfo[i].FirstVertex, returnedTime);
            }
            var stopwatch1=new Stopwatch();
            double minimumWalkingT = double.MaxValue;
            double WalkingTime = 0;
            double CurrentTime = double.MaxValue;
            for (int i = 0; i < QueriesInfo.Count; i++)
            {
                Console.WriteLine("OUTPUT for query "+(i+1).ToString());
                minimumWalkingT = double.MaxValue;
                var validStart = GraphInfo.searchingForStart(QueriesInfo[i].source.x, QueriesInfo[i].source.y, NodesInfo, QueriesInfo[i].walkingDistance);
                var validEnd = GraphInfo.searchinhForEnd(QueriesInfo[i].destination.x, QueriesInfo[i].destination.y, NodesInfo, QueriesInfo[i].walkingDistance);
                double minimumTime = double.MaxValue;
                var shortestTimePath = new List<int>();
                for (int j = 0; j < validStart.Count; j++)
                {
                    
                    for (int k = 0; k < validEnd.Count; k++)
                    {
                        stopwatch1 = new Stopwatch();
                        stopwatch1.Start();
                         var returnedPathData =representedGraph.shortest_path(validStart[j].Key, validEnd[k].Key);
                         stopwatch1.Stop();
                         WalkingTime = validStart[j].Value+validEnd[k].Value;
                         
                        CurrentTime = (WalkingTime * 60) / 5 + returnedPathData.Time;
                        
                        if( CurrentTime< minimumTime)
                        {
                            minimumTime = CurrentTime;
                            shortestTimePath = returnedPathData.Path;
                        }
                        if (WalkingTime < minimumWalkingT)
                        {
                            minimumWalkingT = WalkingTime;
                        }
                        
                    }
                    
                }
                double vehicleD=GraphInfo.calculateDistanceForShortestPath(shortestTimePath, RoadsInfo);



                Console.Write("Total Time from Source To Destination: ");
                minimumTime = System.Math.Round(minimumTime, 2);
                Console.WriteLine(minimumTime.ToString() + " mins");

                Console.Write("Total Distance from Source To Destination: ");
                double finalTotal = minimumWalkingT + vehicleD;
                finalTotal = System.Math.Round(finalTotal, 2);
                Console.WriteLine(finalTotal.ToString() + " Km");
                Console.Write("Total Walked Distance: ");
                minimumWalkingT = System.Math.Round(minimumWalkingT, 2);
                Console.WriteLine(minimumWalkingT.ToString() + " Km");
                Console.Write("Total vehicle Distance: ");
                vehicleD = System.Math.Round(vehicleD, 2);
                Console.WriteLine(vehicleD.ToString() + " Km");


                Console.Write("The Shortest Path is:");
                for (int l = shortestTimePath.Count - 1; l >= 0; l--)
                {
                    Console.Write(shortestTimePath[l].ToString() + " ");
                }
                Console.WriteLine();
                Console.WriteLine(stopwatch1.ElapsedMilliseconds.ToString()+"milliSecond");
                Console.WriteLine();

            }




            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds.ToString()+"milliSecond");
           
        }


    }
}
