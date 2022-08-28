using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public static class Repository
    {
        public static StreamReader StreamReader(string Address)
        {
            StreamReader streamReader;
            FileStream file = new FileStream(Address, FileMode.Open);
            streamReader = new StreamReader(file);
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            return streamReader;
        }

        public static bool Uploader(string Folder, string File)
        {
            var client = new RestClient("http://api.parsaspace.com/v1/files/upload");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1bmlxdWVfbmFtZSI6Im1vdXNpYW5pMTM4M0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoiNTA5OTIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiIyIiwiaXNzIjoiaHR0cDovL2FwaS5wYXJzYXNwYWNlLmNvbS8iLCJhdWQiOiJBbnkiLCJleHAiOjE2NDE4MjM0OTAsIm5iZiI6MTYxMDI4NzQ5MH0.uymAXmDRqrc60FupQAwzQhMdUMTdE4_oa1qhmNt7Du8");
            request.AddHeader("content-type", "multipart/form-data");
            request.AddParameter("Domain", "quiz24exam.parsaspace.com");
            request.AddParameter("path", "/" + Folder + "/");
            request.AddFile("file", File);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Delete(string path)
        {
            var client = new RestClient("https://api.parsaspace.com/v2/files/remove");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1bmlxdWVfbmFtZSI6Im1vdXNpYW5pMTM4M0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoiNTA5OTIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiIyIiwiaXNzIjoiaHR0cDovL2FwaS5wYXJzYXNwYWNlLmNvbS8iLCJhdWQiOiJBbnkiLCJleHAiOjE2NDE4MjM0OTAsIm5iZiI6MTYxMDI4NzQ5MH0.uymAXmDRqrc60FupQAwzQhMdUMTdE4_oa1qhmNt7Du8");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Domain", "quiz24exam.parsaspace.com");
            request.AddParameter("path", "/" + path);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<string> List(string Folder)
        {
            List<string> list = new List<string>();
            StringReader stringr;
            list.Clear();
            Uri uri = new Uri("http://quiz24exam.parsaspace.com/");
            var client = new RestClient("http://api.parsaspace.com/v1/files/list");
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "Bearer " + "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1bmlxdWVfbmFtZSI6Im1vdXNpYW5pMTM4M0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoiNTA5OTIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiIyIiwiaXNzIjoiaHR0cDovL2FwaS5wYXJzYXNwYWNlLmNvbS8iLCJhdWQiOiJBbnkiLCJleHAiOjE2NDE4MjM0OTAsIm5iZiI6MTYxMDI4NzQ5MH0.uymAXmDRqrc60FupQAwzQhMdUMTdE4_oa1qhmNt7Du8");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("Domain", uri.Host);
            request.AddParameter("path", "/" + Folder);
            IRestResponse response = client.Execute(request);
            var json = JsonConvert.DeserializeObject(response.Content).ToString();
            stringr = new StringReader(json);
            string line = stringr.ReadLine(); ;
            while (line != null)
            {
                if (line.Contains("Name"))
                {
                    list.Add(line.Replace('"', ' ').Replace(',', ' ').Trim().ToString());
                }
                line = stringr.ReadLine();
            }
            stringr.Close();
            return list;
        }

        public static bool IsConnectedToInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                MessageBox.Show("اتصال اینترنت خود را بررسی کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
