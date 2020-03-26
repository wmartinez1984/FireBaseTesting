using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
namespace FireBaseTesting.ActivosFinancieros
{
    public partial class Simulador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static void GenerarCalculos(string[] DataList)
        {

            string[] dataList = DataList;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string apikey = "TP7N016HS7WSW4AQ|R67BCSM6M48U3UXP|4FBIG5TULRH84VFD|Z235P5V28NJAO6GF|SRNXB4IHEWRLEJH7|MJRQQRSU4P91WRCN|32MXJLRO8ZLVNP0O|TLKQAFU3U488YD50|GUK1VEFW5NZE4M0M|2QMKXM3TEOAM9PGF|5S2GD09CXEC2DIV5|M8BIRNAJFHTYQW6Q|";
            string series_type = "open";
            string time_period = "2";
            string interval = "weekly";
            string symbol = "AMZN";
            string indicador = "SMA";
            string Sesiones = "1000";

            int RapidaInicial = 2;
            int RapidaFinal = 15;
            int LentaInicial = 16;
            int LentaFinal = 60;

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("TechnicalAnalysis");
            var SenalSheet1 = excel.Workbook.Worksheets.Add("Señales"); //Pestaña de señales

            // setting the properties 
            // of the work sheet  
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            SenalSheet1.TabColor = System.Drawing.Color.Brown;
            SenalSheet1.DefaultRowHeight = 12;

            // Setting the properties 
            // of the first row 
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            SenalSheet1.Row(1).Height = 30;
            SenalSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            SenalSheet1.Row(1).Style.Font.Bold = true;

            // Header of the Excel sheet 
            workSheet.Cells[1, 1].Value = "Fecha";
            //Creamos 59 columnas más, en total 60
            for (int i = 2; i <= LentaFinal; i++)
            {
                workSheet.Cells[1, i].Value = i.ToString();
            }


            int NumPeriodo = int.Parse(time_period);

            var countCall = 0;
            var TotalCall = LentaFinal;
            var Keys = apikey.Split('|');
            int TotalEjecutadas = 0;
            var dataTechnicaList = new List<DataTechnical>();
            DataTechnical dataTechnical = new DataTechnical();
            try
            {
                int EjecutarProxy = 1;
                for (var i = 0; i < Keys.Length; i++)
                {
                   
                    if (Keys[i] != "")
                    {
                        countCall += 1;
                        if (countCall < TotalCall)
                        {

                            //Aquí van las ejecuciones 



                            using (WebClient webClient = new System.Net.WebClient())
                            {
                                int countTime = 0;
                                bool retry = false;
                                do
                                {
                                    retry = false;
                                    try
                                    {
                                        webClient.Encoding = Encoding.UTF8;
                                        webClient.Encoding = UTF8Encoding.UTF8;
                                        webClient.Headers.Add("Content-Type", "application/json");

                                        //Ejecutan individualmente
                                        if (EjecutarProxy == 1)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");

                                        }

                                        if (EjecutarProxy == 2)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf", "8jcnmagkxr9x");
                                        }

                                        if (EjecutarProxy == 3)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2", "hm0pssiuy51s");
                                        }

                                        if (EjecutarProxy == 4)
                                        {

                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-fr", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 5)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-de", "8jcnmagkxr9x");

                                        }


                                        if (EjecutarProxy == 6)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-co", "8jcnmagkxr9x");
                                        }

                                        if (EjecutarProxy == 7)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-country-it", "hm0pssiuy51s");
                                        }

                                        if (EjecutarProxy == 8)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-ar", "950qr9c3oy74");

                                        }

                                        if (EjecutarProxy == 9)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-bg", "950qr9c3oy74");
                                        }

