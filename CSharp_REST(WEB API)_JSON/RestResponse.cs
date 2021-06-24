using Newtonsoft.Json;

namespace CSharp_REST_WEB_API__JSON
{
    public class RestResponse
    {
        [JsonProperty("Vlr_Cotacao")]
        public string vlr_cotacao { get; set; }
        [JsonProperty("Cod_Cotacao")]
        public string cod_cotacao { get; set; }
        [JsonProperty("Dat_Cotacao")]
        public string dat_cotacao { get; set; }
        [JsonProperty("id_moeda")]
        public string ID_MOEDA { get; set; }
        [JsonProperty("data_ref")]
        public string DATA_REF { get; set; }
    }
}
