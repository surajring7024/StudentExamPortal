using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;

using System.Net;
using System.Net.Mail;


namespace StudentExamPortal
{
 
    public class SQl_Details
    {
        SqlConnection con;
        SqlCommand cmd;
        public void getConnection()
        {
            con = new SqlConnection("Data Source=localhost;Initial Catalog=Student_Final_Project;Integrated Security=True;MultipleActiveResultSets=true");
            con.Open();
        }
        public void executeCMD(string cmdtext)
        {
             cmd = new SqlCommand(cmdtext, con);
            cmd.ExecuteNonQuery();
        }
        public object ExSc(string cmdtext)
        {
            cmd = new SqlCommand(cmdtext, con);
            return cmd.ExecuteScalar();
        }
        public object GetSqlDataReader(string cmdtext)
        {
            cmd = new SqlCommand(cmdtext, con);
            SqlDataReader r = cmd.ExecuteReader();
            return r;
        }
        public void CloseConnection()
        {
            con.Close();
        }
        public object GETSqlDataAdapter(string cmdtext)
        {
            SqlDataAdapter cmd = new SqlDataAdapter(cmdtext, con);
            return cmd;
        }
        public  void sendMail(string To1, string msg, string subject1)
        {

            using (SmtpClient smtp = new SmtpClient())
            {
                ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                MailMessage message = new MailMessage();

                message.From = new MailAddress("************************");
                message.To.Add(new MailAddress(To1));
                message.Subject = subject1;
                message.IsBodyHtml = false; //to make message body as html  
                message.Body = msg;
                //smtp.Port = 0;
                smtp.Host = "****";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(userName: "************", password: "*******");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(message);


            }
        }
    }
    public class AesOperation
    {
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}