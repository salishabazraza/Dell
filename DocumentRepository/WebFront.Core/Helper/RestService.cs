using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebFront.Core.Models;

namespace WebFront.Core.Helper
{
    public class RestService
    {
        private readonly HttpClient client;

        private readonly string WSUrl;
        public RestService(IConfiguration config)
        {
            client = new HttpClient();
            WSUrl = config.GetValue<string>(
                "AppIdentitySettings:ApiUrl");
        }

        public async Task<APISystemReturnModel<LoginApiModel>> GetLoginApi(LoginModel model)
        {

            if (client.DefaultRequestHeaders.Authorization == null)
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("X-Version", "1.0");
                // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                //    ($"Bearer", $"{accessToken}");
            }

            var uri = new Uri(string.Format("{0}/Authentication/Login", WSUrl));
            var json = JsonConvert.SerializeObject(model);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

            var result = new APISystemReturnModel<LoginApiModel>();

            try
            {
                var response = await client.PostAsync(uri, contentJson);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    result = JsonConvert.DeserializeObject<APISystemReturnModel<LoginApiModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"[{1}]ERROR {0}", result.code + " " + result.description, "Login");
            }
            return result;
        }




        public async Task<APISystemReturnModel<ObservableCollection<DocumentAPIModel>>> GetDocuments(string accessToken)
        {
            if (client.DefaultRequestHeaders.Authorization == null)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Version", "1.0");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;


            }

            var uri = new Uri(string.Format("{0}/Document/all/records?pageNo=1", WSUrl));
            var result = new APISystemReturnModel<ObservableCollection<DocumentAPIModel>>();
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<APISystemReturnModel<ObservableCollection<DocumentAPIModel>>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"[{1}]ERROR {0}", ex.Message, "Login");
            }
            return result;
        }

        public async Task<APISystemReturnModel<ObservableCollection<Document>>> GetDocumentsSearch(string accessToken, int[] keywordId)
        {
            if (client.DefaultRequestHeaders.Authorization == null)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Version", "1.0");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;


            }

            var uri = new Uri(string.Format("{0}/Keyword/search/documents?pageNo=1", WSUrl));

            var json = JsonConvert.SerializeObject(keywordId);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

            var result = new APISystemReturnModel<ObservableCollection<Document>>();
            try
            {
                var response = await client.PostAsync(uri, contentJson);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<APISystemReturnModel<ObservableCollection<Document>>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"[{1}]ERROR {0}", ex.Message, "Login");
            }
            return result;
        }


        public async Task<APISystemReturnModel<DocumentAPIModel>> GetDocument(string accessToken,string Id)
        {
            if (client.DefaultRequestHeaders.Authorization == null)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Version", "1.0");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;


            }

            var uri = new Uri(string.Format("{0}/Document/record/"+Id, WSUrl));
            var result = new APISystemReturnModel<DocumentAPIModel>();
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<APISystemReturnModel<DocumentAPIModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"[{1}]ERROR {0}", ex.Message, "Login");
            }
            return result;
        }


        public async Task<APISystemReturnModel<ObservableCollection<KeywordsAPIModel>>> GetKeywords(string accessToken)
        {
            if (client.DefaultRequestHeaders.Authorization == null)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Version", "1.0");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;


            }

            var uri = new Uri(string.Format("{0}/Keyword/all/records", WSUrl));
            var result = new APISystemReturnModel<ObservableCollection<KeywordsAPIModel>>();
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<APISystemReturnModel<ObservableCollection<KeywordsAPIModel>>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"[{1}]ERROR {0}", ex.Message, "Login");
            }
            return result;
        }

        public async Task<APISystemReturnModel<KeywordsAPIModel>> GetKeyword(string accessToken, string Id)
        {
            if (client.DefaultRequestHeaders.Authorization == null)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Version", "1.0");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;


            }

            var uri = new Uri(string.Format("{0}/Keyword/get/"+Id, WSUrl));
            var result = new APISystemReturnModel<KeywordsAPIModel>();
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<APISystemReturnModel<KeywordsAPIModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"[{1}]ERROR {0}", ex.Message, "Login");
            }
            return result;
        }

       

        public async Task<APISystemReturnModel<KeywordCreateandUpdateModel>> PostSaveAandUpdateKeyword(string accessToken, KeywordCreateandUpdateModel model)
        {
            if (client.DefaultRequestHeaders.Authorization == null)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Version", "1.0");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;


            }

            var uri = new Uri(string.Format("{0}/Keyword/saveorupdate", WSUrl));
            List<KeywordCreateandUpdateModel> li = new List<KeywordCreateandUpdateModel>();
            li.Add(model);
            var json = JsonConvert.SerializeObject(li);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

            var result = new APISystemReturnModel<KeywordCreateandUpdateModel>();
            try
            {
                var response = await client.PostAsync(uri, contentJson);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<APISystemReturnModel<KeywordCreateandUpdateModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"[{1}]ERROR {0}", ex.Message, "Login");
            }
            return result;
        }



        public async Task<APISystemReturnModel<KeywordDocumentAPIModel>> PostSaveAandUpdateDocument(string accessToken, KeywordDocumentAPIModel model)
        {
            if (client.DefaultRequestHeaders.Authorization == null)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Version", "1.0");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;


            }

            var uri = new Uri(string.Format("{0}/Keyword/mapping/document/saveorupdate", WSUrl));
           
            var json = JsonConvert.SerializeObject(model);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

            var result = new APISystemReturnModel<KeywordDocumentAPIModel>();
            try
            {
                var response = await client.PostAsync(uri, contentJson);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<APISystemReturnModel<KeywordDocumentAPIModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"[{1}]ERROR {0}", ex.Message, "Login");
            }
            return result;
        }

        public async Task<APISystemReturnModel<string>> DelKeyword(string accessToken, string keywordId)
        {
            if (client.DefaultRequestHeaders.Authorization == null)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Version", "1.0");
                var authheader = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Authorization = authheader;


            }

            var uri = new Uri(string.Format("{0}/Keyword/Delete/Keyword?keywordId=" + keywordId, WSUrl));
            var result = new APISystemReturnModel<string>();
            try
            {
                var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<APISystemReturnModel<string>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"[{1}]ERROR {0}", ex.Message, "Login");
            }
            return result;
        }


    }
}
