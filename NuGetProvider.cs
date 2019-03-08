using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NameChk.CLI
{
    class NuGetProvider : IProvider
    {
        HttpClient Client;

        public NuGetProvider()
        {
            Client = new HttpClient { BaseAddress = new Uri("https://api.nuget.org/") };
        }

        public Task<(string, bool)>[] CheckAvailability(string[] names)
        {
            return names.Select(async name =>
            {
                var Response = await Client.GetAsync($"v3-flatcontainer/{name}/index.json");
                return (name, Response.StatusCode == HttpStatusCode.NotFound ? true : false);
            }).ToArray();
        }
    }
}