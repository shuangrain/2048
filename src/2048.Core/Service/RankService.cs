using _2048.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2048.Core.Service
{
    public class RankService
    {
        public bool CanFindServer { get; set; }

        private static readonly string _serverUrl = ConfigurationManager.AppSettings["ServerUrl"];

        public Task<List<ScoreRankModel>> GetScoreAsync(ModeType modeType)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    CanFindServer = true;

                    string url = (modeType == ModeType.None) ? _serverUrl : $"{_serverUrl}/{(int)modeType}";
                    string json = doRequest("GET", url);
                    return JsonConvert.DeserializeObject<List<ScoreRankModel>>(json);
                }
                catch
                {
                    CanFindServer = false;
                    return null;
                }
            });
        }

        public Task<BaseModel> PostScoreAsync(ScoreRankModel model)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    string requestJson = JsonConvert.SerializeObject(model);
                    string responseJson = doRequest("POST", _serverUrl, requestJson);
                    return JsonConvert.DeserializeObject<BaseModel>(responseJson);
                }
                catch
                {
                    return new BaseModel
                    {
                        RtnCode = 999,
                        RtnMsg = "系統繁忙中，請稍後再試。"
                    };
                }
            });
        }

        /// <summary>
        /// 檢查該分數是否可以刷新排行榜
        /// </summary>
        /// <param name="modeType"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool CanAddRank(ModeType modeType, int score)
        {
            var list = GetScoreAsync(modeType).Result;
            return (list == null) || (list.Count < 10) || (list.Any(x => score >= x.Score));
        }

        private string doRequest(string method, string url, string data = null)
        {
            if (string.IsNullOrWhiteSpace(_serverUrl))
            {
                return null;
            }

            //如果是https請求
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                // 忽略憑證
                ServicePointManager.ServerCertificateValidationCallback =
                        new RemoteCertificateValidationCallback((s, cert, chain, errors) => true);
            }

            //### 建立HttpWebRequest物件
            HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.ProtocolVersion = HttpVersion.Version10;

            httpWebRequest.Method = method;
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)";
            httpWebRequest.Accept = "text/html";
            httpWebRequest.Referer = "https://blog.exfast.me";

            //### 設定content type, it is required, otherwise it will not work.
            httpWebRequest.ContentType = "application/json";

            //設定Timeout時間(單位毫秒)
            httpWebRequest.Timeout = 60 * 1000;

            httpWebRequest.Headers.Add("Authorization", "Bearer D01D75D2-6018-4E66-96F1-E8FFEC1DC7CE");

            //### 預設回傳的資料
            string receiveData = "Post Data Error";

            try
            {
                if (httpWebRequest.Method != "GET")
                {
                    //### 取得request stream 並且寫入post data
                    using (StreamWriter sw = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        //### 設定要送出的參數; separated by "&"
                        sw.Write(data ?? string.Empty);
                        sw.Flush();
                        sw.Close();
                    }
                }

                //### 取得server的reponse結果
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8))
                {
                    receiveData = sr.ReadToEnd();
                    sr.Close();
                }

                httpWebResponse.Close();
            }
            catch (Exception exception)
            {
                receiveData = exception.ToString();
            }

            return receiveData;
        }
    }
}
