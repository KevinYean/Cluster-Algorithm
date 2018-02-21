using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster_Algorithm
{
    /// <summary>
    /// Minimum distance between clusters algorithm
    /// </summary>
    public class SingleLinkage : Linkage
    {
        /// <summary>
        /// Constructor will call Linkage.Linkage().
        /// </summary>
        public SingleLinkage() : base()
        {

        }

        /// <summary>
        /// Constructor will call Linkage.Linkage(int newK, List<DataPoint> newDataList);
        /// </summary>
        /// <param name="newK"></param>
        /// <param name="newDataList"></param>
        public SingleLinkage(int newK, List<DataPoint> newDataList) : base(newK, newDataList)
        {

        }

        
    }
}
