namespace CFI_Track3_Squad3_Backend.Infrectuture
{
    public class ApiErrorResponse
    {
        public int Status { get; set; }
        public List<ResponseError> Error { get; set; }

        public class ResponseError
        {
            public string? Error { get; set; }
        }
    }
}
