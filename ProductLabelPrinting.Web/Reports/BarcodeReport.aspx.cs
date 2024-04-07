using Microsoft.IdentityModel.Tokens;
using Microsoft.Reporting.WebForms;
using ProductLabelPrinting.Data;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductLabelPrinting.Web.Report
{
    public partial class BarcodeReport : System.Web.UI.Page
    {
        private ProductLabelPrintingDbEntities _dbContext = new ProductLabelPrintingDbEntities();
        public class spPrintingITemsReturn
        {
            public Int64 UniqueId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string CAS { get; set; }
            public string ManufacturerLicence { get; set; }
            public string ChemicalFormula { get; set; }
            public decimal MolecularWeight { get; set; }
            public string BatchNo { get; set; }
            public decimal GrossWeight { get; set; }
            public decimal TareWeight { get; set; }
            public decimal NetWeight { get; set; }
            public string ManufactureDate { get; set; }
            public string Retest { get; set; }
            public string RetestDate { get; set; }
            public string MasterLabel { get; set; }
            public string UniqueCode { get; set; }
            public string StorageConditon { get; set; }
            public string CompanyName { get; set; }
            public string CompanyAddress { get; set; }
            public string Container { get; set; }
            public decimal BatchSize { get; set; }
            public bool NeutralLabel { get; set; }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["productId"] == null || Request.QueryString["batchId"] == null)
                {
                    Response.Redirect("/Account/Login");
                }

                var ProductId = new SqlParameter("@ProductId", Request.QueryString["productId"]);
                var BatchNo = new SqlParameter("@BatchNo", Request.QueryString["batchId"]);

                var result = _dbContext.Database
                        .SqlQuery<spPrintingITemsReturn>("spGetPrintingITems  @ProductId , @BatchNo", ProductId, BatchNo)
                        .ToList();

                System.IO.DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Barcode"));

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

                var qrString = string.Empty;

                var DataSourceList = new List<spPrintingITemsReturn>();
                int ContainerTotal = result.Count;

                if (result.Count > 0)
                {
                    DataSourceList.Add(new spPrintingITemsReturn
                    {
                        UniqueId = 0,
                        UniqueCode = result[0].UniqueCode,
                        ProductId = result[0].ProductId,
                        ProductName = result[0].ProductName,
                        CAS = result[0].CAS,
                        ManufacturerLicence = result[0].ManufacturerLicence,
                        ChemicalFormula = result[0].ChemicalFormula,
                        MolecularWeight = result[0].MolecularWeight,
                        BatchNo = result[0].BatchNo,
                        GrossWeight =Convert.ToDecimal("0.00"),
                        TareWeight = Convert.ToDecimal("0.00"),
                        NetWeight = Convert.ToDecimal("0.00"),
                        ManufactureDate = result[0].ManufactureDate,
                        Retest = result[0].Retest,
                        RetestDate = result[0].RetestDate,
                        MasterLabel = result[0].MasterLabel,
                        StorageConditon = result[0].StorageConditon,
                        CompanyName = result[0].CompanyName,
                        CompanyAddress = result[0].CompanyAddress,
                        Container = "0 / 0",
                        BatchSize = result[0].BatchSize,
                        NeutralLabel = result[0].NeutralLabel
                    }); ;
                }

                foreach (var item in result)
                {
                    DataSourceList.Add(new spPrintingITemsReturn
                    {
                        UniqueId = item.UniqueId,
                        UniqueCode = item.UniqueCode,
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        CAS = item.CAS,
                        ManufacturerLicence = item.ManufacturerLicence,
                        ChemicalFormula = item.ChemicalFormula,
                        MolecularWeight = item.MolecularWeight,
                        BatchNo = item.BatchNo,
                        GrossWeight = item.GrossWeight,
                        TareWeight = item.TareWeight,
                        NetWeight = item.NetWeight,
                        ManufactureDate = item.ManufactureDate,
                        Retest = item.Retest,
                        RetestDate = item.RetestDate,
                        MasterLabel = item.MasterLabel,
                        StorageConditon = item.StorageConditon,
                        CompanyName = item.CompanyName,
                        CompanyAddress = item.CompanyAddress,
                        Container = item.Container+" / "+ContainerTotal,
                        BatchSize = item.BatchSize,
                        NeutralLabel = item.NeutralLabel
                    });

                }



                foreach(var item in DataSourceList)
                {
                    qrString = $"Unique product identification code: {item.UniqueCode};\nName of the API: {item.ProductName} ;";

                    qrString = (item.NeutralLabel == true ? qrString + "" : qrString + $"Name and address of the manufacturer: {item.CompanyName} , Mfg. Site Address: {item.CompanyAddress},");

                    qrString = qrString + $" Batch no.: {item.BatchNo}; Batch Size: {item.BatchSize} Kgs.; Date of manufacturing: {item.ManufactureDate}; Date of {item.Retest}:\n{item.RetestDate}; Serial Shipping container code: {item.Container} "+(item.Container== "0 / 0 / 1" ? "0 / 0 ;":";");

                    qrString = qrString + (item.NeutralLabel == true ? "Neutral No.:" : " Manufacturing licence no.:") + item.ManufacturerLicence+";";

                    qrString = qrString + " Special storage conditions: " + item.StorageConditon + ".;";

                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrString, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);

                    string folderPath = Server.MapPath("~/Barcode");

                    // Create the folder if it doesn't exist
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Save the QR code as a PNG image file inside the specified folder
                    string fileName = Path.Combine(folderPath, item.UniqueId + ".png");
                    qrCodeImage.Save(fileName, ImageFormat.Png);
                }

                //create barcode and save to barcode folder with id of product
                ReportDataSource rdc = new ReportDataSource("PrintingItem", DataSourceList);

                ReportParameter[] params123 = new ReportParameter[1];
                params123[0] = new ReportParameter("TotalContainer", result.Count().ToString(), false);

                //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/Report1.rdlc");

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/Report1.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.LocalReport.DataSources.Add(rdc);

                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.DataBind();
            }
        }
    }
}