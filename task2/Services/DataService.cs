using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using task2.Models;

namespace task2.Services
{
    public class DataService : IDataService
    {
        private readonly IMapper _mapper;
        public DataService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public StarShipsModel GetData(string url)
        {
            StarShipsModel starShips = new StarShipsModel();
            using (var client = new WebClient())
            {
                var content = client.DownloadString(url);
                starShips = JsonConvert.DeserializeObject<StarShipsModel>(content);
                FillArray(starShips.Results);
            }          
            return starShips;
        }
        public async Task<StarShipsModel> GetDataAsync(string url)
        {
            ApiDataModel starShips = new ApiDataModel();
            using (var client = new WebClient())
            {
                var content = await client.DownloadStringTaskAsync(url);
                starShips = JsonConvert.DeserializeObject<ApiDataModel>(content);
                while (url != null)
                {
                    content = await client.DownloadStringTaskAsync(url);
                    ApiDataModel data = JsonConvert.DeserializeObject<ApiDataModel>(content);
                    url = data.Next;
                    starShips.Results.AddRange(data.Results);
                }
                FillArray(starShips.Results);
            }
            return _mapper.Map<ApiDataModel, StarShipsModel>(starShips);
        }
        public void FillArray(List<StarShipModel> starShips)
        {
            for (int i = 0; i < starShips.Count; i++)
            {
                starShips[i].Index = i + 1;
            }
        }
    }
}
