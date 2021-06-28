using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class ItemFila
    {
        public string moeda { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
        public int id { get; set; }
    }
    public class ItemCount
    {
        public int valor { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SelectOption();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na main => " + e.Message);
                Console.ReadKey();
                BackMenu();
            }
        }
        public static string TextCorrection(string Text)
        {
            try
            {
                if (String.IsNullOrEmpty(Text))
                {
                    return null;
                }
                if (String.IsNullOrWhiteSpace(Text))
                {
                    return null;
                }
                string Correction = @"(?i)[^0-9\s]";
                string TextNull = "";
                return Regex.Replace(Text.Trim().Replace("ㅤ", "").Replace("ﾠ", "").Replace(" ", "").Replace("ㅤ", ""), Correction, TextNull);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao tratar texto coletado => \t" + e.Message);
                return null;
            }
        }

        static void SelectOption()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Selecione uma das opções abaixo:\n(1) - GetItemFila\n(2) - AddItemFila\n(3) - DeletItemFila\n(4) - Sair");
                string optionselected = TextCorrection(Console.ReadLine());
                if (optionselected.Contains("1"))
                {
                    GetItemFila();
                }
                else if (optionselected.Contains("2"))
                {
                    AddItemFilaAsync().Wait();
                }
                else if (optionselected.Contains("3"))
                {
                    Console.ReadKey();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao selecionar esta opção => \t" + e.Message);
                Console.ReadKey();
                BackMenu();
            }
        }
        static void GetItemDiferential()
        {
            try
            {
                var url = "http://localhost:8080/json";
                var webrequest = WebRequest.CreateHttp(url);
                webrequest.Method = "GET";
                webrequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.114 Safari/537.36";
                var result = webrequest.GetResponse();
                var resultdata = result.GetResponseStream();
                StreamReader reader = new StreamReader(resultdata);
                object objResponse = reader.ReadToEnd();
                var get = JsonConvert.DeserializeObject<ItemFila>(objResponse.ToString());
                resultdata.Close();
                result.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro => \t" + e.Message);
            }
        }

        static void GetItemFila()
        {
            try
            {
                List<string> resultlist = new List<string>();
                Console.Clear();
                var url = "http://localhost:8080/json/" + GetCount();
                var webrequest = WebRequest.CreateHttp(url);
                webrequest.Method = "GET";
                webrequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.114 Safari/537.36";
                using (WebResponse result = webrequest.GetResponse())
                {
                    var resultdata = result.GetResponseStream();
                    StreamReader reader = new StreamReader(resultdata);
                    object objResponse = reader.ReadToEnd();
                    var get = JsonConvert.DeserializeObject<ItemFila>(objResponse.ToString());
                    Console.Write($"\nMoeda: {get.moeda}\tData Inicial: {get.data_inicio}\tData Final: {get.data_fim}\tId: {get.id}");
                    Console.WriteLine("\n\bAperte qualquer tecla para continuar...");
                    resultdata.Close();
                    result.Close();
                }
                Console.ReadKey();
                BackMenu();
            }
            catch (Exception GetItemFila)
            {
                Console.WriteLine("não existe objeto a ser retornado!\n\nErro Gerado =>\t" + GetItemFila.Message);
                Console.ReadKey();
                BackMenu();
            }
        }
        static int GetCount()
        {
            try
            {
                int valor;
                var url = "http://localhost:8080/count/1";
                var webrequest = WebRequest.CreateHttp(url);
                webrequest.Method = "GET";
                webrequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.114 Safari/537.36";
                var result = webrequest.GetResponse();
                var resultdata = result.GetResponseStream();
                StreamReader reader = new StreamReader(resultdata);
                object objResponse = reader.ReadToEnd();
                var get = JsonConvert.DeserializeObject<ItemCount>(objResponse.ToString());
                valor = get.valor;
                resultdata.Close();
                result.Close();
                return valor;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro => \t" + e.Message);
                return 0;
            }
        }
        static async Task AddItemFilaAsync()
        {
            try
            {
                string Moeda = String.Empty;
                string Data_Inicio = String.Empty;
                string Data_Final = String.Empty;
                Console.WriteLine("Preencha os campos a abaixo.");
                Console.WriteLine("\nMoeda:");
                Moeda = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Preencha os campos a abaixo.");
                Console.WriteLine("\nMoeda:" + Moeda);
                Console.WriteLine("\nData de Inicio:");
                Data_Inicio = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Preencha os campos a abaixo.");
                Console.WriteLine("\nMoeda:" + Moeda);
                Console.WriteLine("\nData de Inicio:" + Data_Inicio);
                Console.WriteLine("\nData Final:");
                Data_Final = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Preencha os campos a abaixo.");
                Console.WriteLine("\nMoeda:" + Moeda);
                Console.WriteLine("\nData de Inicio:" + Data_Inicio);
                Console.WriteLine("\nData Final:" + Data_Final);
                Console.WriteLine("\nAperte qualquer tecla para continuar...");
                Console.ReadKey();
                Console.WriteLine("\nDesejar realmente adicionar este item?(Sim ou Não)");
                var result = Console.ReadLine();
                if (result.Contains("N") || result.Contains("n"))
                {
                    Console.Clear();
                    SelectOption();
                }
                Console.Clear();
                var JsonData = new ItemFila()
                {
                    moeda = Moeda,
                    data_inicio = Data_Inicio,
                    data_fim = Data_Final
                };
                var json = JsonConvert.SerializeObject(JsonData);
                using var AddItemFilaClient = new HttpClient();
                var response = await AddItemFilaClient.PostAsync("http://localhost:8080/json", new StringContent(json, Encoding.UTF8, "application/json"));
                await ItemCountAsync(true);
                Console.WriteLine("\nItem Adicionado!\nAperte qualquer tecla para continuar...");
                Console.ReadKey();
                BackMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao adicionar item => \t" + e.Message);
                Console.ReadKey();
                BackMenu();
            }
        }
        static async Task ItemCountAsync(bool status)
        {
            try
            {
                if (status)
                {
                    var JsonPut = new ItemCount()
                    {
                        valor = GetCount() + 1,
                    };
                    var json = JsonConvert.SerializeObject(JsonPut);
                    using var ItemCountClient = new HttpClient();
                    var result = await ItemCountClient.PutAsync("http://localhost:8080/count/1", new StringContent(json, Encoding.UTF8, "application/json"));
                }
                else
                {
                    var JsonPut = new ItemCount()
                    {
                        valor = GetCount() - 1,
                    };
                    var json = JsonConvert.SerializeObject(JsonPut);
                    using var ItemCountClient = new HttpClient();
                    var result = await ItemCountClient.PutAsync("http://localhost:8080/count/1", new StringContent(json, Encoding.UTF8, "application/json"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao validar a inserção/remoção de dados => \t" + e.Message);
                Console.ReadKey();
                BackMenu();
            }
        }
        static void BackMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Deseja voltar ao menu inicial?(Sim ou Não)");
                var result = Console.ReadLine();
                if (result.Contains("S") || result.Contains("s") || result.Contains("Y") || result.Contains("y"))
                {
                    Console.Clear();
                    SelectOption();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao voltar o menu => \t" + e.Message);
            }
        }
    }
}
