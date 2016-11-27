namespace DataTypes
{
    public class Pool
    {
        public string Name { get; set; }

        /// <summary>
        /// Constructor for pool object
        /// </summary>
        /// <param name="name">Pool name</param>
        public Pool(string name = "Default")
        {
            Name = name;
        }
    }
}
