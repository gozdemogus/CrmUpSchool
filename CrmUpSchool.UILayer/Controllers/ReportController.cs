using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrmUpSchool.UILayer.Controllers
{
    //[Area("Admin")]
     [Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        public IActionResult ReportList()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult ExcelStatic()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells[1, 1].Value = "Personel ID";
            workSheet.Cells[1, 2].Value = "Personel Adı";
            workSheet.Cells[1, 3].Value = "Personel Soyadı";

            workSheet.Cells[2, 1].Value = "0001";
            workSheet.Cells[2, 2].Value = "Tuba";
            workSheet.Cells[2, 3].Value = "Tuba";

            workSheet.Cells[3, 1].Value = "002";
            workSheet.Cells[3, 2].Value = "Serap";
            workSheet.Cells[3, 3].Value = "Serap";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "personeller.xlsx");
        }

        public List<CustomerViewModel> CustomerList()
        {
            List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
            using (var context = new Context())
            {
                customerViewModels = context.Customers.Select(x => new CustomerViewModel
                {
                    Mail = x.CustomerMail,
                    Name = x.CustomerName,
                    Surname = x.CustomerSurname,
                    Phone = x.CustomerPhone
                }).ToList();
            }
            return customerViewModels;
        }

        public IActionResult DynamicExcel()
        {
            using (var workBook=new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Müşteri Listesi");
                workSheet.Cell(1, 1).Value = "Müşteri Adresi";
                workSheet.Cell(1, 2).Value = "Müşteri Adı";
                workSheet.Cell(1, 3).Value = "Müşteri Soyadı";
                workSheet.Cell(1, 4).Value = "Müşteri Telefon";

                int rowCount = 2;
                foreach (var item in CustomerList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.Mail;
                    workSheet.Cell(rowCount, 2).Value = item.Name;
                    workSheet.Cell(rowCount, 3).Value = item.Surname;
                    workSheet.Cell(rowCount, 4).Value = item.Phone;
                    rowCount++;
                }
                using (var stream= new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","musteri_listesi.xlsx");
                }
            }
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "musteri.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            //string imagePath = "https://avatars.githubusercontent.com/u/107196935?v=4";
            //Image image = Image.GetInstance(imagePath);
            //image.ScaleAbsolute(100, 100); // width and height in user unit
            //image.SetAbsolutePosition(70, 700);
            //document.Add(image);

            //Paragraph paragraph = new Paragraph("Akbank");
            //document.Add(paragraph);

            //Paragraph header = new Paragraph("My PDF Document");
            //header.Font = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            //document.Add(header);

            //Paragraph coloredText = new Paragraph("This text is red.");
            //coloredText.Font.Color = BaseColor.RED;
            //document.Add(coloredText);

            // Add personal information
            Paragraph name = new Paragraph("John Doe");
            name.Alignment = Element.ALIGN_LEFT;
            name.Font = FontFactory.GetFont(FontFactory.HELVETICA, 24, Font.BOLD);
            document.Add(name);

            Paragraph address = new Paragraph("123 Main St, Anytown USA 12345");
            address.Alignment = Element.ALIGN_LEFT;
            address.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
            document.Add(address);

            Paragraph phone = new Paragraph("(555) 555-5555");
            phone.Alignment = Element.ALIGN_LEFT;
            phone.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
            document.Add(phone);

            Paragraph email = new Paragraph("johndoe@email.com");
            email.Alignment = Element.ALIGN_LEFT;
            email.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
            document.Add(email);

            document.Add(new Paragraph("\n")); //add empty line 

            // Add a section header
            Paragraph summaryHeader = new Paragraph("Summary");
            summaryHeader.Alignment = Element.ALIGN_LEFT;
            summaryHeader.Font.Color = BaseColor.BLUE;
            summaryHeader.Font = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            document.Add(summaryHeader);

            // Add summary text
            Paragraph summary = new Paragraph("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed auctor, magna a feugiat placerat, ipsum risus accumsan augue, et malesuada nibh orci id quam. Sed rutrum, ipsum at malesuada dictum, ipsum velit aliquam velit, id aliquam turpis nulla vel nisl.");
            document.Add(summary);

            //Add  a photo
            string photoPath = "https://avatars.githubusercontent.com/u/107196935?v=4";
            Image photo = Image.GetInstance(photoPath);
            photo.ScaleToFit(100f, 150f);
            photo.SetAbsolutePosition(450f, 750f);
            document.Add(photo);

            document.Add(new Paragraph("\n")); //add empty line 

            Paragraph experienceHeader = new Paragraph("Experience");
            experienceHeader.Alignment = Element.ALIGN_LEFT;
            experienceHeader.Font.Color = BaseColor.BLUE;
            experienceHeader.Font = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            document.Add(experienceHeader);

            // Add job experience
            Paragraph jobTitle = new Paragraph("Job Title - Company Name");
            jobTitle.Alignment = Element.ALIGN_LEFT;
            jobTitle.Font = FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD);
            document.Add(jobTitle);

            Paragraph jobDates = new Paragraph("January 2020 - Present");
            jobDates.Alignment = Element.ALIGN_LEFT;
            jobDates.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
            document.Add(jobDates);

            Paragraph jobDescription = new Paragraph("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed auctor, magna a feugiat placerat, ipsum risus accumsan augue, et malesuada nibh orci id quam. Sed rutrum, ipsum at malesuada dictum, ipsum velit aliquam velit, id aliquam turpis nulla vel nisl.");
            document.Add(jobDescription);

            document.Add(new Paragraph("\n")); //add empty line 

            // Add a section header
            Paragraph educationHeader = new Paragraph("Education");
            educationHeader.Alignment = Element.ALIGN_LEFT;
            educationHeader.Font.Color = BaseColor.BLUE;
            educationHeader.Font = FontFactory.GetFont(FontFactory.HELVETICA, 18, Font.BOLD);
            document.Add(educationHeader);

            // Add education
            Paragraph degree = new Paragraph("Bachelor of Science in Computer Science - University Name");
            degree.Alignment = Element.ALIGN_LEFT;
            degree.Font = FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD);
            document.Add(degree);

            Paragraph graduationDate = new Paragraph("May 2018");
            graduationDate.Alignment = Element.ALIGN_LEFT;
            graduationDate.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL);
            document.Add(graduationDate);
       

            document.Close();

            return File("/PdfReports/musteri.pdf", "application/pdf", "musteri.pdf");
        }
    }

}