                                        if (EjecutarProxy == 10)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
                                        }

                                        if (EjecutarProxy == 11)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block", "950qr9c3oy74");
                                        }

                                        if (EjecutarProxy == 12)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block", "8jcnmagkxr9x");
                                        }

                                        if (EjecutarProxy == 13)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block-country-us", "8jcnmagkxr9x");

                                        }

                                        if (EjecutarProxy == 14)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block-country-ie", "950qr9c3oy74");
                                        }

                                        if (EjecutarProxy == 15)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 16)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
                                        }


                                        if (EjecutarProxy == 18)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-route_err-block", "hm0pssiuy51s");
                                        }

                                        if (EjecutarProxy == 19)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 20)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

                                        }

                                        if (EjecutarProxy == 21)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

                                        }

                                        if (EjecutarProxy == 22)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4", "dkynyah79ep4");
                                        }

                                        if (EjecutarProxy == 23)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-gb", "dkynyah79ep4");
                                        }

                                        if (EjecutarProxy == 24)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-us", "dkynyah79ep4");
                                        }

                                        if (EjecutarProxy == 25)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-al", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 26)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-au", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 27)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-eg", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 28)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-fi", "dkynyah79ep4");
                                        }

                                        if (EjecutarProxy == 29)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5", "ihz4r4y1afpi");
                                        }

                                        if (EjecutarProxy == 30)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-cn", "ihz4r4y1afpi");
                                        }

                                        if (EjecutarProxy == 31)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-in", "ihz4r4y1afpi");
                                        }

                                        if (EjecutarProxy == 32)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-in", "nk9fkr5guhqo");
                                        }

                                        if (EjecutarProxy == 33)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-id", "nk9fkr5guhqo");
                                        }


                                        if (EjecutarProxy == 33)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-au", "nk9fkr5guhqo");
                                        }

                                        if (EjecutarProxy == 33)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-ar", "nk9fkr5guhqo");
                                        }

                                        if (EjecutarProxy == 34)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-uz", "nk9fkr5guhqo");
                                        }

                                        if (EjecutarProxy == 35)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-uz", "hmgkn0ztpad0");
                                        }


                                        //******************************************************************************************
                                        if (EjecutarProxy == 36)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");

                                        }

                                        if (EjecutarProxy == 37)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf", "8jcnmagkxr9x");
                                        }

                                        if (EjecutarProxy == 38)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2", "hm0pssiuy51s");
                                        }

                                        if (EjecutarProxy == 39)
                                        {

                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-fr", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 40)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-de", "8jcnmagkxr9x");

                                        }


                                        if (EjecutarProxy == 41)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-co", "8jcnmagkxr9x");
                                        }

                                        if (EjecutarProxy == 42)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-country-it", "hm0pssiuy51s");
                                        }

                                        if (EjecutarProxy == 43)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-ar", "950qr9c3oy74");

                                        }

                                        if (EjecutarProxy == 44)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-country-bg", "950qr9c3oy74");
                                        }

                                        if (EjecutarProxy == 45)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
                                        }

                                        if (EjecutarProxy == 46)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block", "950qr9c3oy74");
                                        }

                                        if (EjecutarProxy == 47)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block", "8jcnmagkxr9x");
                                        }

                                        if (EjecutarProxy == 48)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-route_err-block-country-us", "8jcnmagkxr9x");

                                        }

                                        if (EjecutarProxy == 49)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3-route_err-block-country-ie", "950qr9c3oy74");
                                        }

                                        if (EjecutarProxy == 50)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 51)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef3", "950qr9c3oy74");
                                        }


                                        if (EjecutarProxy == 52)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf2-route_err-block", "hm0pssiuy51s");
                                        }

                                        if (EjecutarProxy == 53)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 54)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

                                        }

                                        if (EjecutarProxy == 55)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block-country-be", "hmgkn0ztpad0");

                                        }

                                        if (EjecutarProxy == 56)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4", "dkynyah79ep4");
                                        }

                                        if (EjecutarProxy == 57)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-gb", "dkynyah79ep4");
                                        }

                                        if (EjecutarProxy == 58)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-us", "dkynyah79ep4");
                                        }

                                        if (EjecutarProxy == 59)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-al", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 60)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-au", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 61)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-country-eg", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 62)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef4-country-fi", "dkynyah79ep4");
                                        }

                                        if (EjecutarProxy == 63)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5", "ihz4r4y1afpi");
                                        }

                                        if (EjecutarProxy == 64)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-cn", "ihz4r4y1afpi");
                                        }

                                        if (EjecutarProxy == 65)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef5-country-in", "ihz4r4y1afpi");
                                        }

                                        if (EjecutarProxy == 66)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef6-country-in", "nk9fkr5guhqo");
                                        }

                                        if (EjecutarProxy == 67)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 68)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef7", "bs8i0wjbemwf");
                                        }

                                        if (EjecutarProxy == 69)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef7", "bs8i0wjbemwf");
                                        }

                                        if (EjecutarProxy == 70)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef7", "bs8i0wjbemwf");
                                        }

                                        if (EjecutarProxy == 71)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8", "hoa63y623ppr");
                                        }

                                        if (EjecutarProxy == 72)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8", "hoa63y623ppr");
                                        }

                                        if (EjecutarProxy == 74)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8", "hoa63y623ppr");
                                        }

                                        if (EjecutarProxy == 75)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zonef8-route_err-block", "hoa63y623ppr");
                                        }

                                        if (EjecutarProxy == 76)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 77)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 78)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-static-route_err-block", "hmgkn0ztpad0");
                                        }

                                        if (EjecutarProxy == 79)
                                        {
                                            webClient.Proxy = new WebProxy("zproxy.lum-superproxy.io:22225");
                                            webClient.Proxy.Credentials = new NetworkCredential("lum-customer-hl_7378269a-zone-zoneaf-country-de", "8jcnmagkxr9x");

                                        }

                                        var json = webClient.DownloadString("https://www.alphavantage.co/query?function=" + indicador + "&symbol=" + symbol + "&interval=" + interval + "&time_period=" + NumPeriodo + "&series_type=" + series_type + "&apikey=" + Keys[i] + "");
                                        JObject Search = JObject.Parse(json);

                                        IList<JToken> results = Search["Technical Analysis: " + indicador + ""].ToList();
                                        EjecutarProxy++;

                                        int count = 1;
                                        // Inserting the  data into excel 

                                        int recordIndex = 2;
                                        int DataCount = 0;
                                        int sessiones = 15;
                                        int sessionesCount = 0;
                                        foreach (JToken result in results)
                                        {
                                            if (count <= int.Parse(Sesiones))
                                            {

                                                dataTechnical.Name = ((Newtonsoft.Json.Linq.JProperty)result).Name.ToString();

                                                JObject RowsTable = JObject.Parse(((Newtonsoft.Json.Linq.JProperty)result).Value.ToString());
                                                foreach (KeyValuePair<string, JToken> property in RowsTable)
                                                {
                                                    dataTechnical.Value = property.Value.ToString();
                                                }

                                                if (NumPeriodo == 2)//sí es la primera,lleno la columna con las fechas
                                                    workSheet.Cells[recordIndex, 1].Value = dataTechnical.Name;

                                                workSheet.Cells[recordIndex, NumPeriodo].Value = dataTechnical.Value;


                                                recordIndex++;

                                                count += 1;

                                            }
                                            else
                                                break;


                                        }

                                        //ajusto la columna que llené 
                                        workSheet.Column(NumPeriodo).AutoFit();

                                    }
                                    catch (Exception ex)
                                    {
                                        if (countTime < 300)
                                        {
                                            retry = true;
                                            EjecutarProxy++;
                                            if(EjecutarProxy >= 66)
                                            {
                                                Thread.Sleep(1000);
                                                EjecutarProxy = 1;
                                            }                                              

                                            countTime++;
                                        }
                                        else
                                        {
                                            throw ex;
                                        }
                                    }
                                } while (retry);


                            }

                            NumPeriodo = NumPeriodo + 1;
                            TotalEjecutadas = i + 1;
                            if (TotalEjecutadas == Keys.Length && countCall < TotalCall)
                                i = 0;

                        }
                        else
                        {
                            break;
                        }


                    }

                    TotalEjecutadas = i + 1;
                    if (TotalEjecutadas == Keys.Length && countCall < TotalCall)
                        i = 0;
                }

                //cálculo  de  Señales
                try
                {


                    int RapidaInicialColum = RapidaInicial;
                    int ColumInicial = 1;
                    for (int s = RapidaInicial; s < RapidaFinal; s++)
                    {
                        int LentaInicialRows = LentaInicial;
                        for (int c = ColumInicial; c <= (((LentaFinal - LentaInicial) + ColumInicial)); c++)
                        {
                            SenalSheet1.Cells[1, c].Value = "Señal (" + s + ", " + LentaInicialRows + ") ";

                            //Primera fila por default
                            SenalSheet1.Cells[2, c].Value = "SELL ( " + s + " = " + decimal.Parse(workSheet.Cells[2, s].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[2, LentaInicialRows].Value + ")";
                            SenalSheet1.Row(2).Style.Font.Bold = true;
                            SenalSheet1.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            //Señales por columna
                            for (int f = 3; f <= int.Parse(Sesiones); f++)
                            {
                                if (workSheet.Cells[f, s].Value != null && workSheet.Cells[s, LentaInicialRows].Value != null)
                                {
                                    decimal C1 = decimal.Parse(workSheet.Cells[f, s].Value.ToString());
                                    decimal C2 = decimal.Parse(workSheet.Cells[f, LentaInicialRows].Value.ToString());
                                    decimal C3 = decimal.Parse(workSheet.Cells[f + 1, s].Value.ToString());
                                    decimal C4 = decimal.Parse(workSheet.Cells[f + 1, LentaInicialRows].Value.ToString());

                                    string strSenal = "";

                                    if (C1 > C2 && C4 > C3)
                                        strSenal = "BUY";
                                    else if (C1 < C2 && C3 > C4)
                                        strSenal = "SELL";
                                    else
                                        strSenal = "NEUTRO";

                                    //SenalSheet1.Cells[f, c].Value = "SELL.." + workSheet.Cells[f, s].Value + ":"+ workSheet.Cells[f, LentaInicialRows].Value;
                                    SenalSheet1.Cells[f, c].Value = "" + strSenal + " ( " + s + " = " + decimal.Parse(workSheet.Cells[f, s].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[f, LentaInicialRows].Value + ")";
                                }


                            }
                            //última fila por default
                            SenalSheet1.Cells[int.Parse(Sesiones) + 1, c].Value = "NEUTRO ( " + s + " = " + decimal.Parse(workSheet.Cells[int.Parse(Sesiones) + 1, s].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[int.Parse(Sesiones) + 1, LentaInicialRows].Value + ")";
                            SenalSheet1.Row(int.Parse(Sesiones) + 1).Style.Font.Bold = true;
                            SenalSheet1.Row(int.Parse(Sesiones) + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                            LentaInicialRows += 1;
                            SenalSheet1.Row(1).Height = 30;
                            SenalSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            SenalSheet1.Row(1).Style.Font.Size = 12;
                            SenalSheet1.Row(1).Style.Font.Bold = true;
                            SenalSheet1.Column(c).AutoFit();

                        }

                        ColumInicial += (LentaFinal - LentaInicial) + 1;



                    }

                    string p_strPathLog1 = Server.MapPath("DadaExcel/log.txt").ToString();
                    if (File.Exists(p_strPathLog1))
                        File.Delete(p_strPathLog1);


                    using (StreamWriter _testData = new StreamWriter(Server.MapPath("DadaExcel/log.txt"), true))
                    {
                        _testData.WriteLine("Proceso de señales correcto + " + DateTime.Now.ToString() + "");
                    }
                }
                catch (Exception ex)
                {
                    string p_strPathLog2 = Server.MapPath("DadaExcel/log.txt").ToString();
                    if (File.Exists(p_strPathLog2))
                        File.Delete(p_strPathLog2);


                    using (StreamWriter _testData = new StreamWriter(Server.MapPath("DadaExcel/log.txt"), true))
                    {
                        _testData.WriteLine("Error señales: " + ex.ToString() + ", " + DateTime.Now.ToString() + "");
                    }
                }


                // file name with .xlsx extension  
                //string p_strPath = context.Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString();
                string p_strPath = Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString();

                if (File.Exists(p_strPath))
                    File.Delete(p_strPath);

                // Create excel file on physical disk  
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                // Write content to excel file  
                File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
                //Close Excel package 
                excel.Dispose();

                string p_strPathLog = Server.MapPath("DadaExcel/log.txt").ToString();
                if (File.Exists(p_strPathLog))
                    File.Delete(p_strPathLog);


                using (StreamWriter _testData = new StreamWriter(Server.MapPath("DadaExcel/log.txt"), true))
                {
                    _testData.WriteLine("Ha terminado el proceso correctamente + " + DateTime.Now.ToString() + "");
                }
               // lblMensaje.Text = "Final del proceso";
               
            }
            catch (Exception ex)
            {

               // lblMensaje.Text = ex.ToString();


                string p_strPathLog = Server.MapPath("DadaExcel/log.txt").ToString();
                if (File.Exists(p_strPathLog))
                    File.Delete(p_strPathLog);


                using (StreamWriter _testData = new StreamWriter(Server.MapPath("DadaExcel/log.txt"), true))
                {
                    _testData.WriteLine("Error: " + ex.ToString() + ", " + DateTime.Now.ToString() + "");
                }

                dataTechnical.Name = "Error";
                dataTechnical.Value = ex.ToString().Substring(0, 20);

            }

        }


        public class DataTechnical
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public int count { get; set; }
            public   int  Colum { get; set; }
        }


        public  void CargarDataLocal()
        {

            // Iterate through the rows of the table.
           


            var ls = new List<ExcelData>();
            List<string> excelData = new List<string>();

            // if you use asp.net, get the relative path
            byte[] bin = File.ReadAllBytes(Server.MapPath("DadaExcel/TechnicalAnalysis.xlsx"));

            //create a new Excel package in a memorystream
            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                //loop all worksheets
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    //loop all rows
                    for (int i = worksheet.Dimension.Start.Row ; i <= worksheet.Dimension.End.Row; i++)
                    {
                        //loop all columns in a row


                       

                       
                    }
                }
            }

            DataTechnicalExcel(ls);
        }
        //public void DataTechnicalExcel(IEnumerable<DataTechnical> dataTechnicals, HttpContext context)
        public void DataTechnicalExcel(List<ExcelData> Data)
        {

            

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("TechnicalAnalysis");
            var SenalSheet1 = excel.Workbook.Worksheets.Add("Señales"); //Pestaña de señales

            // setting the properties 
            // of the work sheet  
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            SenalSheet1.TabColor = System.Drawing.Color.Brown;
            SenalSheet1.DefaultRowHeight = 12;

            // Setting the properties 
            // of the first row 
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            SenalSheet1.Row(1).Height = 30;
            SenalSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            SenalSheet1.Row(1).Style.Font.Bold = true;
           
            // Header of the Excel sheet 
            workSheet.Cells[1, 1].Value = "Fecha";
            //Creamos 59 columnas más, en total 60
            for (int i = 2; i <= 60; i++)
            {
                workSheet.Cells[1, i].Value = i.ToString();
            }

            // Inserting the  data into excel 
            // sheet by using the for each loop 
            // As we have values to the first row  
            // we will start with second row 
            int recordIndex = 2;
            int DataCount = 0;
            int sessiones = 15;
            int sessionesCount = 0;
            foreach (var data in Data)
            {
                if (sessionesCount < (sessiones))
                {
                    if (DataCount > 0)
                    {
                        sessionesCount++;
                        workSheet.Cells[recordIndex, 1].Value = data.Col1;
                        workSheet.Cells[recordIndex, 2].Value = data.Col2;
                        workSheet.Cells[recordIndex, 3].Value = data.Col3;
                        workSheet.Cells[recordIndex, 4].Value = data.Col4;
                        workSheet.Cells[recordIndex, 5].Value = data.Col5;
                        workSheet.Cells[recordIndex, 6].Value = data.Col6;
                        workSheet.Cells[recordIndex, 7].Value = data.Col7;
                        workSheet.Cells[recordIndex, 8].Value = data.Col8;
                        workSheet.Cells[recordIndex, 9].Value = data.Col9;
                        workSheet.Cells[recordIndex, 10].Value = data.Col10;

                        workSheet.Cells[recordIndex, 11].Value = data.Col11;
                        workSheet.Cells[recordIndex, 12].Value = data.Col12;
                        workSheet.Cells[recordIndex, 13].Value = data.Col13;
                        workSheet.Cells[recordIndex, 14].Value = data.Col14;
                        workSheet.Cells[recordIndex, 15].Value = data.Col15;
                        workSheet.Cells[recordIndex, 16].Value = data.Col16;
                        workSheet.Cells[recordIndex, 17].Value = data.Col17;
                        workSheet.Cells[recordIndex, 18].Value = data.Col18;
                        workSheet.Cells[recordIndex, 19].Value = data.Col19;
                        workSheet.Cells[recordIndex, 20].Value = data.Col20;

                        workSheet.Cells[recordIndex, 21].Value = data.Col21;
                        workSheet.Cells[recordIndex, 22].Value = data.Col22;
                        workSheet.Cells[recordIndex, 23].Value = data.Col23;
                        workSheet.Cells[recordIndex, 24].Value = data.Col24;
                        workSheet.Cells[recordIndex, 25].Value = data.Col25;
                        workSheet.Cells[recordIndex, 26].Value = data.Col26;
                        workSheet.Cells[recordIndex, 27].Value = data.Col27;
                        workSheet.Cells[recordIndex, 28].Value = data.Col28;
                        workSheet.Cells[recordIndex, 29].Value = data.Col29;
                        workSheet.Cells[recordIndex, 30].Value = data.Col30;

                        workSheet.Cells[recordIndex, 31].Value = data.Col31;
                        workSheet.Cells[recordIndex, 32].Value = data.Col32;
                        workSheet.Cells[recordIndex, 33].Value = data.Col33;
                        workSheet.Cells[recordIndex, 34].Value = data.Col34;
                        workSheet.Cells[recordIndex, 35].Value = data.Col35;
                        workSheet.Cells[recordIndex, 36].Value = data.Col36;
                        workSheet.Cells[recordIndex, 37].Value = data.Col37;
                        workSheet.Cells[recordIndex, 38].Value = data.Col38;
                        workSheet.Cells[recordIndex, 39].Value = data.Col39;
                        workSheet.Cells[recordIndex, 40].Value = data.Col40;

                        workSheet.Cells[recordIndex, 41].Value = data.Col41;
                        workSheet.Cells[recordIndex, 42].Value = data.Col42;
                        workSheet.Cells[recordIndex, 43].Value = data.Col43;
                        workSheet.Cells[recordIndex, 44].Value = data.Col44;
                        workSheet.Cells[recordIndex, 45].Value = data.Col45;
                        workSheet.Cells[recordIndex, 46].Value = data.Col46;
                        workSheet.Cells[recordIndex, 47].Value = data.Col47;
                        workSheet.Cells[recordIndex, 48].Value = data.Col48;
                        workSheet.Cells[recordIndex, 49].Value = data.Col49;
                        workSheet.Cells[recordIndex, 50].Value = data.Col50;

                        workSheet.Cells[recordIndex, 51].Value = data.Col51;
                        workSheet.Cells[recordIndex, 52].Value = data.Col52;
                        workSheet.Cells[recordIndex, 53].Value = data.Col53;
                        workSheet.Cells[recordIndex, 54].Value = data.Col54;
                        workSheet.Cells[recordIndex, 55].Value = data.Col55;
                        workSheet.Cells[recordIndex, 56].Value = data.Col56;
                        workSheet.Cells[recordIndex, 57].Value = data.Col57;
                        workSheet.Cells[recordIndex, 58].Value = data.Col58;
                        workSheet.Cells[recordIndex, 59].Value = data.Col59;
                        workSheet.Cells[recordIndex, 60].Value = data.Col60;
                        recordIndex++;
                        
                    }

                    DataCount++;
                }
            }

            // By default, the column width is not  
            // set to auto fit for the content 
            // of the range, so we are using 
            // AutoFit() method here.  
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();


            //cálculo  de  Señales
            int RapidaInicial = 2;
            int RapidaFinal = 15;
            int LentaInicial = 16;
            int LentaFinal = 60;

            
            int RapidaInicialColum = RapidaInicial;
            int ColumInicial = 1;
            for (int s = RapidaInicial; s <= RapidaFinal; s++)
            {
                int LentaInicialRows = LentaInicial;
                for (int c = ColumInicial; c <= (((LentaFinal - LentaInicial) + ColumInicial)); c++)
                {
                    SenalSheet1.Cells[1, c].Value = "Señal (" + s + ", " + LentaInicialRows + ") ";

                    //Primera fila por default
                    SenalSheet1.Cells[2, c].Value = "SELL ( " + s + " = " + decimal.Parse(workSheet.Cells[2, s].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[2, LentaInicialRows].Value + ")";
                    SenalSheet1.Row(2).Style.Font.Bold = true;
                    SenalSheet1.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    //Señales por columna
                    for (int f = 3; f <= sessiones; f++)
                    {
                        if(workSheet.Cells[f, s].Value != null && workSheet.Cells[s, LentaInicialRows].Value != null)
                        {
                            decimal C1 = decimal.Parse(workSheet.Cells[f, s].Value.ToString());
                            decimal C2 = decimal.Parse(workSheet.Cells[f, LentaInicialRows].Value.ToString());
                            decimal C3 = decimal.Parse(workSheet.Cells[f + 1, s].Value.ToString());
                            decimal C4 = decimal.Parse(workSheet.Cells[f + 1, LentaInicialRows].Value.ToString());

                            string strSenal = "";

                            if (C1 > C2 && C4 > C3)
                                strSenal = "BUY";
                            else if (C1 < C2 && C3 > C4)
                                strSenal = "SELL";
                            else
                                strSenal = "NEUTRO";
    
                            //SenalSheet1.Cells[f, c].Value = "SELL.." + workSheet.Cells[f, s].Value + ":"+ workSheet.Cells[f, LentaInicialRows].Value;
                            SenalSheet1.Cells[f, c].Value = ""+ strSenal  + " ( "+ s +" = " + decimal.Parse(workSheet.Cells[f, s].Value.ToString()) + ",  "+ LentaInicialRows + " = " + workSheet.Cells[f, LentaInicialRows].Value +")";
                        }

                       
                    }
                    //última fila por default
                    SenalSheet1.Cells[sessiones + 1, c].Value =  "NEUTRO ( " + s + " = " + decimal.Parse(workSheet.Cells[sessiones + 1, s].Value.ToString()) + ",  " + LentaInicialRows + " = " + workSheet.Cells[sessiones + 1, LentaInicialRows].Value + ")";
                    SenalSheet1.Row(sessiones + 1).Style.Font.Bold = true;
                    SenalSheet1.Row(sessiones + 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                    LentaInicialRows += 1;
                    SenalSheet1.Row(1).Height = 30;
                    SenalSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    SenalSheet1.Row(1).Style.Font.Size = 12;
                    SenalSheet1.Row(1).Style.Font.Bold = true;
                    SenalSheet1.Column(c).AutoFit();

                }
                
                ColumInicial += (LentaFinal - LentaInicial) + 1;



            }



            


            // file name with .xlsx extension  
            //string p_strPath = context.Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString();
            string p_strPath = Server.MapPath("DadaExcel/TechnicalAnalysisv2.xlsx").ToString();

            if (File.Exists(p_strPath))
                File.Delete(p_strPath);

            // Create excel file on physical disk  
            FileStream objFileStrm = File.Create(p_strPath);
            objFileStrm.Close();

            // Write content to excel file  
            File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
            //Close Excel package 
            excel.Dispose();
        }


        public class ExcelData
        {
            public string Col1 { get; set; }
            public string Col2 { get; set; }
            public string Col3 { get; set; }
            public string Col4 { get; set; }
            public string Col5 { get; set; }


            public string Col6 { get; set; }
            public string Col7 { get; set; }
            public string Col8 { get; set; }
            public string Col9 { get; set; }
            public string Col10 { get; set; }

            public string Col11 { get; set; }
            public string Col12 { get; set; }
            public string Col13 { get; set; }
            public string Col14 { get; set; }
            public string Col15 { get; set; }

            public string Col16 { get; set; }
            public string Col17 { get; set; }
            public string Col18 { get; set; }
            public string Col19 { get; set; }
            public string Col20 { get; set; }

            public string Col21 { get; set; }
            public string Col22 { get; set; }
            public string Col23 { get; set; }
            public string Col24 { get; set; }
            public string Col25 { get; set; }


            public string Col26 { get; set; }
            public string Col27 { get; set; }
            public string Col28 { get; set; }
            public string Col29 { get; set; }
            public string Col30 { get; set; }


            public string Col31 { get; set; }
            public string Col32 { get; set; }
            public string Col33 { get; set; }
            public string Col34 { get; set; }
            public string Col35 { get; set; }


            public string Col36 { get; set; }
            public string Col37 { get; set; }
            public string Col38 { get; set; }
            public string Col39 { get; set; }
            public string Col40 { get; set; }

            public string Col41 { get; set; }
            public string Col42 { get; set; }
            public string Col43 { get; set; }
            public string Col44 { get; set; }
            public string Col45 { get; set; }


            public string Col46 { get; set; }
            public string Col47 { get; set; }
            public string Col48 { get; set; }
            public string Col49 { get; set; }
            public string Col50 { get; set; }

            public string Col51 { get; set; }
            public string Col52 { get; set; }
            public string Col53 { get; set; }
            public string Col54 { get; set; }
            public string Col55 { get; set; }


            public string Col56 { get; set; }
            public string Col57 { get; set; }
            public string Col58 { get; set; }
            public string Col59 { get; set; }
            public string Col60 { get; set; }

        }
    }
}