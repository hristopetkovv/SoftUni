namespace SIS.HTTP.Response
{
    public class FileResponse : HttpResponse
    {
        public FileResponse(byte[] fileContent, string ContentType)
        {
            this.StatusCode = HttpResponseCode.OK;
            this.Body = fileContent;
            this.Headers.Add(new Header("Content-Type", ContentType));
            this.Headers.Add(new Header("Content-Length", this.Body.Length.ToString()));
        }
    }
}
