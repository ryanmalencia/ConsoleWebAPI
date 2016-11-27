using System.Collections.Generic;

namespace DataTypes
{
    public class OSCollection
    {
        public List<OS> OSES;

        /// <summary>
        /// OSCollection constructor
        /// </summary>
        public OSCollection()
        {
            OSES = new List<OS>();
        }

        /// <summary>
        /// Add OS to collection
        /// </summary>
        /// <param name="os">OS object</param>
        public void AddOS(OS os)
        {
            OSES.Add(os);
        }
    }
}
