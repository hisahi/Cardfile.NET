namespace CardfileDotNet.Data
{
    public class AttachmentFile
    {
        public string Name { get; set; }
        public string Mime { get; set; }
        public byte[] Data { get; set; }

        public AttachmentFile(string name, string mime, byte[] data)
        {
            Name = name;
            Mime = mime;
            Data = data;
        }
    }
}