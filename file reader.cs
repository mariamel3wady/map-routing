using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApplication51
{
    public class fileManager
    {

        public ReturnedGraphData ReadFile()
        {
            //MUST CHANGE THE NAME OF intersections TO AVOID ISSUES PLEASE
            List<nodes> intersections = new List<nodes>();
            List<road> roads = new List<road>();
            List<query> querys = new List<query>();
            StreamReader sr = new StreamReader("OLMap.txt");

            int numberintersections = Convert.ToInt32(sr.ReadLine());
            for (int j = 0; j < numberintersections; j++)
            {
                nodes n = new nodes();
                string str = sr.ReadLine();
                string[] data = str.Split(' ');
                n.nodeNumber = Convert.ToInt32(data[0]);
                n.coordinates.x = Convert.ToDouble(data[1]);
                n.coordinates.y = Convert.ToDouble(data[2]);
                intersections.Add(n);

            }
            int numberRoades = Convert.ToInt32(sr.ReadLine());
            for (int j = 0; j < numberRoades; j++)
            {
                road r = new road();
                string str2 = sr.ReadLine();
                string[] data2 = str2.Split(' ');
                r.FirstVertex = Convert.ToInt32(data2[0]);
                r.SecondVertex = Convert.ToInt32(data2[1]);
                r.length = Convert.ToDouble(data2[2]);
                r.speed = Convert.ToInt32(data2[3]);
                roads.Add(r);

            }
            
            //for (int i = 0; i < intersections.Count; i++)
            //{
            //    Console.WriteLine(intersections[i].nodeNumber);
            //    Console.WriteLine(intersections[i].coordinates.x);
            //    Console.WriteLine(intersections[i].coordinates.y);


            //}
            //for (int i = 0; i < roads.Count; i++)
            //{
            //    Console.WriteLine(roads[i].FirstVertex);
            //    Console.WriteLine(roads[i].SecondVertex);
            //    Console.WriteLine(roads[i].length);
            //    Console.WriteLine(roads[i].speed);

            //}
            sr.Close();
             StreamReader sr2 = new StreamReader("OLQueries.txt");
             int numberquery = Convert.ToInt32(sr2.ReadLine());

             for (int k = 0; k < numberquery; k++)
             {
                 query q = new query();
                 string str3 = sr2.ReadLine();
                 string[] data3 = str3.Split(' ');
                 q.source.x = Convert.ToDouble(data3[0]);
                 q.source.y = Convert.ToDouble(data3[1]);
                 q.destination.x = Convert.ToDouble(data3[2]);
                 q.destination.y = Convert.ToDouble(data3[3]);
                 q.walkingDistance = Int32.Parse(data3[4]);
                 querys.Add(q);
             }
            ReturnedGraphData returnable = new ReturnedGraphData();
            returnable.Nodes = intersections;
            returnable.Roads = roads;
            returnable.Queries = querys;
            return returnable;
        }

    }
}
