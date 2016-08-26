using System;
using System.Net;
using System.IO;
using System.Text;
using System.Xml;

namespace ExchangeSDK.Snippets.CSharp
{
   class GettingItemPropertyValuesWebDAV
   {
      [STAThread]
      static void Main(string[] args)
      {
         // Variables.
         System.Net.HttpWebRequest Request;
         System.Net.WebResponse Response;
         System.Net.CredentialCache MyCredentialCache;
         string strSrcURI = "http://Server/public/TestFolder1/test.eml";
         string strUserName = "UserName";
         string strPassword = "!Password";
         string strDomain = "Domain";
         string strBody = "";
         byte[] bytes = null;
         System.IO.Stream RequestStream = null;
         System.IO.Stream ResponseStream = null;
         XmlDocument ResponseXmlDoc = null;
         XmlNodeList DisplayNameNodes = null;

         try
         {
            // Build the PROPFIND request body.
            strBody = "<?xml version=\"1.0\"?>"
                    + "<d:propfind xmlns:d='DAV:'><d:prop>"
                    + "<d:displayname/></d:prop></d:propfind>";

            // Create a new CredentialCache object and fill it with the network
            // credentials required to access the server.
            MyCredentialCache = new System.Net.CredentialCache();
            MyCredentialCache.Add( new System.Uri(strSrcURI),
               "NTLM",
               new System.Net.NetworkCredential(strUserName, strPassword, strDomain)
               );

            // Create the HttpWebRequest object.
            Request = (System.Net.HttpWebRequest)HttpWebRequest.Create(strSrcURI);

            // Add the network credentials to the request.
            Request.Credentials = MyCredentialCache;

            // Specify the method.
            Request.Method = "PROPFIND";

            // Encode the body using UTF-8.
            bytes = Encoding.UTF8.GetBytes((string)strBody);

            // Set the content header length.  This must be
            // done before writing data to the request stream.
            Request.ContentLength = bytes.Length;

            // Get a reference to the request stream.
            RequestStream = Request.GetRequestStream();

            // Write the request body to the request stream.
            RequestStream.Write(bytes, 0, bytes.Length);

            // Close the Stream object to release the connection
            // for further use.
            RequestStream.Close();

            // Set the content type header.
            Request.ContentType = "text/xml";

            // Send the PROPFIND method request and get the
            // response from the server.
            Response = (HttpWebResponse)Request.GetResponse();

            // Get the XML response stream.
            ResponseStream = Response.GetResponseStream();

            // Create the XmlDocument object from the XML response stream.
            ResponseXmlDoc = new XmlDocument();
            ResponseXmlDoc.Load(ResponseStream);

            // Build a list of the DAV:href XML nodes, corresponding to the folders
            // in the mailbox.  The DAV: namespace is typically assgigned the a:
            // prefix in the XML response body.
            DisplayNameNodes = ResponseXmlDoc.GetElementsByTagName("a:displayname");

            if(DisplayNameNodes.Count > 0)
            {
               // Display the item's display name.
               Console.WriteLine("DAV:displayname property...");
               Console.WriteLine(DisplayNameNodes[0].InnerText);
            }
            else
            {
               Console.WriteLine("DAV:displayname property not found...");
            }

            // Clean up.
            ResponseStream.Close();
            Response.Close();
         }
         catch(Exception ex)
         {
            // Catch any exceptions. Any error codes from the PROPFIND
            // method request on the server will be caught here, also.
            Console.WriteLine(ex.Message);
         }
      }
   }
}