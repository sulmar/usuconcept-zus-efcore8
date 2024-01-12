namespace TableSplitting.Model;

internal class Attachment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public required string ContentType { get; set; }
    public required DetailedAttachment DetailedAttachment { get; set; }   
}


internal class DetailedAttachment
{
    public int Id { get; set; }
    public required string ContentType { get; set; } // wspóldzielone pole

    public string Filename { get; set; }
    public byte[] Content { get; set; }
}
