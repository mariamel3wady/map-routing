using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication51
{
    //Time,Distance and path returned from shortest path function.
   public struct pathData
   {
       public List<int> Path;
       public double Time;
       public pathData(List<int> P, double T)
       {
           Time = T;
           Path = P;
       }   
   
   }




    public struct point
    {
        public double x, y;
        public point(double X, double Y)
        {
            x = X;
            y = Y;
        }
    };
    //lists returned from file reader
    public struct ReturnedGraphData
    {
        public List<nodes> Nodes;
        public List<road> Roads;
        public List<query> Queries;
    };
    //vertcies
    public struct nodes
    {
        
        public int nodeNumber;
        public point coordinates;
        public nodes(int n, double X, double Y)
        {
            
            nodeNumber = n;
            coordinates.x = X;
            coordinates.y = Y;
        }
    };
    //edges
    public struct road
    {
        
        public int FirstVertex, SecondVertex, speed;
        public double length;
        public road(int v1, int v2, double l, int s)
        {
            
            FirstVertex = v1;
            SecondVertex = v2;
            length = l;
            speed = s;
        }
    };
    public struct query
    {
        
        public point source, destination;
        public int walkingDistance;
        public query(double x1, double y1, double x2, double y2, int WD)
        {
            
            source.x = x1;
            source.y = y1;
            destination.x = x2;
            destination.y = y2;
            walkingDistance = WD;
        }
    };
}
