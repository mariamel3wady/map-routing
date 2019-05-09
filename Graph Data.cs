using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication51
{
    public class Graph_Data
    {
        static int squareroot(int x) 
    { 
        // Base cases 
        if (x == 0 || x == 1) 
            return x; 
  
        // Staring from 1, try all 
        // numbers until i*i is  
        // greater than or equal to x. 
        int i = 1, result = 1; 
          
        while (result <= x)  
        { 
            i++; 
            result = i * i; 
        }
        return i - 1;
}

        
        public double power(double x,int y) {
            double temp;
            if (y == 0)
                return 1;
            temp = power(x, y / 2);
            if (y % 2 == 0)
                return temp * temp;
            else
                return x * temp * temp; 

    }


        



        public double calculateDistanceForShortestPath(List<int> l,List<road> r)
        {
            double returnedDistance = 0;

            for (int i = 0;i<l.Count-1 ; i++)
            {
                for (int j = 0; j < r.Count; j++)
                {
                    if (l[i] == r[j].FirstVertex && l[i + 1] == r[j].SecondVertex)
                    {
                        returnedDistance += r[j].length;
                        break;
                    }
                    else if (l[i] == r[j].SecondVertex && l[i + 1] == r[j].FirstVertex)
                    {
                        returnedDistance += r[j].length;
                        break;
                    }
                }
            }
            return returnedDistance;
        }
        public double EuclideanDistance(double n1X, double n1Y, double n2X, double n2Y)
        {

            double dist;
            double x = n1X - n2X;
            double y = n1Y - n2Y;


            dist = power(x, 2) + power(y, 2);
            dist = Math.Sqrt(dist);


            return dist;
        }
        public double CalculatingTime(double length, int speed)
        {
            double time = length / speed;
            // etcheky 3leeha y mariam
            return time*60;
        }
        public List<KeyValuePair<int,double>> searchingForStart(double x, double y, List<nodes> n, int walkingD)
        {
            // needs refactoring 
            var validStartingDistances = new List<KeyValuePair< int,double>>();
            for (int i = 0; i < n.Count; i++)
            {
                double distance = EuclideanDistance(x, y, n[i].coordinates.x, n[i].coordinates.y);
                if (distance*1000 < walkingD)
                {
                    var temp = new KeyValuePair<int, double>(n[i].nodeNumber,distance);
                    validStartingDistances.Add(temp);
                }
                
            }
            return validStartingDistances;
        }
        public List<KeyValuePair<int, double>> searchinhForEnd(double x, double y, List<nodes> n, int walkingD)
        {
            var validEndingDistances = new List<KeyValuePair<int,double>>();
            for (int i = 0; i < n.Count; i++)
            {
                double distance = EuclideanDistance(x, y, n[i].coordinates.x, n[i].coordinates.y);
                if (distance*1000 < walkingD)
                {
                    var temp = new KeyValuePair<int, double>(n[i].nodeNumber, distance);
                    validEndingDistances.Add(temp);
                }
            }
            return validEndingDistances;
        }

    }
}
