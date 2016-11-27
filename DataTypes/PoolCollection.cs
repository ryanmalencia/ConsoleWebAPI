using System.Collections.Generic;

namespace DataTypes
{
    public class PoolCollection
    {
        public List<Pool> Pools;

        /// <summary>
        /// PoolCollection constructor
        /// </summary>
        public PoolCollection()
        {
            Pools = new List<Pool>();
        }
        
        /// <summary>
        /// Add pool to collection
        /// </summary>
        /// <param name="pool">Pool object</param>
        public void AddPool(Pool pool)
        {
            Pools.Add(pool);
        }

        /// <summary>
        /// Get all pools in collection
        /// </summary>
        /// <returns>List of pools</returns>
        public List<Pool> GetAllPools()
        {
            return Pools;
        }
    }
}
