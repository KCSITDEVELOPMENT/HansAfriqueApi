namespace HansAfriqueApi.Dto
{
    public class FileRecordDto
    {
            public int Id { get; set; }
            public string FileName { get; set; }
            public string FileFormat { get; set; }
            public string FilePath { get; set; }
            public string ContentType { get; set; }
            public string AltText { get; set; }
            public string Description { get; set; }
            public int Partid { get; set; }
            public bool IsMain { get; set; }

    }
}