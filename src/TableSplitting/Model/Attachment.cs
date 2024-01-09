namespace TableSplitting.Model;

internal class Attachment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public required string ContentType { get; set; }
    public string Filename { get; set; }
    public byte[] Content { get; set; }    
}

