using System.Collections.Generic;

namespace ExampleApp.Models
{
    internal class CountyInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}
