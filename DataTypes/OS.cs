namespace DataTypes
{
    public class OS
    {
        public string Name { get; set; }

        /// <summary>
        /// OS constructior
        /// </summary>
        /// <param name="name">OS name</param>
        public OS(string name="Unknown")
        {
            Name = name;
        }
    }
}
