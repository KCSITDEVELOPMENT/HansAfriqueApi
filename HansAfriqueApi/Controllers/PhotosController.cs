using HansAfriqueApi.Data;
using HansAfriqueApi.Dto;
using HansAfriqueApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HansAfriqueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string AppDirectory = Path.Combine("../HansAfriquePics/src/assets/PhotoUploads/");
        private static List<FileRecordDto> fileDB = new List<FileRecordDto>();

        public PhotosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> PostAsync([FromForm] FileModelDto model, int id)
        {
            try
            {
                FileRecordDto file = await SaveFileAsync(model.MyFile);

                if (!string.IsNullOrEmpty(file.FilePath))
                {
                    var ProductPhotos = _context.Photos.Where(n => n.Partid == id).Count();
                    if (ProductPhotos == 0) {
                        file.IsMain = true;
                    }

                    file.AltText = model.AltText;
                    file.Description = model.Description;
                    file.Partid = id;
                    SaveToDB(file);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                };
            }
        }

        private async Task<FileRecordDto> SaveFileAsync(IFormFile myFile)
        {
            FileRecordDto file = new FileRecordDto();
            if (myFile != null)
            {
                if (!Directory.Exists(AppDirectory))
                    Directory.CreateDirectory(AppDirectory);

                var fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(myFile.FileName);
                var path = AppDirectory+ fileName;

                file.Id = fileDB.Count() + 1;
                file.FilePath = path;
                file.FileName = fileName;
                file.FileFormat = Path.GetExtension(myFile.FileName);
                file.ContentType = myFile.ContentType;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await myFile.CopyToAsync(stream);
                }

                return file;
            }
            return file;

        }

        private void SaveToDB(FileRecordDto record)
        {
            if (record == null)
                throw new ArgumentNullException($"{nameof(record)}");

            

            FileData fileData = new FileData();
            fileData.FilePath = record.FilePath;
            fileData.FileName = record.FileName;
            fileData.FileExtension = record.FileFormat;
            fileData.MimeType = record.ContentType;
            fileData.Partid = record.Partid;
            fileData.IsMain = record.IsMain;

            _context.Photos.Add(fileData);
            _context.SaveChanges();
       
        }

        [HttpGet]
        public List<FileRecordDto> GetAllFiles()
        {

            return _context.Photos.Select(n => new FileRecordDto
            {
                ContentType = n.MimeType,
                FileFormat = n.FileExtension,
                FileName = n.FileName,
                FilePath = n.FilePath
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            if (!Directory.Exists(AppDirectory))
                Directory.CreateDirectory(AppDirectory);

            //getting file from inmemory obj
            //var file = fileDB?.Where(n => n.Id == id).FirstOrDefault();
            //getting file from DB
            var file = _context.Photos.Where(n => n.Id == id).FirstOrDefault();

            var path = Path.Combine(AppDirectory, file?.FilePath);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);
        }

    }
}
