using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paginaweb1
{
    internal class URL_Persistencia
    {
        string fileURLJSON = "UrlJson.txt";

        public List<URL> LeerJson()
        {
            List<URL> lecturaURL = new List<URL>();
            string jsonString = File.ReadAllText(fileURLJSON);
            lecturaURL = JsonConvert.DeserializeObject<List<URL>>(jsonString);
            return lecturaURL;
        }
        public void GuardarJson(List<URL> lecturaURL)
        {
            string jsonString = JsonConvert.SerializeObject(lecturaURL);
            File.WriteAllText(fileURLJSON, jsonString);
        }
    }
}
