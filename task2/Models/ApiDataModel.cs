using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2.Models
{
    public class ApiDataModel
    {
        public ApiDataModel()
        {
            this.Results = new List<StarShipModel>();
        }
        public string Next { get; set; }
        public int Count { get; set; }

        public List<StarShipModel> Results { get; set; }
    }
}
