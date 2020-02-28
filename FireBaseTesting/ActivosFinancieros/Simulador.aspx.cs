using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Style;
namespace FireBaseTesting.ActivosFinancieros
{
    public partial class Simulador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CargarDataLocal();
            //var Articles = new[]
            //{
            //    new {
            //        Id = "101", Name = "C++"
            //    },
            //    new {
            //        Id = "102", Name = "Python"
            //    },
            //    new {
            //        Id = "103", Name = "Java Script"
            //    },
            //    new {
            //        Id = "104", Name = "GO"
            //    },
            //    new {
            //        Id = "105", Name = "Java"
            //    },
            //    new {
            //        Id = "106", Name = "C#"
            //    }
            //};

            //ExcelPackage excel = new ExcelPackage();
            //// name of the sheet 
            //var workSheet = excel.Workbook.Worksheets.Add("TechnicalAnalysis");

            //// setting the properties 
            //// of the work sheet  
            //workSheet.TabColor = System.Drawing.Color.Black;
            //workSheet.DefaultRowHeight = 12;

            //// Setting the properties 
            //// of the first row 
            //workSheet.Row(1).Height = 20;
            //workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //workSheet.Row(1).Style.Font.Bold = true;

            //// Header of the Excel sheet 
            //workSheet.Cells[1, 1].Value = "S.No";
            //workSheet.Cells[1, 2].Value = "Id";
            //workSheet.Cells[1, 3].Value = "Name";

            //// Inserting the article data into excel 
            //// sheet by using the for each loop 
            //// As we have values to the first row  
            //// we will start with second row 
            //int recordIndex = 2;

            //foreach (var article in Articles)
            //{
            //    workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
            //    workSheet.Cells[recordIndex, 2].Value = article.Id;
            //    workSheet.Cells[recordIndex, 3].Value = article.Name;
            //    recordIndex++;
            //}

            //// By default, the column width is not  
            //// set to auto fit for the content 
            //// of the range, so we are using 
            //// AutoFit() method here.  
            //workSheet.Column(1).AutoFit();
            //workSheet.Column(2).AutoFit();
            //workSheet.Column(3).AutoFit();

            //// file name with .xlsx extension  
            //string p_strPath = Server.MapPath("DadaExcel/TechnicalAnalysis.xlsx");

            //if (File.Exists(p_strPath))
            //    File.Delete(p_strPath);

            //// Create excel file on physical disk  
            //FileStream objFileStrm = File.Create(p_strPath);
            //objFileStrm.Close();

            //// Write content to excel file  
            //File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
            ////Close Excel package 
            //excel.Dispose();
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


                        ls.Add(new ExcelData
                        {
                            Col1 = worksheet.Cells[i, 1].Text.ToString(),
                            Col2 = worksheet.Cells[i, 2].Text.ToString(),
                            Col3 = worksheet.Cells[i, 3].Text.ToString(),
                            Col4 = worksheet.Cells[i, 4].Text.ToString(),
                            Col5 = worksheet.Cells[i, 5].Text.ToString(),

                            Col6 = worksheet.Cells[i, 6].Text.ToString(),
                            Col7 = worksheet.Cells[i, 7].Text.ToString(),
                            Col8 = worksheet.Cells[i, 8].Text.ToString(),
                            Col9 = worksheet.Cells[i, 9].Text.ToString(),
                            Col10 = worksheet.Cells[i, 10].Text.ToString(),

                            Col11 = worksheet.Cells[i, 11].Text.ToString(),
                            Col12 = worksheet.Cells[i, 12].Text.ToString(),
                            Col13 = worksheet.Cells[i, 13].Text.ToString(),
                            Col14 = worksheet.Cells[i, 14].Text.ToString(),
                            Col15 = worksheet.Cells[i, 15].Text.ToString(),

                            Col16 = worksheet.Cells[i, 16].Text.ToString(),
                            Col17 = worksheet.Cells[i, 17].Text.ToString(),
                            Col18 = worksheet.Cells[i, 18].Text.ToString(),
                            Col19 = worksheet.Cells[i, 19].Text.ToString(),
                            Col20 = worksheet.Cells[i, 20].Text.ToString(),

                            Col21 = worksheet.Cells[i, 21].Text.ToString(),
                            Col22 = worksheet.Cells[i, 22].Text.ToString(),
                            Col23 = worksheet.Cells[i, 23].Text.ToString(),
                            Col24 = worksheet.Cells[i, 24].Text.ToString(),
                            Col25 = worksheet.Cells[i, 25].Text.ToString(),

                            Col26 = worksheet.Cells[i, 26].Text.ToString(),
                            Col27 = worksheet.Cells[i, 27].Text.ToString(),
                            Col28 = worksheet.Cells[i, 28].Text.ToString(),
                            Col29 = worksheet.Cells[i, 29].Text.ToString(),
                            Col30 = worksheet.Cells[i, 30].Text.ToString(),

                            Col31 = worksheet.Cells[i, 31].Text.ToString(),
                            Col32 = worksheet.Cells[i, 32].Text.ToString(),
                            Col33 = worksheet.Cells[i, 33].Text.ToString(),
                            Col34 = worksheet.Cells[i, 34].Text.ToString(),
                            Col35 = worksheet.Cells[i, 35].Text.ToString(),


                            Col36 = worksheet.Cells[i, 36].Text.ToString(),
                            Col37 = worksheet.Cells[i, 37].Text.ToString(),
                            Col38 = worksheet.Cells[i, 38].Text.ToString(),
                            Col39 = worksheet.Cells[i, 39].Text.ToString(),
                            Col40 = worksheet.Cells[i, 40].Text.ToString(),


                            Col41 = worksheet.Cells[i, 41].Text.ToString(),
                            Col42 = worksheet.Cells[i, 42].Text.ToString(),
                            Col43 = worksheet.Cells[i, 43].Text.ToString(),
                            Col44 = worksheet.Cells[i, 44].Text.ToString(),
                            Col45 = worksheet.Cells[i, 45].Text.ToString(),


                            Col46 = worksheet.Cells[i, 46].Text.ToString(),
                            Col47 = worksheet.Cells[i, 47].Text.ToString(),
                            Col48 = worksheet.Cells[i, 48].Text.ToString(),
                            Col49 = worksheet.Cells[i, 49].Text.ToString(),
                            Col50 = worksheet.Cells[i, 50].Text.ToString(),


                            Col51 = worksheet.Cells[i, 51].Text.ToString(),
                            Col52 = worksheet.Cells[i, 52].Text.ToString(),
                            Col53 = worksheet.Cells[i, 53].Text.ToString(),
                            Col54 = worksheet.Cells[i, 54].Text.ToString(),
                            Col55 = worksheet.Cells[i, 55].Text.ToString(),

                            Col56 = worksheet.Cells[i, 56].Text.ToString(),
                            Col57 = worksheet.Cells[i, 57].Text.ToString(),
                            Col58 = worksheet.Cells[i, 58].Text.ToString(),
                            Col59 = worksheet.Cells[i, 59].Text.ToString(),
                            Col60 = worksheet.Cells[i, 60].Text.ToString(),

                        });

                       
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
                    SenalSheet1.Cells[2, c].Value = "SELL";
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

                            if (C1 > C2 && C3 > C4)
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
                    SenalSheet1.Cells[sessiones + 1, c].Value = "NEUTRO";
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