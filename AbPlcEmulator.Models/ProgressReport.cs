using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using CoPick.Logging;

namespace AbPlcEmulator.Models
{
    public class ProgressReport : IProgress<ImagesLoadResponse>
    {
        private static readonly LogHelper Logger = LogHelper.Logger;

        public void Report(ImagesLoadResponse response)
        {
            Logger.Info(response.ToString());
        }
    }
}
