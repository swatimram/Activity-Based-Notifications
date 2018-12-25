using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;
namespace NotificationClient
{
    class GCMAlert
    {

        public static string Send(string message, string deviceId)
        {
            string GoogleAppID = "AIzaSyB_wKz-SfL5MmEv5XPfsD_0U-NhtqCk2o8";
            var PROJECT_ID = "968912281773";
            var value = message;
            WebRequest tRequest;
            tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));

            tRequest.Headers.Add(string.Format("Sender: id={0}", PROJECT_ID));

            string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + deviceId + "";
            Console.WriteLine(postData);
            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;


            Stream dataStream = tRequest.GetRequestStream();
            System.Threading.Thread.Sleep(1000);
            dataStream.Write(byteArray, 0, byteArray.Length);
            System.Threading.Thread.Sleep(1000);
            dataStream.Close();

            WebResponse tResponse = tRequest.GetResponse();
            System.Threading.Thread.Sleep(1000);
            dataStream = tResponse.GetResponseStream();

            StreamReader tReader = new StreamReader(dataStream);

            String sResponseFromServer = tReader.ReadToEnd();


            tReader.Close();
            dataStream.Close();
            tResponse.Close();
            return sResponseFromServer;
        }

    }

}
