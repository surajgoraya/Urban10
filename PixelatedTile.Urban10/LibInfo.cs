using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelatedTile.Urban10
{
    /// <summary>
    /// Get information about the Library.
    /// </summary>
    public class LibInfo
    {
        private double _version = 1.1;

        /// <summary>
        /// Returns the version string of the library
        /// </summary>
        public string LibVersion
        {
            get
            {
                return "Urban10, Version: "+_version.ToString();
            }
        }
    }
}
