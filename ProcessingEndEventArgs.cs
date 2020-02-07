using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    public class ProcessingEndEventArgs : EventArgs
    {
        public TimeSpan DeltaTime { get; set; }
        public int ProcessedFilesCount { get; set; }
        public int RequestedFilesCount { get; set; }
    }
}
