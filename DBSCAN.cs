using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*https://en.wikipedia.org/wiki/DBSCAN
 */

namespace Cluster_Algorithm
{
    public class DBSCAN
    {
        public DBSCAN()
        {

        }

        public void Run()
        {
            /*A point p is a core point if at least minPts points are within distance ε(ε is the maximum radius of the neighborhood from p) of it(including p). Those points are said to be directly reachable from p.
            A point q is directly reachable from p if point q is within distance ε from point p and p must be a core point.
            A point q is reachable from p if there is a path p1, ..., pn with p1 = p and pn = q, where each pi+1 is directly reachable from pi (all the points on the path must be core points, with the possible exception of q).
            All points not reachable from any other point are outliers.

            Now if p is a core point, then it forms a cluster together with all points (core or non-core) that are reachable from it. Each cluster contains at least one core point; non-core points can be part of a cluster, but they form its "edge", since they cannot be used to reach more points.

              */

            //Pseudocode
            //Create a duplicate of the DataPoint list, but make sure to not reference it.
            //Go through everypoint
                // 1 If it is a corepoint given minPts within an e distance
                    // 2 Label it as core in datapoint
                    //Add it a brandnew cluster
                        //3 foreach points it found within the radius
                            //4 Make those Points (q)
                            //Add them to the cluster
                                //5 Repeat loop to level 1 from that datalist to find if those points q or core points or edges
               //Remove all the points that were added cluster from the Duplicatelist.

        }
    }
}
